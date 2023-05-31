using quick_admin_server_net.Dao;
using quick_admin_server_net.Daos;
using quick_admin_server_net.Enties;

namespace quick_admin_server_net.Services.Impl
{
    public class UserService : BaseService<User>, IUserService
    {
        readonly IUserDao _userDao;
        public UserService(IUserDao userDao): base(userDao) 
        {
            _userDao = userDao;
        }
    }
}
