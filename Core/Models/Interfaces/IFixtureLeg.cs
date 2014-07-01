using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Interfaces
{
    public interface IFixtureLeg
    {
        Guid Id { get; set; }
        DateTime DateTime { get; set; }
        IParticipant Home { get; set; }
        IParticipant Away { get; set; }
        IVenue Venue { get; set; }
    }
}
