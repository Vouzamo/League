using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Interfaces
{
    public interface ISeason
    {
        [ScaffoldColumn(false)]
        Guid Id { get; set; }
        [Required, Display(Name = "Year")]
        int Year { get; set; }
        [Required, StringLength(100), Display(Name = "Name")]
        string Name { get; set; }

        IEnumerable<ICompetition> Competitions { get; set; }
    }
}
