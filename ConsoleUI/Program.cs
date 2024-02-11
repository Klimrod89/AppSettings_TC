using Microsoft.Extensions.Configuration;


IConfigurationBuilder builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", false, true);
IConfigurationRoot config = builder.Build();

string mySetting = config["MySettings"]!;
mySetting = config.GetValue<string>("MySettings")!;

Console.WriteLine($"MySetting Value: {mySetting}");

Console.ReadLine();