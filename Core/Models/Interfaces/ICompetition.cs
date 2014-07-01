using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;

namespace Core.Models.Interfaces
{
    public interface ICompetition
    {
        Guid Id { get; set; }
        string Name { get; set; }
        Sport Sport { get; set; }
        ISeason Season { get; set; }
        CompetitionFormat CompetitionType { get; set; }
        Participation ParticipationType { get; set; }
        IEnumerable<IParticipant> Partipants { get; set; }
        IEnumerable<IFixture> Fixtures { get; set; }
    }
}
