using System.Collections.Generic;
using System.Collections.ObjectModel;
using BabySitter.Models;

namespace BabySitter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BabySitter.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BabySitter.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller"}
            //    );
            //

            var emergencyContacts = new List<EmergencyContact>()
            {
                new EmergencyContact() {Id =1, name = "Dave", cellNumber = 9880767, Relation = "Brother"},
                new EmergencyContact() {Id =2, name = "Andy", cellNumber = 7610767, Relation = "Father"}
            };
            foreach (var emergencyContact in emergencyContacts)
            {
                context.EmergencyContacts.AddOrUpdate(
                    p => p.Id,
                    emergencyContact
                );
            }
            //// emergencyContacts.ForEach(ec => context.EmergencyContacts.AddOrUpdate(e => e.Id, ec));

            context.SaveChanges();


            var employers = new List<Employer>
            {
                new Employer{Id=1, name = "John", Address = "203/A, Santa Barbara", cellNumber = 9887897,  Children = new List<Child>(), EmergencyContact = context.EmergencyContacts.FirstOrDefault(e=>e.name == "Dave")},
                new Employer{ Id=2,name = "Paul", Address = "4/C/1, Dallas", cellNumber = 6778791, Children = new List<Child>(),EmergencyContact = context.EmergencyContacts.FirstOrDefault(e=>e.name == "Andy")}

            };
            foreach (var employer in employers)
            {
                context.Employers.AddOrUpdate(e => e.Id, employer);
            }
            context.SaveChanges();

            var children = new List<Child>
            {
                new Child{Id=1,name = "Alison", Age = 6, Health = "Normal", Interest = "Playing", Employer = employers.FirstOrDefault(c => c.name == "John")},
                new Child{Id=2,name = "Jason", Age = 5, Health = "Normal", Interest = "Playing", Employer = employers.FirstOrDefault(c => c.name == "John")},
                new Child{Id=3,name = "Ray", Age = 8, Health = "Normal", Interest = "Drawing", Employer = employers.FirstOrDefault(c => c.name == "Paul")}
            };
            foreach (var child in children)
            {
                context.Children.AddOrUpdate(c => c.Id, child);
            }
            context.SaveChanges();

        }
    }
}
