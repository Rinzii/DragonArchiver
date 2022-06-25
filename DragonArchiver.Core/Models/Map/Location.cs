namespace DragonArchiver.Core.Models;

public class Location
{
    public (int x, int y) MapLocation { get; set; }
    public string MapIcon { get; set; }
    public Continent HomeContinent { get; set; }
}