namespace quick_admin_server_net.Services
{
    public interface IBaseService<T>
    {
        T GetById(long id);
    }
}
