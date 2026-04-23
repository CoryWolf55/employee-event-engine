using System.Xml.Linq;

namespace Backend_Engine_EEE
{

    class Program
    {
        static void Main(string[] args)
        {
            //Plan - 
            //1. Create an employee tracking system. This should allow onboarding, offboarding,
            // Clock in, Clock out, and tracking of hours worked. It should also allow for
            // the generation of reports on employee hours and attendance.
            bool active = true;
            while(active) {
                Console.WriteLine("Welcome to the Employee Tracking System!");
                Console.WriteLine("Please select an option:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Employee");
                Console.WriteLine("3. Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Admin selected.");

                        AdminFunc();
                        break;
                    case "2":
                        Console.WriteLine("Employee selected.");
                        EmployeeFunc();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        active = false;
                        break;
                    case "4":
                        foreach(Employee employee in LocalDB.Employees)
                        {
                            Console.WriteLine($"ID: {employee.EmployeeId}, Name: {employee.Name}");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AdminFunc()
        {
            Console.WriteLine("Admin functions will be implemented here.");
            // Implement admin functionalities such as onboarding, offboarding, and report generation.

            Console.WriteLine("Please select an admin function:");
            Console.WriteLine("1. Onboard Employee");
            Console.WriteLine("2. Search Employee");
            Console.WriteLine("3. Exit");
            string? input = Console.ReadLine();
            if (input == null)
                return;
            int response = int.Parse(input);
            switch (response)
            {
                case 1:
                    Console.WriteLine("Onboarding Employee...");
                    EmployeeEdit.OnboardEmployee();
                    break;
                case 2:
                    Console.WriteLine("Searching Employee...");
                    EmployeeEdit.SearchEmployee();
                    break;
                case 3:
                    Console.WriteLine("Exiting Admin functions.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }


        static void EmployeeFunc()
        {
            Console.WriteLine("Employee functions will be implemented here.");
            // Implement employee functionalities such as clocking in, clocking out, and viewing hours worked.

            Console.WriteLine("Please Enter your employee ID: ");


            try 
            {
                string? input = Console.ReadLine();
                if (input == null)
                {
                    Console.WriteLine("Invalid Response");
                    return;
                }
                    
                int id = int.Parse(input);
                if (!CheckEmployeeLogin(id))
                {
                    Console.WriteLine("Invalid employee ID. Please try again.");
                    return;
                }
                EmployeeEdit.EmployeeFunctions(id);
            }
            catch 
            {
                Console.WriteLine("Improper answer!");
            }
        }


        static bool CheckEmployeeLogin(int Id)
        {
            //Check ID to db
            Employee employee = LocalDB.Employees.FirstOrDefault(e => e.EmployeeId == Id);
            if (employee == null)
            {
                return false;
            }

            Console.WriteLine($"Welcome {employee.Name}!");
            // Implement clock in, clock out, and hours tracking for the employee.
            return true;

        }

    }

}





