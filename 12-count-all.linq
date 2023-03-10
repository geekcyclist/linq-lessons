<Query Kind="Program" />

void Main()
{
	var employees = new EmployeeRepo().GetEmployees();
	
	// Incorrect: Optimized, but may do a full iteration of the enumerable
	if (employees.Count(e => e.LastName == "Jones") > 0)
	{
		Console.WriteLine("Found a Jones");
	}

	// Correct: Don't really need the full count? Short-circut on the first found
	//if (employees.Any(e => e.LastName == "Jones"))
	//{
	//	Console.WriteLine("Found a Jones");
	//}
	
	// Need to know if all values are the same? use Enumerable.All()
	//	Short circuts on the first different value
	//var namesStartWithJ = employees.Where(e => e.FirstName.StartsWith("J"));
	//namesStartWithJ.Dump();
	//
	//bool allEngineering = namesStartWithJ.All(e => e.Department == "Engineering");
	//allEngineering.Dump("All Engineering?");
	//	
	//bool containsN = namesStartWithJ.All(e => e.FirstName.Concat(e.LastName).Contains('n'));
	//containsN.Dump("Contains an 'n'");
	
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
}