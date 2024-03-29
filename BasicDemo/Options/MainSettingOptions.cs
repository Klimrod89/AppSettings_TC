namespace BasicDemo;

public class MainSettingOptions
{
    public string SubSetting { get; set; }
    public SubSectionOptions SubSection { get; set; } = new();
}
