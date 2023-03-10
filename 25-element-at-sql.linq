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

// Won't work because the provider returns a DbSet, not IEnumerable compatible
// var lastAlbum = Albums.OrderBy(a => a.AlbumId).ElementAt(^1);

var enumerableAlbums = Albums.OrderBy(a => a.AlbumId).AsEnumerable();

// Note SQL tab - deferred execution, but twice....
var secondAlbum = enumerableAlbums.ElementAt(1);
secondAlbum.Dump();

var penultimateAlbum = enumerableAlbums.ElementAt(^2);
penultimateAlbum.Dump();