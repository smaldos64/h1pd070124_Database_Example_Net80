namespace Database_Example_Net80.Models
{
    using Microsoft.EntityFrameworkCore;
    using System;
    //using System.Data.Entity;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DatabaseContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Database_Example.Models.DatabaseContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DatabaseContext' 
        // connection string in the application configuration file.
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        //public DatabaseContext() : base("name = 'DBConnectionString' connectionString = 'data source=(LocalDb)\\MSSQLLocalDB;initial catalog=Database_Example_Net80;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework' providerName = 'System.Data.SqlClient'") 
        //{
        //}

        public DatabaseContext() 
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
  
    }
}