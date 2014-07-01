using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    public class Statistic : IStatistic
    {
        public Guid Id { get; set; }
    }
}
