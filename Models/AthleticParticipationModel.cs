using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class AthleticParticipationModel
    {
        public int AcademicId { get; set; }
        public int StudentID { get; set; }
        public string Sport { get; set; }
        public string Role { get; set; }
        public string ParticpatedYears { get; set; }
        public string Achivements { get; set; }
    }
}
