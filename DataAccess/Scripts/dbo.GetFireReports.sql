USE FireSystem
GO
IF OBJECT_ID('dbo.GetFireReports', 'P') IS NOT NULL
	DROP PROCEDURE dbo.GetFireReports
GO

CREATE PROCEDURE dbo.GetFireReports
AS
	SELECT *
	FROM FireReports
GO