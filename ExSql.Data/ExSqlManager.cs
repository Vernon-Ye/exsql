using ExSql.Data.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExSql.Data
{
    /// <summary>
    /// 扩展SQL命令管理工具
    /// </summary>
    public class ExSqlManager
    {

        public ExSqlManager(IConfiguration config)
        {
            LoadCmds(config);
            LoadViews(config);
            LoadProcs(config);
        }

        #region ExSqlCmds
        /// <summary>
        /// SQL命令脚本
        /// </summary>
        public SortedList<string, ExSqlCmd> ExSqlCmds { get; protected set; } = new SortedList<string, ExSqlCmd>();
        protected void LoadCmds(IConfiguration config)
        {
            foreach (var c in config.GetSection("ExSqlCmds").GetChildren())
            {
                var cmd = new ExSqlCmd();
                cmd.Name = c["Name"];
                cmd.PreSql = c["PreSql"];
                ExSqlCmds[cmd.Name] = cmd;
            }
        }

        public ExSqlCmd GetExSqlCmd(string name)
        {
            return this.ExSqlCmds[name];
        }
        #endregion

        #region ExSqlViews
        /// <summary>
        /// 数据视图脚本
        /// </summary>
        public SortedList<string, ExSqlView> ExSqlViews { get; protected set; } = new SortedList<string, ExSqlView>();
        protected void LoadViews(IConfiguration config)
        {
            if (config["EnableViews"].ToUpper() == "TRUE")
            {
                foreach (var c in config.GetSection("ExSqlViews").GetChildren())
                {
                    var cmd = new ExSqlView();
                    cmd.Name = c["Name"];
                    cmd.PreSql = c["PreSql"];
                    cmd.Entity = c["Entity"];
                    ExSqlViews[cmd.Name] = cmd;
                }
            }
        }

        /// <summary>
        /// 获取视图脚本
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExSqlView GetExSqlView(string name)
        {
            return this.ExSqlViews[name];
        }

        /// <summary>
        /// 初始化数据视图
        /// </summary>
        /// <param name="action"></param>
        public void GenerateViews(Action<ExSqlView> action)
        {
            foreach (var view in ExSqlViews.Values)
            {
                action(view);
            }
        }
        #endregion

        #region ExSqlProcs
        /// <summary>
        /// 存储过程脚本
        /// </summary>
        public SortedList<string, ExSqlProc> ExSqlProcs { get; protected set; } = new SortedList<string, ExSqlProc>();
        protected void LoadProcs(IConfiguration config)
        {
            if (config["EnableProcs"].ToUpper() == "TRUE")
            {
                foreach (var c in config.GetSection("ExSqlProcs").GetChildren())
                {
                    var cmd = new ExSqlProc();
                    cmd.Name = c["Name"];
                    cmd.PreSql = c["PreSql"];
                    ExSqlProcs[cmd.Name] = cmd;
                }
            }
        }

        /// <summary>
        /// 获取存储过程
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ExSqlProc GetExSqlProc(string name)
        {
            return this.ExSqlProcs[name];
        }

        /// <summary>
        /// 初始化存储过程
        /// </summary>
        /// <param name="action"></param>
        public void GenerateProcs(Action<ExSqlProc> action)
        {
            foreach (var proc in ExSqlProcs.Values)
            {
                action(proc);
            }
        }
        #endregion

    }
}
