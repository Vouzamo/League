using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Interfaces
{
    public interface IParticipant
    {
        Guid Id { get; set; }
        string Name { get; set; }

        IEnumerable<ICompetition> GetCompetitions();
    }
}
