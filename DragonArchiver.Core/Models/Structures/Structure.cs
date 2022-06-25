
namespace DragonArchiver.Core.Models;

public abstract class Structure
{
    protected Structure(Location location)
    {
        Location = location;
    }

    public Location Location { get; set; }
    
}

