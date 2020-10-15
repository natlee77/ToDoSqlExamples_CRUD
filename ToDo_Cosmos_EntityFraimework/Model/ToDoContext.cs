using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ToDo_Cosmos_EntityFraimework.Model
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseCosmos(
              ConfigurationManager.AppSettings[ "EndpointUri"],
              ConfigurationManager.AppSettings [ "PrimaryKey"],
              ConfigurationManager.AppSettings ["DatabaseName"]

                );


        }
        //++ genom ToDoContext --generate overrids --OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .HasDefaultContainer(ConfigurationManager.AppSettings["ContainerName"])
                .Entity<ToDo>().HasNoDiscriminator();

        }
    }
}
