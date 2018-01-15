CREATE TABLE [dbo].[Person]
(
	Id INT NOT NULL IDENTITY,
	FirstName varchar(50),
	LastName varchar(50),
	Gender varchar(6),
	FavoriteColor varchar(10),
	DateOfBirth datetime
)
