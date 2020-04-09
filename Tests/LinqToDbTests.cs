using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using NUnit.Framework;
using ORM;
using ORM.Models;
using Tests.Configuration;

namespace Tests
{
    [TestFixture]
    public class LinqToDbTests
    {
        private string ConfigurationString => Config.ConfigurationString;
        private NorthwindContext connection;

        [SetUp]
        public void SetUp()
        {
            connection = new NorthwindContext(ConfigurationString);
        }

        [TearDown]
        public void TearDown()
        {
            connection.Dispose();
        }

        [Test]
        public void GetProductsTest()
        {
            foreach (var prod in connection.Products.LoadWith(p => p.Category).LoadWith(p => p.Supplier))
            {
                Console.WriteLine($"{prod}\n");
            }
        }

        [Test]
        public void GetEmployeesTest()
        {
            var employees = from emp in connection.Employees
                            join empTerr in connection.EmployeeTerritories on emp.EmployeeId equals empTerr.EmployeeId into temp1
                            from r1 in temp1.DefaultIfEmpty()
                            join terr in connection.Territories on r1.TerritoryId equals terr.TerritoryId into temp2
                            from r2 in temp2.DefaultIfEmpty()
                            join reg in connection.Regions on r2.RegionId equals reg.RegionId into temp3
                            from r3 in temp3.DefaultIfEmpty()
                            select new
                            {
                                Employee = emp,
                                Region = r3
                            };

            foreach (var emp in employees.Distinct())
            {
                Console.WriteLine($"{emp}\n");
            }
        }

        [Test]
        public void GetEmployeesAmountTest()
        {
            var query = from reg in connection.Regions
                        join ter in connection.Territories on reg.RegionId equals ter.RegionId into temp1
                        from r1 in temp1.DefaultIfEmpty()
                        join terr in connection.EmployeeTerritories on r1.TerritoryId equals terr.TerritoryId into temp2
                        from r2 in temp2.DefaultIfEmpty()
                        join emp in connection.Employees on r2.EmployeeId equals emp.EmployeeId into temp3
                        from r3 in temp3.DefaultIfEmpty()
                        select new
                        {
                            Region = reg,
                            r3.EmployeeId
                        };

            var result = query.Distinct().GroupBy(q => q.Region).Select(g => new { Region = g.Key, EmpCount = g.Count() });

            foreach (var r in result)
            {
                Console.WriteLine($"{r}\n");
            }
        }

        [Test]
        public void GetEmployeesWithShippersTest()
        {
            var result = (from emp in connection.Employees
                          join ord in connection.Orders on emp.EmployeeId equals ord.EmployeeId into temp1
                          from r1 in temp1.DefaultIfEmpty()
                          join sh in connection.Shippers on r1.ShipperId equals sh.ShipperId into temp2
                          from r2 in temp2.DefaultIfEmpty()
                          select new
                          {
                              Employee = emp.EmployeeId,
                              Shipper = r2.ShipperId,
                          })
                .Distinct().GroupBy(r => r.Employee).Select(p => new
                {
                    EmployeeId = p.Key,
                    ShipperId = p.Select(r => r.Shipper)
                });

            foreach (var r in result)
            {
                Console.WriteLine($"EmployeeId: {r.EmployeeId}");
                foreach (var sh in r.ShipperId)
                {
                    Console.WriteLine($"ShipperId: {sh}");
                }
                Console.WriteLine();
            }
        }

        [Test]
        public void AddEmployeeWithTerritories()
        {
            var employee = new Employee
            {
                FirstName = "Test First",
                LastName = "Test Last"
            };

            employee.EmployeeId = Convert.ToInt32(connection.InsertWithIdentity(employee));

            connection.Territories.Where(t => t.TerritoryDescription == "Boston")
                .Insert(
                    connection.EmployeeTerritories,
                    t => new EmployeeTerritory
                    {
                        EmployeeId = employee.EmployeeId,
                        TerritoryId = t.TerritoryId
                    });
        }

        [Test]
        public void ChangeProductsCategory()
        {
            var updatedCount = connection.Products
                .Update(p => p.CategoryId == 1, pr =>
                    new Product()
                    {
                        CategoryId = 2
                    });
        }

        [Test]
        public void AddProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductName = "Product1",
                    Category = new Category {CategoryName = "Category1"},
                    Supplier = new Supplier {CompanyName = "Supplier1"}
                },
                new Product
                {
                    ProductName = "Product2",
                    Category = new Category {CategoryName = "Category1"},
                    Supplier = new Supplier {CompanyName = "Supplier1"}
                }
            };

            foreach (var product in products)
            {
                var category = connection.Categories
                    .FirstOrDefault(c => c.CategoryName == product.Category.CategoryName);

                product.CategoryId = category?.CategoryId ?? Convert.ToInt32(connection.InsertWithIdentity(
                                         new Category
                                         {
                                             CategoryName = product.Category.CategoryName
                                         }));

               var supplier = connection.Suppliers
                    .FirstOrDefault(c => c.CompanyName == product.Supplier.CompanyName);

               product.SupplierId = supplier?.SupplierId ?? Convert.ToInt32(connection.InsertWithIdentity(
                                        new Supplier
                                        {
                                            CompanyName = product.Supplier.CompanyName
                                        }));
            }

            connection.BulkCopy(products);
        }

        [Test]
        public void ChangeProduct()
        {
            connection.OrderDetails.LoadWith(od => od.Order).LoadWith(od => od.Product)
                .Where(od => od.Order.ShippedDate == null)
                .Update(od => new OrderDetail
                {
                    ProductId = connection.Products.FirstOrDefault(p => p.CategoryId ==od.Product.CategoryId && p.ProductId > od.ProductId) != null 
                                ? connection.Products.First(p => p.CategoryId == od.Product.CategoryId && p.ProductId > od.ProductId).ProductId
                                : connection.Products.First(p => p.CategoryId == od.Product.CategoryId && p.ProductId == od.ProductId).ProductId
                });
        }
    }
}
