<Query Kind="Program" />

void Main()
{
	ExceptionalLogin("asmith@example.com");
	ExceptionalLogin("gray@example.com");

	//FlowLogin("asmith@example.com");
	//FlowLogin("gray@example.com");
}

public void ExceptionalLogin(string login)
{
	var repo = new EmployeeRepo();

	try
	{
		var employee = repo.GetEmployees().First(e => e.Login == login);
		employee.Dump("Process a login...");
	}
	catch (Exception ex)
	{
		Console.WriteLine($"No employee found for {login}...is this really 'exceptional' or is it expected?");
	}
}

public void FlowLogin(string login)
{
	var repo = new EmployeeRepo();
	
	// Recommendation - Do NOT use exceptions for flow control...
	
	var emp = repo.GetEmployees().FirstOrDefault(e => e.Login == login);
	if (emp is not null)
	{
		emp.Dump("Process a login...");
	}
	else
	{
		Console.WriteLine($"No employee found for {login}...log an invalid login attempt");
	}
}


public record Employee(int Id, string FirstName, string LastName, string Department, string Login);

public class EmployeeRepo
{

	public IEnumerable<Employee> GetEmployees()
	{
		return new List<Employee>(){
			new Employee( 1, "Adam", "Smith", "Administration", "asmith@example.com"),
			new Employee( 2, "David", "Jones", "Sales", "djones@example.com"),
			new Employee( 3, "David", "Lee", "Engineering", "dlee@example.com"),
			new Employee( 6, "Milton", "Lewis", "Sales", "mlewis@example.com"),
			new Employee( 7, "Alison", "Jones", "Engineering", "ajones@example.com"),
			new Employee( 11, "Adam", "Wilson", "Engineering", "awilson@example.com"),
			new Employee( 12, "Susan", "Friedman", "Administration", "sfriedman@example.com"),
			new Employee( 22, "Jenn", "Smith", "Engineering", "jsmith@example.com"),
			new Employee( 23, "Justin", "Bacher", "Administration", "jbacher@example.com"),
			new Employee( 24, "Amanda", "Newman", "Engineering", "anewman@example.com"),
			new Employee( 37, "Paul", "Young", "Sales", "pyoung@example.com"),
			new Employee( 39, "Brenda", "Simpson", "Accounting", "bsimpson@example.com"),
			new Employee( 40, "Alex", "Lewis", "Legal", "alewis@example.com"),
			new Employee( 41, "Martin", "Miller", "Engineering", "mmiller@example.com"),
			new Employee( 42, "Joshua", "Anderson", "Engineering", "janderson@example.com"),
		};
	}
}
