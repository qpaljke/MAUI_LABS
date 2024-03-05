using ShukailaLabs.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShukailaLabs.Services;

public interface IDbService
{
    public List<Team> GetAllTeams();
    public List<Participant> GetTeamParticipants(int id);
    public void Init();
}
