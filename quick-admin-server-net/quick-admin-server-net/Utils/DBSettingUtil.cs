using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick.Admin.Utils
{
    public static class DBSettingUtil
    {
        private const string APP_SETTING_DB_CONNECTION = "DBConnection";
        private const string APP_SETTING_DB_CONNECTION_DB_TYPE = "DBType";
        private const string APP_SETTING_DB_CONNECTION_ADDRESS = "Address"; 
        private const string APP_SETTING_DB_CONNECTION_PORT = "Port"; 
        private const string APP_SETTING_DB_CONNECTION_UID = "Uid"; 
        private const string APP_SETTING_DB_CONNECTION_PWD = "Pwd";
        private const string APP_SETTING_DB_CONNECTION_CHARSET = "Charset";
        private const string APP_SETTING_DB_CONNECTION_DATABASE = "Database";


        public static string GetDBConnection()
        {
            //"SugarConnectString": "server=localhost;Database=DBTest;Uid=root;Pwd=root;"
            return new StringBuilder()
                .Append("server=")
                .Append(GetDBAddress())
                .Append(";port=")
                .Append(GetDBPort())
                .Append(";Database=")
                .Append(GetDatabase())
                .Append(";Uid=")
                .Append(GetDBUID())
                .Append(";Pwd=")
                .Append(GetDBPwd())
                .Append(";charset=")
                .Append(GetDBCharset)
                .Append(";")
                .ToString();
        }

        public static DbType GetDBType()
        {
            string dbType = AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_DB_TYPE)
                .ToString()
                );

            switch(dbType.ToLower())
            {
                case "mysql":
                    return DbType.MySql;
                case "sqlServer":
                    return DbType.SqlServer;
                case "sqlite":
                    return DbType.Sqlite;
                case "oracle":
                        return DbType.Oracle;
                case "postgresql":
                        return DbType.PostgreSQL;
                case "dm":
                        return DbType.Dm;
                case "kdbndp":
                        return DbType.Kdbndp;
                case "oscar":
                        return DbType.Oscar;
                case "access":
                        return DbType.Access;
                case "opengauss":
                        return DbType.OpenGauss;
                case "QuestDB":
                        return DbType.QuestDB;
                case "hg":
                        return DbType.HG;
                case "clickhouse":
                        return DbType.ClickHouse;
                case "gbase":
                        return DbType.GBase;
                case "odbc":
                        return DbType.Odbc;
                case "custom":
                        return DbType.Custom;
                default:
                        return DbType.MySql;
            }
        }

        private static string GetDBAddress()
        {
            return AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_ADDRESS)
                .ToString()
                );
        }

        private static string GetDBPort()
        {
            return AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_PORT)
                .ToString()
                );
        }

        private static string GetDBUID()
        {
            return AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_UID)
                .ToString()
                );
        }

        private static string GetDBPwd()
        {
            return AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_PWD)
                .ToString()
                );
        }

        private static string GetDBCharset()
        {
            return AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_CHARSET)
                .ToString()
                );
        }

        private static string GetDatabase()
        {
            return AppSettingUtil.ReadString(new StringBuilder()
                .Append(APP_SETTING_DB_CONNECTION)
                .Append(":")
                .Append(APP_SETTING_DB_CONNECTION_DATABASE)
                .ToString()
                );
        }
    }
}
