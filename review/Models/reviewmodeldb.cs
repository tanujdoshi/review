using System;
using System.Data.Entity;
using System.Linq;

namespace review.Models
{
    
    public class reviewmodeldb : DbContext
    {
        // Your context has been configured to use a 'reviewmodeldb' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'review.Models.reviewmodeldb' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'reviewmodeldb' 
        // connection string in the application configuration file.
        public reviewmodeldb()
            : base("name=reviewmodeldb")
        {
        }
        public DbSet<user> Users { get; set; }
        public DbSet<adminn> Admins { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<subcategory> subcategories { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<product> Products { get; set; }
             
        public DbSet<suggestion> suggestions { get; set; }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}