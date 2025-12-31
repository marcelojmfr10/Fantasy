
delete from Predictions
delete from Matches
delete from UserGroups
delete from Groups
delete from TournamentTeams
delete from Tournaments

dbcc checkident(Predictions,reseed,0)
dbcc checkident(Matches,reseed,0)
dbcc checkident(UserGroups,reseed,0)
dbcc checkident(Groups,reseed,0)
dbcc checkident(TournamentTeams,reseed,0)
dbcc checkident(Tournaments,reseed,0)