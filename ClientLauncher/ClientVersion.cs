using System.Text.Json.Serialization;

namespace ClientLauncher;

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public class ClientVersion
{
    public decimal Version { get; set; }
    public List<ClientFile> Files { get; } = [];
}