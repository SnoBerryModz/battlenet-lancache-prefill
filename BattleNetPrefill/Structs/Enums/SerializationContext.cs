namespace BattleNetPrefill.Structs.Enums
{
    //TODO Possibly change this to metadata
    [JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default)]
    [JsonSerializable(typeof(List<Request>))]
    [JsonSerializable(typeof(ConcurrentDictionary<string, long>))]
    internal partial class SerializationContext : JsonSerializerContext
    {
    }
}
