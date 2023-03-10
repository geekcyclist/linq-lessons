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

var albums = Albums.OrderBy(a => a.AlbumId);
var chunkedAlbums = albums.AsEnumerable().Chunk(25);

foreach (var chunk in chunkedAlbums)
{
	chunk.Count().Dump();
}

// Db Providers require casting to an enumerable type
//  so if you have large data sets you may need to still
//  look at other chunking methods.
// Consider a proc with OFFSET...FETCH https://www.sqlservertutorial.net/sql-server-basics/sql-server-offset-fetch/