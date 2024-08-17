using System.Net;
using System.Text.Json;
using OneOf;
using OneOf.Types;

namespace ClientLauncher;

public static class GitHubResource
{
    private const string GithubUpdateResources = "https://raw.githubusercontent.com/ZPChan/DorkfestEQ/main/ClientUpdateResources/";
    private const string ManifestFileName = "_manifest.json";

    public static string GetUrl(string fileName) => $"{GithubUpdateResources}{fileName}";

    public static async Task<OneOf<Stream, Error>> GetFileStream(string fileName, HttpClient httpClient)
    {
        try
        {
            var response = await httpClient.GetAsync(GitHubResource.GetUrl(fileName));

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStreamAsync();

            return new Error();
        }
        catch (Exception)
        {
            return new Error();
        }
    }
    public static async Task<OneOf<Manifest, Error>> GetManifest(HttpClient httpClient)
    {
        try
        {
            var result = await GetFileStream(ManifestFileName, httpClient);
            if (result.IsT1) return result.AsT1;

            var stream = result.AsT0;
            
            var manifest = await JsonSerializer.DeserializeAsync<Manifest>(stream);
            if (manifest is null) return new Error();
            
            return manifest;
        }
        catch (Exception)
        {
            return new Error();
        }
    }
}