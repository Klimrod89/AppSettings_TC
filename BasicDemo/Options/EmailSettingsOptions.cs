namespace BasicDemo;

public class EmailSettingsOptions
{
    public bool EnableEmailSystem { get; set; }
    public int EmailTimeOutInSeconds { get; set; }
    public List<string> EmailServers { get; set; } = new();
}
