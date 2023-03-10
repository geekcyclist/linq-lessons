<Query Kind="Program" />

void Main()
{

	var repo = new EmployeeRepo();
	
	//returns null object (default for employee)
	var nullEmployee = repo.Employees().FirstOrDefault(e => e.Id == 8);
	nullEmployee.Dump();

	//returns null object (default for employee)
	var singleEmployee = repo.Employees().FirstOrDefault(e => e.Id == 8);
	singleEmployee.Dump();

	//returns exception if multiple
	//var singleEmployee = repo.Employees().SingleOrDefault(e => e.FirstName == "David");
	//singleEmployee.Dump();

	//Returning default if not found...
	// Does NOT eliminate the need to do any checking...
	//var defaultEmployee = repo.Employees().FirstOrDefault(e => e.Id == 8, new Employee(0, "", "", ""));
	//defaultEmployee.Dump();

	//still returns exception if multiple values returned!
	//var singleEmployee = repo.Employees().SingleOrDefault(e => e.FirstName == "David", new Employee(0, "", "", ""));
	//singleEmployee.Dump();

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
