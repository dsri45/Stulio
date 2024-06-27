using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class WorkExperienceModel
    {
        [PrimaryKey, AutoIncrement]
        public int WorkId { get; set; }
        public int StudentID { get; set; }
        public string Role { get; set; }
        public string Establishment { get; set; }
        public string ParticpatedYears { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
