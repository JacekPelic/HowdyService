# How to run?
To run application, make sure that Microsoft SQL Server service is running. If you're not running it locally, consider running it in docker, using docker-compose command in docker file. 

After running Microsoft SQL Server, remember to apply migration with database-update (Preferably  using Package Manager Console in VS using update-database, targeting HowdyService.Dal)
