using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;

namespace Core.Models.Classes
{
    public abstract class Participant
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }
        public virtual ICollection<Fixture> Fixtures { get; set; } 

        public string Name { get; set; }
        public Participation Participation { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
