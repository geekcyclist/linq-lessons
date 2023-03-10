<Query Kind="Program">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c12aaaaa</ID>
    <NamingService>2</NamingService>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\ChinookDemoDb.sqlite</AttachFileName>
    <DisplayName>Demo database (SQLite)</DisplayName>
    <DriverData>
      <PreserveNumeric1>true</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
      <MapSQLiteDateTimes>true</MapSQLiteDateTimes>
      <MapSQLiteBooleans>true</MapSQLiteBooleans>
    </DriverData>
  </Connection>
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
</Query>

#load "BenchmarkDotNet"

void Main()
{
	//Chinook sample database - included with LINQPad
	// https://github.com/lerocha/chinook-database

	var lastTitleWithAChained = Albums
		.Where(a => a.Title.StartsWith("A"))
		.OrderBy(a => a.Title)
		.Last();
	lastTitleWithAChained.Dump();
	
	var lastTitleWithAUnChained = Albums
		.OrderBy(a => a.Title)
		.Last(a => a.Title.StartsWith("A"));
	lastTitleWithAChained.Dump();

	//RunBenchmark(); return;
}

[Benchmark]
public void BenchmarkWithWhere() 
{
	var lastTitleWithAChained = Albums
	.Where(a => a.Title.StartsWith("A"))
	.OrderBy(a => a.Title)
	.Last();
	
	lastTitleWithAChained.ToString();
}

[Benchmark]
public void BenchmarkWithoutWhere()
{
	var lastTitleWithAUnChained = Albums
		.OrderBy(a => a.Title)
		.Last(a => a.Title.StartsWith("A"));
	
	lastTitleWithAUnChained.ToString();
}

//[GlobalSetup]
//public void BenchmarkSetup()
//{
//	// optional setup code...
//}