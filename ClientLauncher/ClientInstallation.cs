using Microsoft.Win32;
using OneOf.Types;

namespace ClientLauncher;

public class ClientInstallation
{
    private decimal? _version;
    private string? _installLocation;

    private const string BaseKey =
        @"Software\Microsoft\Windows\CurrentVersion\Uninstall\{35D0B5BD-4FF8-4277-AB0A-2EA97464B7FE}_is1";

    private const string InstallLocationValueName = "InstallLocation";
    private const string DisplayVersionValueName = "DisplayVersion";

    public ClientInstallation()
    {
        var regKey = GetBaseKey();

        _installLocation = (string?) regKey?.GetValue(InstallLocationValueName, null);
        _version = (string?)regKey?.GetValue(DisplayVersionValueName, null) is { } versionString
            ? decimal.TryParse(versionString, out var version)
                ? version
                : null
            : null;
    }

    private RegistryKey? GetBaseKey() => Registry.CurrentUser.OpenSubKey(BaseKey);

    public decimal? Version
    {
        get => _version;
        set
        {
            _version = value;
        }
    }

    public string? InstallLocation
    {
        get => _installLocation;
        set => _installLocation = value;
    }
}