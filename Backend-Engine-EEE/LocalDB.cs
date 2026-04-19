
public static class LocalDB
{
    //For simplicity this will be an in memory storage

    public static List<Company> Companies { get; set; } = new List<Company>();
    public static List<Employee> Employees { get; set; } = new List<Employee>();
}