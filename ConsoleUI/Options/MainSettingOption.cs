namespace ConsoleUI.Options;

public class MainSettingOption
{
    public string SubSetting { get; set; }=string.Empty;
    public SubSection SubSection { get; set; } = new();
}
