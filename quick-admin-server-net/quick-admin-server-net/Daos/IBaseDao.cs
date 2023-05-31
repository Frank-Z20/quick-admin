namespace quick_admin_server_net.Dao
{
    public interface IBaseDao<T>
    {
        T GetById(long id);

        Task<T> GetByIdAsync(long id);
    }
}
