using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class AcademicAchievementsModel
    {
        [PrimaryKey, AutoIncrement]
        public int AcademicId { get; set; }
        public int StudentID { get; set; }
        public DateTime DateAchived { get; set; }
        public string Award { get; set; }
        public string Class { get; set; }
        public string Description { get; set; }

    }
}
