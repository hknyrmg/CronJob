using System;
using System.Collections.Generic;
using System.Text;

namespace CronJob.Common.Data
{
   public class EntityBase
    {
        public int Id { get; set; }
        private DateTime createdDate;

        public DateTime? CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value ?? DateTime.UtcNow; }
        }

    }
}
