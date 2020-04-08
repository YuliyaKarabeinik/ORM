using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LinqToDB;

namespace ORM.Extensions
{
    public static class QueryExtensions
    {
        [ExpressionMethod("CoursesImpl")]
        public static IEnumerable<Territory> GetTerritories(this Employee employee)
        {
           // return emp => emp.EmployeeTerritories.Select(et => et.Territory);
            return (_coursesImpl ?? (_coursesImpl = CoursesImpl().Compile()))(employee);
        }

        static Func<Employee, IEnumerable<Territory>> _coursesImpl;
        static Expression<Func<Employee, IEnumerable<Territory>>> CoursesImpl()
        {
            return emp => emp.EmployeeTerritories.Select(et => et.Territory);
        }
    }
}
