using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Quick.Admin;
using Quick.Admin.Enums;
using Quick.Admin.Utils;
using quick_admin_server_net.Enties;
using quick_admin_server_net.Services;
using quick_admin_server_net.Services.Impl;
using Serilog;
using SqlSugar;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
string? basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 初始化Serilog
Log.Logger = new LoggerConfiguration()
       .MinimumLevel.Debug()
       .WriteTo.File(Path.Combine("Logs", @"quick-admin-log.txt"), rollingInterval: RollingInterval.Day)
       .CreateLogger();
// 使用注入的方式添加
//builder.Services.AddSingleton(Log.Logger);
#endregion

//引入配置文件
var _config = new ConfigurationBuilder()
                 .SetBasePath(basePath)
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();
// 注入读取配置文件的自定义服务
builder.Services.AddSingleton(new AppSettingUtil(_config));

#region 注入SqlSugar
builder.Services.AddScoped(options =>
{
    return new SqlSugarScope(new List<ConnectionConfig>()
    {
        new ConnectionConfig() { ConfigId = DBEnum.DEFAULT_DB, 
            ConnectionString = DBSettingUtil.GetDBConnection(), 
            DbType = DBSettingUtil.GetDBType(), 
            IsAutoCloseConnection = true 
        }
    });
});
#endregion

#region 使用autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    //builder.RegisterModule<AutofacModuleRegister>();
    Assembly assembly = Assembly.Load(ServiceCore.GetAssemblyName());
/*        builder.RegisterAssemblyTypes(assembly)
               .AsImplementedInterfaces()
               .InstancePerDependency()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);*/
    builder.RegisterAssemblyTypes(assembly)
    .Where(a => (a.Name.EndsWith("Service") || a.Name.EndsWith("Dao")))
    .AsImplementedInterfaces()
               .InstancePerDependency()
               .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
    //Console.WriteLine(assembly.GetName().Name);
    //builder.RegisterType<UserService<User>>().As<IUserService<User>>();
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
