using System.ComponentModel;
using Microsoft.Extensions.Configuration;



IConfigurationBuilder builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory() + "/ConsoleUI")
                                .AddJsonFile("appsettings.json", false, true)
                                .AddJsonFile("appsettings.Development.json", true, true)
                                .AddUserSecrets<Program>();

IConfigurationRoot config = builder.Build();

string mySetting = config["MySettings"]!;
mySetting = config.GetValue<string>("MySettings")!;
mySetting = (string)config.GetValue(typeof(string), "MySettings")!;

string mySubSetting = config.GetValue<string>("MainSetting:SubSetting")!;

string? mySubSubSetting = config["MainSetting:SubSection:SubSubSetting"];

string? connectionString = config.GetConnectionString("Default");

Console.WriteLine($"MySetting Value: {mySetting}");
Console.WriteLine($"MySubSetting Value: {mySubSetting}");
Console.WriteLine($"MySubSubSetting Value: {mySubSubSetting}");
Console.WriteLine($"ConnectionString Value: {connectionString}");

Console.ReadLine();
