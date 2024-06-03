using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stulio.Models
{
    public class ClassesModel
    {
        [PrimaryKey, AutoIncrement]
        public int ClassId { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string ClassYear { get; set; }
        public string Grade { get; set; }
    

    }
}
