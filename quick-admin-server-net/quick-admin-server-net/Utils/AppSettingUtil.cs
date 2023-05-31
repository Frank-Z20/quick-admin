using Microsoft.Extensions.Configuration;

namespace Quick.Admin.Utils
{
    public class AppSettingUtil
    {
        private static IConfiguration? _config;

        public AppSettingUtil(IConfiguration configuration)
        {
            _config = configuration;
        }

        public static string ReadString(params string[] keys)
        {
            try
            {
                if (_config != null && keys.Any())
                {
                    string? str = _config[string.Join(":", keys)];
                    if (!string.IsNullOrEmpty(str))
                    {
                        return str;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

        public static string ReadString(string key)
        {
            try
            {
                if (_config != null && !string.IsNullOrEmpty(key))
                {
                    string? str = _config[key];
                    if (!string.IsNullOrEmpty(str))
                    {
                        return str;
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }

        public static T ReadObject<T>(params string[] keys) where T : class, new()
        {
            T data = new();
            try
            {
                if (_config != null && keys.Any())
                {
                    _config.Bind(string.Join(":", keys), data);
                }
            }
            catch
            {
                return data;
            }
            return data;
        }

        public static List<T> ReadList<T>(params string[] keys) where T : class { 



            List<T> list = new();
            try
            {
                if (_config != null && keys.Any())
                {
                    _config.Bind(string.Join(":", keys), list);
                }
            }
            catch
            {
                return list;
            }
            return list;
        }
    }
}
