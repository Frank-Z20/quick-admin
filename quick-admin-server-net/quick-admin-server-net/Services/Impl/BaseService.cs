using quick_admin_server_net.Dao;
using quick_admin_server_net.Dao.Impl;

namespace quick_admin_server_net.Services.Impl
{
    public class BaseService<T> : IBaseService<T>
    {
        private readonly IBaseDao<T> _baseDao;

        public BaseService(IBaseDao<T> baseDao)
        {
            _baseDao = baseDao;
        }

        public T GetById(long id)
        {
            return _baseDao.GetById(id);
        }
    }
}
