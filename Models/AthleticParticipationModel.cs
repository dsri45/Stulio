using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class AthleticParticipationModel
    {
        [PrimaryKey, AutoIncrement]
        public int AthleticId { get; set; }
        public int StudentID { get; set; }
        public string Sport { get; set; }
        public string Role { get; set; }
        public string ParticpatedYears { get; set; }
        public string Achivements { get; set; }
    }
}
