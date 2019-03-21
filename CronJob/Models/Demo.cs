using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CronJob.Models
{
    public class Demo
    {
        [Key]
        public int DemoId { get; set; }
        public string DemoName { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
