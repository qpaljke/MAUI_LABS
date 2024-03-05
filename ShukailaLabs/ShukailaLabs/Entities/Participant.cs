using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShukailaLabs.Entities
{
    [SQLite.Table("Participant")]
    public class Participant
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int ParticipantId {  get; set; }
        public string ParticipantName { get; set; }
        public decimal ParticipantContractCost {  get; set; }
        [Indexed]
        public int TeamId {  get; set; }   
    }
}
