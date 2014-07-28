using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]
        public DateTime To { get; set; }
        
        // Children
        public virtual ICollection<Division> Divisions { get; set; }
    }
}
