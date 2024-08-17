using System.Text.Json;
using OneOf;
using OneOf.Types;

namespace ClientLauncher;

public class Manifest
{
    public List<ClientVersion> Versions { get; } = [];
}