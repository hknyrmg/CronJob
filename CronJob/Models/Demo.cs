using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CronJob.Models
{
    public class Demo:Entitybase
    {
        public string DemoName { get; set; }
    }
}
