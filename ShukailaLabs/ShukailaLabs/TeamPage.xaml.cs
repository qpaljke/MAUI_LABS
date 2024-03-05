namespace ShukailaLabs;
using ShukailaLabs.Services;
using ShukailaLabs.Entities;
public partial class TeamPage : ContentPage
{
	private List<Team> teams;
	private List<Participant> participants;
	private IDbService _database;
	public TeamPage(IDbService database)
	{
		_database = database;
		_database.Init();
		InitializeComponent();
		LoadData();
	}

	private void LoadData()
	{
		teams = _database.GetAllTeams();
		picker.ItemsSource = teams;
	}

	public void OnTeamSelectedIndexChanged(object sender, EventArgs e)
	{
		var selectedResponsibility = picker.SelectedItem as Team;
		if (selectedResponsibility != null)
		{
			participants = _database.GetTeamParticipants(selectedResponsibility.TeamId);
			collectionView.ItemsSource = participants;
		}
	}
}