USE FireSystem
GO
IF OBJECT_ID('dbo.GetPostulations', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetPostulations
GO

CREATE PROCEDURE dbo.GetPostulations
AS
	SELECT *
	FROM Postulations
GO