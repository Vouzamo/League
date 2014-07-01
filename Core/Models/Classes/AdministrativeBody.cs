using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    public class AdministrativeBody
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Properties
        public string Name { get; set; }

        // Children
        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Participant> Participants { get; set; } 
    }
}
