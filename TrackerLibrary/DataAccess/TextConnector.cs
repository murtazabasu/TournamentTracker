using System;
using System.Collections.Generic;
using System.Text;
using TrackerLibrary.Models;
using TrackerLibrary.DataAccess.TextHelpers;
using System.Linq;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {

        private const string PrizesFile = "PrizeModels.csv";
        private const string PersonFile = "PersonModels.csv";
        private const string TeamFile = "TeamModels.csv";

        public PersonModel CreatePerson(PersonModel model)
        {
            // Load the test file and convert the text to List<PrizeModel>
            List<PersonModel> people = PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();

            // Find the max ID
            int currentId = 1;

            if (people.Count > 1)
            {
                // Add the new record with the new ID (max + 1)
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            people.Add(model);

            // Convert the prizes to list<string>
            // Save the list<string> to the text file
            people.SaveToPeopleFile(PersonFile);

            return model;
        }

        // TODO - Wire up the CreatePrize for text files.
        public PrizeModel CreatePrize(PrizeModel model)
        {
            // Load the test file and convert the text to List<PrizeModel>
            List<PrizeModel> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrizeModels();

            // Find the max ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                // Add the new record with the new ID (max + 1)
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            prizes.Add(model);

            // Convert the prizes to list<string>
            // Save the list<string> to the text file
            prizes.SaveToPrizeFile(PrizesFile);

            return model;
        }

        public TeamModel CreateTeam(TeamModel model)
        {
            List<TeamModel> teams = TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonFile);

            // Find the max ID
            int currentId = 1;

            if (teams.Count > 0)
            {
                // Add the new record with the new ID (max + 1)
                currentId = teams.OrderByDescending(x => x.Id).First().Id + 1;
            }

            model.Id = currentId;

            teams.Add(model);

            teams.SaveToTeamFile(TeamFile);

            return model;
        }

        public TournamentModel CreateTournament(TournamentModel model)
        {
            throw new NotImplementedException();
        }

        public List<PersonModel> GetPerson_All()
        {
            return PersonFile.FullFilePath().LoadFile().ConvertToPersonModels();
        }

        public List<TeamModel> GetTeam_All()
        {
           return TeamFile.FullFilePath().LoadFile().ConvertToTeamModels(PersonFile);
        }
    }
}
