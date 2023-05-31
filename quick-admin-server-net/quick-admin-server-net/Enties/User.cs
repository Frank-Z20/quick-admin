using SqlSugar;

namespace quick_admin_server_net.Enties
{
    [SugarTable("user")]
    public class User
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
