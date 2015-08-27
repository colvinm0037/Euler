using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Notes
{
    class Generics
    {
        public class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
        {

            public bool Equals(Employee x, Employee y)
            {
                return (x.Name.Equals(y.Name));
            }

            public int GetHashCode(Employee obj)
            {
                return obj.Name.GetHashCode();
            }

            public int Compare(Employee x, Employee y)
            {
                return String.Compare(x.Name, y.Name);
            }
        }

        public class DepartmentCollection : SortedDictionary<string, SortedSet<Employee>>
        {
            public DepartmentCollection Add(string departmentName, Employee employee)
            {
                if (!ContainsKey(departmentName))
                {
                    Add(departmentName, new SortedSet<Employee>(new EmployeeComparer()));
                }
                this[departmentName].Add(employee);
                return this;
            }
        }

        void Main()
        {
            var departments = new DepartmentCollection();

            departments.Add("Sales", new Employee { Name = "Micah" })
                       .Add("Sales", new Employee { Name = "Charlie" })
                       .Add("Sales", new Employee { Name = "James" })
                       .Add("Sales", new Employee { Name = "James" });

            departments.Add("Engineering", new Employee { Name = "Jon" })
                       .Add("Engineering", new Employee { Name = "Bob" })
                       .Add("Engineering", new Employee { Name = "Don" })
                       .Add("Engineering", new Employee { Name = "Bob" });

            foreach (var item in departments)
            {
                Console.WriteLine(item.Key);
                foreach (var employee in item.Value)
                {
                    Console.WriteLine("\t" + employee.Name);
                }
            }
        }

        public class Employee
        {
            public string Name { get; set; }
            //	public Employee(string name)
            //	{
            //		this.Name = name;
            //	}
        }
    }
}
