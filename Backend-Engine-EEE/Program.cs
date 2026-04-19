using Backend_Engine_EEE;

LocalDB db = new LocalDB();
Console.WriteLine("Hello, World!");


//Plan - 
//1. Create an employee tracking system. This should allow onboarding, offboarding,
// Clock in, Clock out, and tracking of hours worked. It should also allow for
// the generation of reports on employee hours and attendance.

Console.WriteLine("Welcome to the Employee Tracking System!");
Console.WriteLine("Please select an option:");
Console.WriteLine("1. Admin");
Console.WriteLine("2. Employee");
Console.WriteLine("3. Exit");

switch(Console.ReadLine())
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
        break;
    default:
        Console.WriteLine("Invalid option. Please try again.");
        break;
}

static void AdminFunc()
{
    Console.WriteLine("Admin functions will be implemented here.");
    // Implement admin functionalities such as onboarding, offboarding, and report generation.

    Console.WriteLine("Please select an admin function:");
    Console.WriteLine("1. Onboard Employee");
    Console.WriteLine("2. Search Employee");
    Console.WriteLine("3. Exit");

    int response = int.Parse(Console.ReadLine());
    switch(response)
    {
        case 1:
            Console.WriteLine("Onboarding Employee...");
            // Implement onboarding logic here.
            break;
        case 2:
            Console.WriteLine("Searching Employee...");
            // Implement employee search logic here.
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
    int id = int.Parse(Console.ReadLine());

    if(!CheckEmployeeLogin(id))
    {
        Console.WriteLine("Invalid employee ID. Please try again.");
        return;
    }
}


static bool CheckEmployeeLogin( int EmployeeId)
{
    //Check ID to db
    Employee employee = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault();
    if (employee == null)
    {
        return false;
    }
    
     Console.WriteLine($"Welcome {employee.Name}!");
    // Implement clock in, clock out, and hours tracking for the employee.
    return true;
    
}


