using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    public class Fixture
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Foreign Key(s)
        public Guid DivisionId { get; set; }
        public virtual Division Division { get; set; }

        // Properties
        public virtual Participant Home { get; set; }
        public virtual Participant Away { get; set; }

        // Children
        public virtual ICollection<Leg> Legs { get; set; }

        //public Participant Winner { get; set; }
    }
}
