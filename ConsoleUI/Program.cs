using System.ComponentModel;
using System.Threading.Tasks.Dataflow;
using ConsoleUI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ConsoleUI.Options;



IConfigurationBuilder builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", false, true)
                                .AddJsonFile("appsettings.Development.json", true, true)
                                .AddUserSecrets<Program>();


IConfigurationRoot config = builder.Build();

string mySetting = config["MySettings"]!;
mySetting = config.GetValue<string>("MySettings")!;
mySetting = (string)config.GetValue(typeof(string), "MySettings")!;

string oops = config.GetSection("MainSetting").GetValue<string>("SubSection:SubSubSetting")!;
Console.WriteLine($"Oops: {oops}");

// Reading from an option class using GET
var mainSetting = config.GetSection("MainSetting").Get<MainSettingOption>();
string? getOption = mainSetting?.SubSection.SubSubSetting;

Console.WriteLine($"Get Option: {getOption}");

// Reading from an option class using BIND
MainSettingOption mSetting = new();
config.GetSection("MainSetting").Bind(mSetting);
string?  bindOption=  mSetting?.SubSection.SubSubSetting;
Console.WriteLine($"Bind Option: {bindOption}");


string mySubSetting = config.GetValue<string>("MainSetting:SubSetting")!;

string? mySubSubSetting = config["MainSetting:SubSection:SubSubSetting"];

string? connectionString = config.GetConnectionString("Default");

Console.WriteLine($"MySetting Value: {mySetting}");
Console.WriteLine($"MySubSetting Value: {mySubSetting}");
Console.WriteLine($"MySubSubSetting Value: {mySubSubSetting}");
Console.WriteLine($"ConnectionString Value: {connectionString}");

Console.ReadLine();
