// See https://aka.ms/new-console-template for more information

using System.Globalization;
using ClientLauncher;

using var httpClient = new HttpClient();

var manifestResult = await GitHubResource.GetManifest(httpClient);

if (manifestResult.IsT1)
{
    Console.WriteLine("Error, unable to get manifest.  Make sure you are connected to the internet.");
    return;
}

var manifest = manifestResult.AsT0;

var latestVersion = manifest.Versions.LastOrDefault()?.Version;

if (latestVersion is null)
{
    Console.WriteLine("Unable to determine the current online version of DorkfestEQ.  Aborting.");
    return;
}




