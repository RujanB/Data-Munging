// See https://aka.ms/new-console-template for more information
using DataMunging;

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

Console.WriteLine("--------CalculateWeatherSpread-----------");
new Calculate().CalculateWeatherSpread();
Console.WriteLine("--------CalculateSoccerLeagueSmallestDiff-----------");
new Calculate().CalculateSoccerLeagueSmallestDiff();

Console.ReadLine();



