// See https://aka.ms/new-console-template for more information

using System.Globalization;
using ClientLauncher;

using var httpClient = new HttpClient();

var manifestResult = await GitHubResource.GetManifest(httpClient);

manifestResult.Switch(manifest =>
{
    var versionsCount = manifest.Versions.Count;
    var lastVersion = manifest.Versions.LastOrDefault()?.Version.ToString(CultureInfo.CurrentCulture) ?? "unknown";
    Console.WriteLine(
        $"There are {versionsCount} versions.  The latest one is {lastVersion}.");
}, _ =>
{
    Console.WriteLine("Error, unable to get manifest.  Make sure you are connected to the internet.");
});

