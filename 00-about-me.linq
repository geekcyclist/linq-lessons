<Query Kind="Program" />

void Main()
{
	var slcNetPresentation = new PresentationInfo("Gary Ray", "gary.ray@gmail.com", "https://");
	slcNetPresentation.Dump("About Me");
}

public record PresentationInfo(string name, string email, string githubLink);