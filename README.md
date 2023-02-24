# LimedikaTask

Prerequisites:<br />
VS 2022<br />
SQL 2022 (Most likely would run with older versions, but not tested)<br />

*Steps to try out the application:*<br />
1.Clone repository (VS 2022)<br />
2.Build solution<br />
3.Add user secrets to the project in the format
{
  "Clients": {
    "ConnectionString": "Server=.;Database=LimedikaTask;Trusted_Connection=True;TrustServerCertificate=True;",
    "ServiceApiKey": "yourapikeyhere"
  }
}<br />
3.In Package Manager Console run command - "Add-Migration testMigration" and then run "Update-Database"<br />
4.Run application and try out the functionality.<br />
