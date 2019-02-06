using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using ExercLambda.Entities;

namespace ExercLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter full file path: ");
                string path = Console.ReadLine();

                Console.Write("Enter salary: ");
                double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                List<Employee> employees = new List<Employee>();

                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] vet = sr.ReadLine().Split(',');

                        string name = vet[0];
                        string email = vet[1];
                        double salary = double.Parse(vet[2], CultureInfo.InvariantCulture);

                        employees.Add(new Employee(name, email, salary));
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Email of people whose salary is more than 2000.00: ");

                var emails = employees.Where(x => x.Salary > value).OrderBy(x => x.Email).Select(x => x.Email);

                foreach (string email in emails)
                {
                    Console.WriteLine(email);
                }
                var sum = employees.Where(x => x.Name.ToString().Contains('M')).Sum(x => x.Salary);

                Console.Write("Sum of salary of people whose name starts with 'M':");
                Console.WriteLine(sum.ToString("F2", CultureInfo.InvariantCulture));
                Console.ReadLine();
            }
            catch(IOException e)
            {
                Console.WriteLine("Error!" + e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error! " + e.Message);
            }           
        }
    }
}
