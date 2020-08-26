How to run the project - 
Requirement to run project - 
	a - SQL Server
	b - Visual studio

1) Open available AuthDemo.sln in root folder.
2) To work authenticaton you need to create Database which requires following steps - 
	a - opne nuget package manager console 
	b - Run "add-migration 'migration-name'"
	c - Run "update-database"
3) By now your DB should get created in your sql server with the name of "AuthDemo".
4) Now run the project, you will see home page.