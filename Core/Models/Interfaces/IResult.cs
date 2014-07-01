using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Interfaces
{
    public interface IResult
    {
        Guid Id { get; set; }
        IFixture Fixture { get; set; }
        IParticipant Winner { get; set; }
        IEnumerable<IStatistic> Statistics { get; set; } 
    }
}
