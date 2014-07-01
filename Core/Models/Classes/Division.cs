using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    public class Division
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Foreign Key(s)
        public Guid SeasonId { get; set; }
        public virtual Season Season { get; set; }

        // Properties
        [Required]
        public string Name { get; set; }
        public Sport Sport { get; set; }
        public CompetitionFormat CompetitionFormat { get; set; }
        public Participation ParticipationType { get; set; }
        
        // Children
        public virtual ICollection<Fixture> Fixtures { get; set; }
        public virtual ICollection<Participant> Partipants { get; set; }

        //public ScoreSystem ScoreSystem { get; set; }
    }
}
