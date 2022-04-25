using System;
using System.Collections.Generic;
using System.Text;

namespace CAD.Base.DataAccess.Data.Models
{
    public class Log : EntityBase
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
