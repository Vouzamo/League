using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Interfaces
{
    public interface IFixture
    {
        Guid Id { get; set; }
        IEnumerable<IFixtureLeg> Legs { get; set; }
        ICompetition Competition { get; set; }

        IResult GetResult();
    }
}
