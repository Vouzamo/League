using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models.Classes
{
    public class AdministrativeBody
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Foreign Key(s)
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        // Properties
        public string Name { get; set; }

        // Children
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Participant> Participants { get; set; } 
    }
}
