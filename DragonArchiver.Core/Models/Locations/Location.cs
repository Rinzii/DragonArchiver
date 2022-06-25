namespace DragonArchiver.Core.Models;

public class Location
{
    public (int x, int y) MapLocation { get; set; }
    public string MapIcon { get; set; }
    public Continent HomeContinent { get; set; }

    public Location((int x, int y) mapLocation, string mapIcon, Continent homeContinent)
    {
        MapLocation = mapLocation;
        MapIcon = mapIcon;
        HomeContinent = homeContinent;
    }
}