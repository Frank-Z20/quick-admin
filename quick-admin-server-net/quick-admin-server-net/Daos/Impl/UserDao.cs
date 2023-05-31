using quick_admin_server_net.Dao.Impl;
using quick_admin_server_net.Enties;
using SqlSugar;

namespace quick_admin_server_net.Daos.Impl
{
    public class UserDao : BaseDao<User>, IUserDao
    {
        /*public UserDao(ISqlSugarClient context) : base(context)
        {
        }*/
        public UserDao(SqlSugarScope sqlSugar) : base(sqlSugar)
        {

        }
    }
}
