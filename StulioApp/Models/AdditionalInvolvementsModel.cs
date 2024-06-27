using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class AdditionalInvolvementsModel
    {
        [PrimaryKey, AutoIncrement]
        public int InvolvementId { get; set; }
        public int StudentID { get; set; }
        public string ActivityName { get; set; }
        public string ParticpatedYears { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Achivements { get; set; }


    }
}
