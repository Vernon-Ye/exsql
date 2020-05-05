using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExSql.Data
{
    public static class ServiceCollectionExtentions
    {
        /// <summary>
        /// 附加拓展SQL命令支持
        /// </summary>
        /// <param name="services"></param>
        /// <param name="json"></param>
        public static void AddExSql(this IServiceCollection services,string json= "exsql.data.json")
        {
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile(json).Build();
            var manager = new ExSqlManager(config);
            services.AddSingleton(manager);
        }
    }
}
