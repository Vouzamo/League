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
            Venue currentVenue = null;
            AdministrativeBody currentAdministrativeBody = null;

            foreach (var venue in GetVenues())
            {
                context.Venues.Add(venue);
                currentVenue = venue;
            }

            foreach (var administrativeBody in GetAdministrativeBody())
            {
                context.AdministrativeBodies.Add(administrativeBody);
                currentAdministrativeBody = administrativeBody;
            }

            foreach (var participant in GetParticipants(currentVenue, currentAdministrativeBody))
            {
                context.Participants.Add(participant);
            }
        }

        private static IEnumerable<Venue> GetVenues()
        {
            return new Collection<Venue>()
                {
                    new Venue()
                        {
                            Name = "Burnley Snooker Club"
                        }
                };
        }

        private static IEnumerable<Participant> GetParticipants(Venue venue, AdministrativeBody administrativeBody)
        {
            return new Collection<Participant>()
                {
                    new Team()
                        {
                            Participation = Participation.Team,
                            Name = "Burnley Snooker B",
                            Venue = venue,
                            Players = new Collection<Individual>()
                                {
                                    new Individual()
                                        {
                                            Participation = Participation.Individual,
                                            FirstName = "John",
                                            Name = "Askew",
                                            Handicap = -15,
                                            Venue = venue,
                                            AdministrativeBody = administrativeBody
                                        },
                                    new Individual()
                                        {
                                            Participation = Participation.Individual,
                                            FirstName = "Paul",
                                            Name = "Stevens",
                                            Handicap = 10,
                                            Venue = venue,
                                            AdministrativeBody = administrativeBody
                                        }
                                },
                            AdministrativeBody = administrativeBody
                        }
                };
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
                                            To = new DateTime(2014,7,16),
                                            Divisions = new Collection<Division>()
                                        }
                                }
                        }
                };
        }
    }
}
