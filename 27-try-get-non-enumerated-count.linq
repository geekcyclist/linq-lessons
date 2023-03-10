<Query Kind="Statements">
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
</Query>

/*
The typical way to count the number of elements on an IEnumerable<T> is through the Count() method. 
This Count() method will already do some optimizations. 
It will first check if the IEnumerable<T> can be cast to an ICollection<T>. 
If that is the case, the count can be returned immediately and we don’t need to iterate over all the elements. 
If not, Count() will have to loop through all the elements, 
which can be an expensive operation and be a performance issue, especially when the list of elements is long.

If you want to avoid this performance penalty, you can use the TryGetNonEnumeratedCount() method.  
It will first check if it is ‘safe’ to do a count in a fast way, if not it will return nothing.
*/



IEnumerable<int> array = Enumerable.Range(0, 100);
var canGetCount = array.TryGetNonEnumeratedCount(out int count);

Console.WriteLine($"Can count ? = {canGetCount}");
Console.WriteLine($"Number of elements = {count}");

var albums = Albums;

var canGetAlbumCount = albums.TryGetNonEnumeratedCount(out int albumCount);
Console.WriteLine($"Can count albums? = {canGetAlbumCount}");
Console.WriteLine($"Number of elements = {albumCount}");
