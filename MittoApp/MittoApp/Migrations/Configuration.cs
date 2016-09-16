namespace MittoApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MittoApp.Migrations.MittoContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MittoApp.Migrations.MittoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            Countries Germany = new Countries { Id = Guid.Parse("79f3ce58-609c-499a-9703-674a138700a2"), Name = "Germany", MobileCountryCode = "262", CountryCode = "49", PricePerSMS = 0.055m };
            Countries Austria = new Countries { Id = Guid.Parse("bee59f64-9241-4fcb-b9b8-38b54c16298c"), Name = "Austria", MobileCountryCode = "232", CountryCode = "43", PricePerSMS = 0.053m };
            Countries Poland = new Countries { Id = Guid.Parse("b86a4377-7660-4800-adf3-243e73210457"), Name = "Poland", MobileCountryCode = "260", CountryCode = "48", PricePerSMS = 0.032m };


            context.Countries.AddOrUpdate(
              Germany, Austria, Poland
            );

            context.Messages.AddOrUpdate(
                new Messages { Id = Guid.NewGuid(), Country = Germany, Sender = "111222333", Receiver = "111222333", Text = "msg1", State = 0, SendDate = DateTime.Now},
                new Messages { Id = Guid.NewGuid(), Country = Germany, Sender = "111222333", Receiver = "111222333", Text = "msg2", State = 0, SendDate = DateTime.Now },
                new Messages { Id = Guid.NewGuid(), Country = Germany, Sender = "111222333", Receiver = "111222333", Text = "msg3", State = 0, SendDate = DateTime.Now },
                new Messages { Id = Guid.NewGuid(), Country = Austria, Sender = "111222333", Receiver = "111222333", Text = "msg4", State = 0, SendDate = DateTime.Now },
                new Messages { Id = Guid.NewGuid(), Country = Austria, Sender = "111222333", Receiver = "111222333", Text = "msg5", State = 0, SendDate = DateTime.Now },
                new Messages { Id = Guid.NewGuid(), Country = Poland, Sender = "111222333", Receiver = "111222333", Text = "msg6", State = 0, SendDate = DateTime.Now },
                new Messages { Id = Guid.NewGuid(), Country = Poland, Sender = "111222333", Receiver = "111222333", Text = "msg7", State = 0, SendDate = DateTime.Now }                );
            
            
        }
    }
}
