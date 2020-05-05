using ExSql.Data;
using ExSql.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ExSql.Samples
{
    public class SampleContext : ExSqlContext
    {
        public SampleContext(ExSqlManager exsql, DbContextOptions options) : base(exsql, options)
        {

        }

        public DbSet<SysUser> SysUser { get; set; }
    }

    [Table("sys_user")]
    public class SysUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LoginName { get; set; }
        [Required]
        [MaxLength(500)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        public int Status { get; set; } = 1;

        [MaxLength(500)]
        public string Remark { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;

        public DateTime UpdateTime { get; set; }

    }

    public class ViewUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
    }
}
