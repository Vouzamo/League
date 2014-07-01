using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    [Table("Individual")]
    public partial class Individual : Participant
    {
        public virtual ICollection<Team> Teams { get; set; } 

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Handicap { get; set; }
    }
}
