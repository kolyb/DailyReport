using System;
using System.Collections.Generic;
using System.Text;

namespace DailyReport.DataAccess.Models
{
    public class WorkLocation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AdressWorkLocation { get; set; }

        public int? Rage { get; set; }
    }
}
