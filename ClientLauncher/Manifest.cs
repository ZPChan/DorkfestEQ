using System.Text.Json;
using System.Text.Json.Serialization;
using OneOf;
using OneOf.Types;

namespace ClientLauncher;

[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
public class Manifest
{
    public List<ClientVersion> Versions { get; } = [];
}