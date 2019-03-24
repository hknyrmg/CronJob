using CronJob.Common.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CronJob.Data.Entities
{
    public class Demo:EntityBase
    {
        [Required(ErrorMessage = "Name is required")]

        public string DemoName { get; set; }
    }
}
