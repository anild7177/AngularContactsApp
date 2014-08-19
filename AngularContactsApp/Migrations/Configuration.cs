namespace AngularContactsApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using AngularContactsApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularContactsApp.Models.MyContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AngularContactsApp.Models.MyContactsContext context)
        {
            context.MyContacts.AddOrUpdate(new MyContacts[]
            {
                new MyContacts()
                {
                    Id = 51, Name = "Anil", MobileNumber = 9000827177, Email = "anild@techaspect.com"
                }
            });
        }
    }
}
