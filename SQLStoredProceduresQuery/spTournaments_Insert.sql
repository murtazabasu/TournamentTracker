ALTER PROCEDURE dbo.spTournaments_Insert
	@TournamentName nvarchar(50),
	@EntryFee money,
	@id int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.Tournaments (TournamentName, EntryFee, Active)
	values (@TournamentName, @EntryFee, 1);

END
GO
