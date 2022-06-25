using System.Text.Json.Serialization;

namespace DragonArchiver.Core.Models;

public abstract class LegendaryAction
{
    [JsonPropertyName("name")] public string? Name { get; set; }
    [JsonPropertyName("desc")] public string? Desc { get; set; }
    [JsonPropertyName("attack_bonus")] public int AttackBonus { get; set; }
    [JsonPropertyName("damage_dice")] public string? DamageDice { get; set; }
}