using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class CommunityServiceModel
    {
        public int AcademicId { get; set; }
        public int StudentID { get; set; }
        public string ServiceName { get; set; }
        public string ParticpatedYears { get; set; }
        public string VoulnteeredHours { get; set; }
        public string Description { get; set; }
    }
}
