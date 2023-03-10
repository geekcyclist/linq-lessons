<Query Kind="Program" />

void Main()
{
	var repo = new EmployeeRepo();
	var employees = new EmployeeRepo().GetEmployees();
	
	// Incorrect - Union, Intersect, Except, Distinct return new sets
	//  and do NOT modify the existing set like AddRange()
	employees.Union(repo.GetRecentEmployees());
	employees.Dump("Unioned set 'disappears'");
	
	//Correct Union - Preferred becasue it leaves original collections intact
	//var allEmployees = employees.Union(repo.GetRecentEmployees());
	//allEmployees.Dump("New variable holds unioned set without cast");
	
	//Works, but mutates the collection.
	//var employeeList = employees.ToList();
	//employeeList.AddRange(repo.GetRecentEmployees().ToList());
	//employeeList.Dump("Combined with cast and AddRange()");
}

public record Employee(int Id, string FirstName, string LastName, string Department);

public class EmployeeRepo
{
	public IEnumerable<Employee> GetEmployees()
	{
		return new List<Employee>(){
			new Employee( 1, "Adam", "Smith", "Administration"),
			new Employee( 2, "David", "Jones", "Sales"),
			new Employee( 3, "David", "Lee", "Engineering"),
			new Employee( 6, "Milton", "Lewis", "Sales"),
			new Employee( 7, "Alison", "Jones", "Engineering"),
			new Employee( 11, "Adam", "Wilson", "Engineering"),
			new Employee( 12, "Susan", "Friedman", "Administration"),
			new Employee( 22, "Jenn", "Smith", "Engineering"),
			new Employee( 23, "Justin", "Bacher", "Administration"),
			new Employee( 24, "Amanda", "Newman", "Engineering"),
			new Employee( 37, "Paul", "Young", "Sales"),
			new Employee( 39, "Brenda", "Simpson", "Accounting"),
			new Employee( 40, "Alex", "Lewis", "Legal"),
			new Employee( 41, "Martin", "Miller", "Engineering"),
			new Employee( 42, "Joshua", "Anderson", "Engineering"),
		};
	}

	public IEnumerable<Employee> GetRecentEmployees()
	{
		return new List<Employee>(){
			new Employee( 51, "Steven", "Boyer", "Administration"),
			new Employee( 52, "DJ", "Willis", "Sales"),
			new Employee( 53, "David", "Smith", "Engineering"),
		};
	}
}
