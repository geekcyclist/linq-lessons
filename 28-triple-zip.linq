<Query Kind="Statements" />

int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
string[] temps = { "Coldest", "Cold", "Moderate", "Moderate", "Warm", "Hot", "Hot", "Hotest", "Warm", "Moderate", "Moderate", "Cold" };

var doubleZip = numbers.Zip(months);
doubleZip.Dump();

//var chained = numbers.Zip(months).Zip(temps);
//chained.Dump();

//var trippleZipped = numbers.Zip(months, temps);
//trippleZipped.Dump();
