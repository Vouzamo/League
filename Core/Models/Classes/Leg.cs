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
    public class Leg
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Foreign Key(s)
        public Guid FixtureId { get; set; }
        public virtual Fixture Fixture { get; set; }

        // Properties
        public DateTime DateTime { get; set; }
        public Venue Venue { get; set; }

        // Children
        public virtual Participant Home { get; set; }
        public virtual Participant Away { get; set; }

        //public virtual Score Score { get; set; }
    }
}
