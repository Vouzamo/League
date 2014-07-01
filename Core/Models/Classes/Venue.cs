using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    public class Venue
    {
        public Guid Id { get; set; }

        public virtual ICollection<Participant> Participants { get; set; }

        public string Name { get; set; }
    }
}
