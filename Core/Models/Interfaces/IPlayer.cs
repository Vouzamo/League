using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Interfaces
{
    public interface IPlayer : IParticipant
    {
        int handicap { get; set; }
    }
}
