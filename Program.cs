using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzz6
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Task1
            List<Task1__1> employees = new List<Task1__1>
            {
                new Task1__1{Name = "Alice", Department = "HR", Salary = 60000, PositionLevel = "Manager"},
                new Task1__1{Name = "Tom", Department = "iT", Salary = 60000, PositionLevel = "Specialist"},
                new Task1__1{Name = "Eva", Department = "Finance", Salary = 60000, PositionLevel = "Manager"}
            };

            var averageSalariesByDepartment = employees //средняя зп каждого отдела
                .GroupBy(e => e.Department).Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                });


            var highestAverageSalaryDepartament = averageSalariesByDepartment //отдел с самой высокой средней зп
                .OrderByDescending(d => d.AverageSalary).First();

            double overallAverageSalary = employees.Average(e => e.Salary); //работники с зарплатой выше средней
            var employeesAboveAverage = employees
                .Where(e => e.Salary > overallAverageSalary).ToList();

            var totalSalariesByPositionLevel = employees //суммарная зарплата по уровню должности
                .GroupBy(e => e.PositionLevel).Select(q => new
                {
                    PositionLevel = q.Key,
                    TotalSalary = q.Sum(e => e.Salary)
                });


            //Task2
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction { TransactionId = Guid.NewGuid(), Amount = 100.0, Date =new DateTime(2023, 1, 4) },
                new Transaction { TransactionId = Guid.NewGuid(), Amount = 195.0, Date = new DateTime(2023, 2, 4) },
                new Transaction { TransactionId = Guid.NewGuid(), Amount = 200.0, Date = new DateTime(2023, 1, 4) }
            };

            DateTime startDate = new DateTime(2023, 1, 4);
            DateTime endDate = new DateTime(2023, 2, 28);

            double averageamount = TransactionAnalyzer.CalculateAverageAmount(transactions, startDate, endDate);

            //Task3
            List<object> objects = new List<object>
            {
                new Foo{ Id = Guid.NewGuid(), Name = "Apple", Description = "Fruit"},
                new Foo{ Id = Guid.NewGuid(), Name = "Banana", Description = "Fruit"}
            };

            var result = StringPropertyAnalyzer.CalculateAverageStringLength(objects);


        }
    }
}
