using SqlSugar;
using System.Data;

namespace quick_admin_server_net.Dao.Impl
{
    public class BaseDao<T> : SimpleClient<T>, IBaseDao<T> where T : class, new()
    {
        public SqlSugarScope _sqlSugar;
        public SqlSugarScopeProvider _sqlSugarProvider;
        public BaseDao(SqlSugarScope sqlSugar)
        {
            _sqlSugar = sqlSugar;
            _sqlSugarProvider = sqlSugar.GetConnectionScopeWithAttr<T>();
        }
       // private ISqlSugarClient _sqlSugar => base.Context;
        /*public BaseDao(ISqlSugarClient context) : base(context)//注意这里要有默认值等于null
        {
            base.Context = context;
        }*/

        public T GetById(long id)
        {
            return _sqlSugar.Queryable<T>().InSingle(id);
        }

        public Task<T> GetByIdAsync(long id)
        {
            return _sqlSugar.Queryable<T>().InSingleAsync(id);
        }
    }
}
