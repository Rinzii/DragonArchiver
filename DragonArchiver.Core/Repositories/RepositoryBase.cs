using DragonArchiver.Core.DB;

namespace DragonArchiver.Core.Repositories;

public class RepositoryBase<T>
{
    #region Properties
    protected DragonArchiverDbContext DragonArchiverDbContext { get; }
    #endregion
        
    #region Constructor
    public RepositoryBase(DragonArchiverDbContext dragonArchiverDbContext)
    {
        DragonArchiverDbContext = dragonArchiverDbContext;
    }
    #endregion

    public void Update(T item)
    {
        _ = DragonArchiverDbContext.Update(item!);
    }
}