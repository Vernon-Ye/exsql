using System;
using System.Collections.Generic;
using System.Text;

namespace ExSql.Data.Configuration
{
    /// <summary>
    /// 存储过程脚本
    /// </summary>
    public class ExSqlProc
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string PreSql { get; set; }
    }
}
