namespace CodeFirst
{
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CodeFirstContext : DbContext
    {
        // Your context has been configured to use a 'CodeFirstContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst.CodeFirstContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CodeFirstContext' 
        // connection string in the application configuration file.
        public CodeFirstContext()
            : base("name=CodeFirstContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CodeFirstContext, Configuration>());
        }

        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightCode> FlightCodes { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<TicketDetail> TicketDetail { get; set; }
                     
    }

}