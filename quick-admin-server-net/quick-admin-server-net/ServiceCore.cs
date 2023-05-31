using System.Reflection;

namespace Quick.Admin
{
    public static class ServiceCore
    {
        /// <summary>
        /// 获取程序集名称
        /// </summary>
        /// <returns></returns>
        public static string GetAssemblyName()
        {
            Console.WriteLine(Assembly.GetExecutingAssembly().GetName().Name);
            return Assembly.GetExecutingAssembly().GetName().Name;
        }
    }

}
