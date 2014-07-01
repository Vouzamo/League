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
    public class Season
    {
        // Primary Key
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        // Foreign Key(s)
        public Guid AdministrativeBodyId { get; set; }
        public virtual AdministrativeBody AdministrativeBody { get; set; }

        // Properties
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        
        // Children
        public virtual ICollection<Division> Divisions { get; set; }
    }
}
