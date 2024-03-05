using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukailaLabs.Entities
{
    [SQLite.Table("Team")]
    public class Team
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int TeamId { get; set; }
        public string TeamName {  get; set; }
    }
}
