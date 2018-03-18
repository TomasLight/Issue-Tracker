/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
SELECT bug.[Id]
      ,bug.[Name],
	  history.DateUpdate,
	  --users.LastName,
	  --users.FirstName,
	  users.Login,
	  status.Status
  FROM [BugInfo].[dbo].[Bugs] as bug
  inner join [BugInfo].[dbo].Histories as history on bug.Id = history.BugId
  inner join [BugInfo].[dbo].Users as users on history.UserId = users.Id
  inner join [BugInfo].[dbo].HistoriesStatus as status on history.Id = status.HistoryId