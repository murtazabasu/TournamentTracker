CREATE PROCEDURE dbo.spTeam_GetByTournament
	@TournamentId int
	
AS
BEGIN
	SET NOCOUNT ON;
	
	select t.*
	from dbo.Teams t
	inner join dbo.TournamentEntries e on t.id = e.TeamId
	where e.TournamentId = @TournamentId;

END

