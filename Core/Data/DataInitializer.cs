using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Classes;
using Core.Models.Enums;

namespace Core.Data
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            foreach (var administrativeBody in GetAdministrativeBody())
            {
                context.AdministrativeBodies.Add(administrativeBody);
            }
        }

        private static IEnumerable<AdministrativeBody> GetAdministrativeBody()
        {
            return new Collection<AdministrativeBody>()
                {
                    new AdministrativeBody()
                        {
                            Name = "Burnley Snooker",
                            Seasons = new Collection<Season>()
                                {
                                    new Season()
                                        {
                                            Name = "Spring",
                                            From = new DateTime(2014,4,1),
                                            To = new DateTime(2014,10,31),
                                            Divisions = new Collection<Division>()
                                                {
                                                    new Division()
                                                        {
                                                            Name = "World Championship",
                                                            Sport = Sport.Snooker,
                                                            CompetitionFormat = CompetitionFormat.Tournament,
                                                            ParticipationType = Participation.Individual,
                                                            Partipants = new Collection<Participant>(),
                                                            Fixtures = new Collection<Fixture>()
                                                        }
                                                }
                                        },
                                    new Season()
                                        {
                                            Name = "Summer",
                                            From = new DateTime(2014,3,15),
                                            To = new DateTime(2014, 7, 16),
                                            Divisions = new Collection<Division>()
                                        }
                                }
                        }
                };
        }
    }
}
