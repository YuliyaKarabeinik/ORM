using LinqToDB;
using LinqToDB.Data;

namespace ORM
{
    public class NorthwindContext : DataConnection
    {
        public NorthwindContext(string configurationString) : base(configurationString)
        { }

        public ITable<Category> Categories => GetTable<Category>();

        public ITable<Product> Products => GetTable<Product>();

        public ITable<Supplier> Suppliers => GetTable<Supplier>();

        public ITable<Employee> Employees => GetTable<Employee>();

        public ITable<EmployeeTerritory> EmployeeTerritories => GetTable<EmployeeTerritory>();

        public ITable<Territory> Territories => GetTable<Territory>();

        public ITable<Region> Regions => GetTable<Region>();

        public ITable<Order> Orders => GetTable<Order>();

        public ITable<Shipper> Shippers => GetTable<Shipper>();

    }
}
