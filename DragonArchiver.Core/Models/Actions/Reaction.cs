using System.Text.Json.Serialization;

namespace DragonArchiver.Core.Models
{
    public abstract class Reaction
    {
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("desc")] public string? Desc { get; set; }
        [JsonPropertyName("attack_bonus")] public int AttackBonus { get; set; }
    }
}
