<Query Kind="Program" />

void Main()
{
	var repo = new EmployeeRepo();
	var employees = repo.GetEmployees();
	
	// Using custom comparer - this works
	var allEmployess = employees.Union(repo.GetRecentEmployees(), new EmployeeComparer());
	allEmployess.Dump("Union with Comparer");
	
	// the [set]By extensions takes a keySelector. The keySelector is used as the comparative discriminator of the source type.
	// Using unionBy and comparing by id
	var unionBy = employees.UnionBy(repo.GetRecentEmployees(), e => e.Id);
	unionBy.Dump("UnionBy");
	
	// similar extensions

	// IntersectBy: get all from the first set where the comparison intersects the second set
	var intersectBy = employees.IntersectBy(repo.GetRecentEmployees(), emp => emp);
	intersectBy.Dump("IntersectBy");
	
	// DistinctBy - differentiate based on the keySelector and return the first instance of each type
	var distinctBy = employees.DistinctBy(e => e.Department);
	distinctBy.Dump("DistinctBy");
	

	// ExceptBy: get all from the first set excluding those whose key is in the second set
	var exceptBy = employees.ExceptBy(repo.GetRecentEmployees().Select(r => r.Id ), e => e.Id);
	exceptBy.Dump("ExceptBy");

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

public class EmployeeComparer : IEqualityComparer<Employee>
{
	public bool Equals(Employee left, Employee right)
	{
		bool sameId = left.Id == right.Id;
		bool sameName = left.FirstName.ToLowerInvariant() == right.FirstName.ToLowerInvariant() &&
			left.LastName.ToLowerInvariant() == right.LastName.ToLowerInvariant();

		return sameId && sameName;
	}

	public int GetHashCode(Employee obj)
	{
		return obj.ToString().ToLower().GetHashCode();
	}
}