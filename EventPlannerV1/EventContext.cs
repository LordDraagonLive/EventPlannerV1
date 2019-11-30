namespace EventPlannerV1
{
    using EventPlannerV1.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EventContext : DbContext
    {
        // Your context has been configured to use a 'EventContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'EventPlannerV1.EventContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'EventContext' 
        // connection string in the application configuration file.
        public EventContext()
            : base("name=EventContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        //public virtual DbSet<Task> Tasks { get; set; }
        //public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}