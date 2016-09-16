namespace MittoApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using static Utils.Enums;
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class MittoContext : DbContext
    {
        // Your context has been configured to use a 'MittoContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MittoApp.Migrations.MittoContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MittoContext' 
        // connection string in the application configuration file.
        public MittoContext()
            : base("name=MittoContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

         public virtual DbSet<Countries> Countries { get; set; }

        public virtual DbSet<Messages> Messages { get; set; }
    }

    public class Countries
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string MobileCountryCode { get; set; }
        public string CountryCode { get; set; }
        public decimal PricePerSMS { get; set; }
        
    }

    public class Messages
    {
        public Guid Id { get; set; }
        public Countries Country { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Text { get; set; }
        public State State { get; set; }
        public DateTime SendDate { get; set; }
    }
}