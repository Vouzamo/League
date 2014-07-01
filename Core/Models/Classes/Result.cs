using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Interfaces;

namespace Core.Models.Classes
{
    public class Result : IResult
    {
        public Guid Id { get; set; }
        public IFixture Fixture { get; set; }
        public IParticipant Winner { get; set; }
        public IEnumerable<IStatistic> Statistics { get; set; }
    }
}
