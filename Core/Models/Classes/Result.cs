using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Classes
{
    public class Result
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Foreign Key(s)
        public Guid LegId { get; set; }
        public virtual Leg Leg { get; set; }

        // Properties
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
