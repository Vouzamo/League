using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    [Table("Team")]
    public partial class Team : Participant
    {
        public virtual ICollection<Individual> Players { get; set; }
    }
}
