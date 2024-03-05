using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShukailaLabs.Entities;
using SQLite;
namespace ShukailaLabs.Services;

public class SQLiteService : IDbService
{
    private SQLiteConnection _database;
    public const string _databaseFilename = "database.db";

    public static string _databasePath = Path.Combine(FileSystem.AppDataDirectory, _databaseFilename);

    public SQLiteService()
    {
        _database = new SQLiteConnection(_databasePath);
        _database.DropTable<Team>();
        _database.DropTable<Participant>();
        _database.CreateTable<Team>();
        _database.CreateTable<Participant>();
    }


    public List<Team> GetAllTeams()
    {
        return _database.Table<Team>().ToList();
    }

    public List<Participant> GetTeamParticipants(int id)
    {
        return _database.Table<Participant>().Where(p  => p.TeamId == id).ToList();
    }
    public void Init()
    {

        if (_database != null)
        {
            _database.Insert(new Team() { TeamName = "Real Madrid"});
            _database.Insert(new Team() { TeamName = "Chelsea" });
            _database.Insert(new Team() { TeamName = "Barcelona" });
            _database.Insert(new Team() { TeamName = "Paris Saint Germain" });
            _database.Insert(new Team() { TeamName = "Liverpool" });


            _database.Insert(new Participant() { TeamId = 1, ParticipantName = "Fran Garcia", ParticipantContractCost = 45000000 });
            _database.Insert(new Participant() { TeamId = 1, ParticipantName = "Ferland Mendy", ParticipantContractCost = 20000000 });
            _database.Insert(new Participant() { TeamId = 1, ParticipantName = "Alvaro Carrillo", ParticipantContractCost = 37500000 });
            _database.Insert(new Participant() { TeamId = 1, ParticipantName = "Luka Modric", ParticipantContractCost = 19000000 });

            _database.Insert(new Participant() { TeamId = 2, ParticipantName = "Malo Gusto", ParticipantContractCost = 24500000 });
            _database.Insert(new Participant() { TeamId = 2, ParticipantName = "Reece James", ParticipantContractCost = 35600000 });
            _database.Insert(new Participant() { TeamId = 2, ParticipantName = "Levi Colwill", ParticipantContractCost = 15700000 });

            _database.Insert(new Participant() { TeamId = 3, ParticipantName = "Ronadl Araujo", ParticipantContractCost = 7000000 });
            _database.Insert(new Participant() { TeamId = 3, ParticipantName = "Jules Kounde", ParticipantContractCost = 12400000 });

            _database.Insert(new Participant() { TeamId = 4, ParticipantName = "Kylian Mbappe", ParticipantContractCost = 70000000 });
            _database.Insert(new Participant() { TeamId = 4, ParticipantName = "Nuno Mendes", ParticipantContractCost = 30000000 });

            _database.Insert(new Participant() { TeamId = 5, ParticipantName = "Pavel Shukaila", ParticipantContractCost = 99999999 });
            _database.Insert(new Participant() { TeamId = 5, ParticipantName = "Maksim Antikhovich", ParticipantContractCost = 99999999});
        }
    }
}
        

