<Query Kind="Program" />

/*

Deferred or Lazy Operators: 
	Select, SelectMany, Where, Take, Skip, etc.tegory.

Immediate or Greedy Operators: 
	Count, Average, Min, Max, First, Last, ToArray, ToList, etc.


Resource:
https://samwalpole.com/linq-beware-of-deferred-execution

*/
void Main()
{
	var slcNetPresentation = new PresentationInfo("Gary Ray", "gary.ray@gmail.com", "https://");
	slcNetPresentation.Dump("Thank You!");
}

public record PresentationInfo(string name, string email, string githubLink);
