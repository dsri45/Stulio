using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class PersonalEndeavorsModel
    {
        [PrimaryKey, AutoIncrement]
        public int EndeavorId { get; set; }
        public int StudentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
