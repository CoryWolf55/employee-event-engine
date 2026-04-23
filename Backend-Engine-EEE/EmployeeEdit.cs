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
            LocalDB.Employees.Add(newEmployee);
            Console.WriteLine("Successfully Created Employee");
            ManageEmployee(newEmployee);
        }

        public static void SearchEmployee()
        {
            Console.WriteLine("What is the employees name?");
            string? name = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(name)) 
            {
                Console.WriteLine("Invalid Name");
                SearchEmployee();
                return;
            }

            var foundEmployees = LocalDB.Employees.Where(e => e.Name.ToLower() == name.ToLower()).ToList();
            if (foundEmployees.Count == 0) 
            {
                Console.WriteLine("There were no employees with that name");
                SearchEmployee();
                return;
            }
        }

        public static void EmployeeFunctions(int ID)
        {
            //Take in ID and give employee functions
            Employee e = FindEmployeeByID(ID);
            if(e == null)
                return;

            Console.WriteLine("Welcome " + e.Name);
            Console.WriteLine("Would you like to: ");
            Console.WriteLine("1: Clock in/out");
            Console.WriteLine("2: Exit");

            string? input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    EmployeeClockInOut(e);
                    break;
                case "2":
                    Console.WriteLine("Exiting");
                    break; ;
                default:
                    Console.WriteLine("Invalid");
                    break;
            }

        }

        private static void EmployeeClockInOut(Employee e)
        {
            //Check status of last action - Do opposite - Log it
            if(e.TimeEntries.Count <= 0)
            {
                ClockIn(e);
                return;
            }

            var lastEntry = e.TimeEntries.Last();
            if(lastEntry.Type == ClockType.In)
            {
                ClockOut(e);
                return;
            }
            ClockIn(e);

        }

        private static void ClockIn(Employee e)
        {
            var now = DateTime.UtcNow;
            e.TimeEntries.Add(new TimeEntry { Type = ClockType.In, Time = now});
            Console.WriteLine("Successfully clocked in at: " + now);
        }
        private static void ClockOut(Employee e)
        {
            var now = DateTime.UtcNow;
            e.TimeEntries.Add(new TimeEntry { Type = ClockType.Out, Time = now });
            Console.WriteLine("Successfully clocked out at: " + now);
        }

        private static Employee FindEmployeeByID(int ID)
        {
            Employee e = LocalDB.Employees.FirstOrDefault(n => n.EmployeeId == ID);
            if(e == null)
            {
                Console.WriteLine("Employee not found");
                return null;
            }
            return e;
        }

        private static void CreateEmployeeName(Employee employee)
        {
            Console.WriteLine("Please Enter the Employees Name: ");
            try
            {
                string? name = Console.ReadLine();
                if (name != null)
                {
                    employee.Name = name;
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Invalid Name");
                CreateEmployeeName(employee);
            }
            return;
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
            return;
        }


        private static void ManageEmployee(Employee e)
        {
            Console.WriteLine("You are managing: " +  e.Name + " " + e.EmployeeId);
            Console.WriteLine("What would you like to do?: ");
            Console.WriteLine("1: Check Report");
            Console.WriteLine("2: Offboard Employee");
            Console.WriteLine("3: Exit");
            string? input  = Console.ReadLine();
            switch(input) {
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
