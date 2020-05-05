using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExSql.Data.EFCore
{
    public class ExSqlContext : DbContext
    {
        protected ExSqlManager _ExSqlManager;

        public ExSqlContext(ExSqlManager exsql)
        {
            _ExSqlManager = exsql;
        }

        public ExSqlContext(ExSqlManager exsql, DbContextOptions options) : base(options)
        {
            _ExSqlManager = exsql;
        }

        /// <summary>
        /// 通过ExSQL命令方式取得相应查询对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public IQueryable<T> ExSqlCmdForQuery<T>(string name, params object[] parameters)
            where T : class
        {
            var cmd = _ExSqlManager.GetExSqlCmd(name);
            return this.Set<T>().FromSqlRaw(cmd.PreSql, parameters).AsNoTracking();
        }

        /// <summary>
        /// 通过ExSQL命令方式获取指定数据列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">命令名称</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public List<T> ExSqlCmdForList<T>(string name, params object[] parameters)
            where T : class
        {
            var cmd = _ExSqlManager.GetExSqlCmd(name);
            return this.Set<T>().FromSqlRaw(cmd.PreSql, parameters).AsNoTracking().ToList();
        }

        /// <summary>
        /// 通过ExSQL命令方式获取单条指定数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">命令名称</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T ExSqlCmdForFirst<T>(string name, params object[] parameters)
            where T : class
        {
            var cmd = _ExSqlManager.GetExSqlCmd(name);
            return this.Set<T>().FromSqlRaw(cmd.PreSql, parameters).AsNoTracking().FirstOrDefault();
        }

        /// <summary>
        /// 通过ExSQL命令方式执行脚本
        /// </summary>
        /// <param name="name">命令名称</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExSqlCmdForExec(string name, params object[] parameters)
        {
            var cmd = _ExSqlManager.GetExSqlCmd(name);
            return this.Database.ExecuteSqlRaw(cmd.PreSql, parameters);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //实体视图映射
            foreach (var view in _ExSqlManager.ExSqlViews.Values)
            {
                modelBuilder.Entity(view.Entity).ToView(view.Name);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
