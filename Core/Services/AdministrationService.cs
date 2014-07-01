using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Classes;
using Core.Models.Interfaces;

namespace Core.Services
{
    public class AdministrationService : IAdministrationService
    {
        public IEnumerable<IAdministrativeBody> GetAdministrativeBodies()
        {
            throw new NotImplementedException();
        }

        public IAdministrativeBody GetAdministrativeBody(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
