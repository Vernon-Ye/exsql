using System;
using System.Collections.Generic;
using System.Text;

namespace ExSql.Data.Configuration
{
    /// <summary>
    /// 数据视图脚本
    /// </summary>
    public class ExSqlView
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string PreSql { get; set; }

        /// <summary>
        /// 实体
        /// </summary>
        public string Entity { get; set; }
    }
}
