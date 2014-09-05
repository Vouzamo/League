using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid HomeId { get; set; }
        public virtual Participant Home { get; set; }
        public Guid AwayId { get; set; }
        public virtual Participant Away { get; set; }

        // Children
        public virtual ICollection<Leg> Legs { get; set; }

        // Properties


        // Methods
        public Result Result
        {
            get
            {
                Result result = new Result();

                foreach (Leg leg in Legs)
                {
                    Result legResult = leg.Result;

                    // Here is where a score object could manipulate the calculation
                    if (legResult != null)
                    {
                        result.HomeScore += leg.Result.HomeScore;
                        result.AwayScore += leg.Result.HomeScore;
                    }
                }

                return result;
            }
        }
    }
}
