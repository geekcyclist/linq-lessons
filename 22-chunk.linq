<Query Kind="Program" />

void Main()
{
	/* OLD Methods - Create your own extension using groupby or skip/take like
		public static IEnumerable<IEnumerable<T>> CustomChunks<T>(this IEnumerable<T> values, int chunkSize)
	    {
	        while (values.Any())
	        {
	            yield return values.Take(chunkSize).ToList();
	            values = values.Skip(chunkSize).ToList();
	        }
	    }
		
		for discussion see 
			Question https://stackoverflow.com/q/419019/76874 and in particular
			Answer https://stackoverflow.com/a/10425490/76874
	*/


	var repo = new EmployeeRepo();
	var chunks = repo.Employees().Chunk(5);
	chunks.Dump();
}

public class Employee
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Department { get; set; }

	public Employee(int id, string firstName, string lastName, string department)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		Department = department;
	}
}

public class EmployeeRepo
{

	public IEnumerable<Employee> Employees()
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
