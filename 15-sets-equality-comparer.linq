<Query Kind="Program">
  <Namespace>System.Diagnostics.CodeAnalysis</Namespace>
</Query>

void Main()
{
	// Primative types have built in equality comparison
	List<int> numbers1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
	List<int> numbers2 = new List<int>() { 1, 2, 3, 11, 12, 13, 14, 15, 16, 17, 18 };
	var result = numbers1.Union(numbers2);
	result.Dump();

	var repo = new EmployeeRepo();
	var employees = repo.GetEmployees();
	
	// Incorrect for complex objects with possible duplicates
	//var allEmployees = employees.Union(repo.GetRecentEmployees());
	//allEmployees.Dump();
	
	
	// Using custom comparer - NOTE! Uncomment the Comparer at the bottom of this file...
	//var allEmployeesComparer = employees.Union(repo.RecentEmployees(), new EmployeeComparer());
	//allEmployessallEmployeesComparer.Dump();
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
			new Employee( 41, "Martin", "Miller", "Engineering"),
			new Employee( 42, "Joshua", "Anderson", "Engineering"),
			new Employee( 51, "Steven", "Boyer", "Administration"),
			new Employee( 52, "DJ", "Willis", "Sales"),
			new Employee( 53, "David", "Smith", "Engineering"),
		};
	}
}

//public class EmployeeComparer : IEqualityComparer<Employee>
//{
//	public bool Equals(Employee left, Employee right)
//	{
//		bool sameId = left.Id == right.Id;
//		
//		bool sameName = left.FirstName.ToLowerInvariant() == right.FirstName.ToLowerInvariant() && 
//			left.LastName.ToLowerInvariant() == right.LastName.ToLowerInvariant();
//		
//		return sameId && sameName;
//	}
//
//	public int GetHashCode(Employee obj)
//	{
//		 return obj.ToString().ToLower().GetHashCode();
//	}
//}