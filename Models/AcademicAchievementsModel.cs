using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class AcademicAchievementsModel
    {
        public int StudentID { get; set; }
        public int DateAchived { get; set; }
        public string Award { get; set; }
        public string Class { get; set; }
        public string Picture { get; set; }    
    }
}
