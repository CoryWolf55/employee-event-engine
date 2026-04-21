using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Backend_Engine_EEE
{
    internal class EmployeeEdit
    {
        public static void OnboardEmployee()
        {
            //This is where the admin can set up an employee
            Employee newEmployee = new();
            CreateEmployeeName(newEmployee);
            CreateEmployeeID(newEmployee);
            Console.WriteLine("Successfully Created Employee");
            ManageEmployee(newEmployee);
        }

        public static void SearchEmployee()
        {
            Console.WriteLine("What is the employees name?");
            string name = Console.ReadLine();
            if (name == null) 
            {
                Console.WriteLine("Invalid Name");
                SearchEmployee();
                return;
            }

            var foundEmployees = LocalDB.Employees.Where(e => e.Name.ToLower() == name.ToLower()).ToList();
            if (foundEmployees.Count == 0 || foundEmployees == null) 
            {
                Console.WriteLine("There were no employees with that name");
                SearchEmployee();
                return;
            }
        }

        private static void CreateEmployeeName(Employee employee)
        {
            Console.WriteLine("Please Enter the Employees Name: ");
            try
            {
                string name = Console.ReadLine();
                if (name != null)
                {
                    employee.Name = name;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Name");
                CreateEmployeeName(employee);
                return;
            }
        }

        private static readonly Random rnd = new Random();
        private static void CreateEmployeeID(Employee employee)
        {
            var existingIds = LocalDB.Employees.Select(e => e.EmployeeId).ToHashSet();

            int chosenId;
            do
            {
                chosenId = rnd.Next(100000); //Max ID -> 99999
            } while (existingIds.Contains(chosenId));

            //Setting it in DB
            employee.EmployeeId = chosenId;
        }


        private static void ManageEmployee(Employee e)
        {
            Console.WriteLine("You are managing: " +  e.Name + " " + e.EmployeeId);
            Console.WriteLine("What would you like to do?: ");
            Console.WriteLine("1: Check Report");
            Console.WriteLine("2: Offboard Employee");
            Console.WriteLine("3: Exit");

            switch(Console.ReadLine()) {
                case "1": 
                    Console.WriteLine("Getting Report");
                    GrabReport(e);
                    break;
                case "2":
                    Console.WriteLine("Offboarding Employee");
                    LocalDB.Employees.Remove(e); //Temp
                    break;
                case "3":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }
               

        }

        static void GrabReport(Employee e)
        {
            //Returning report for 
        }


    }
}
