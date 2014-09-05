using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid VenueId { get; set; }
        public virtual Venue Venue { get; set; }
        public Guid HomeId { get; set; }
        public virtual Participant Home { get; set; }
        public Guid AwayId { get; set; }
        public virtual Participant Away { get; set; }
        public Guid ResultId { get; set; }
        public virtual Result Result { get; set; }

        // Properties
        public DateTime DateTime { get; set; }
    }
}
