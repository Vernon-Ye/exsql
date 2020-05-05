using System;
using System.Collections.Generic;
using System.Text;

namespace ExSql.Data.Configuration
{
    /// <summary>
    /// SQL命令脚本
    /// </summary>
    public class ExSqlCmd
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
