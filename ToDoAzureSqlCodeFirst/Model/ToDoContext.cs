using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ToDoAzureSqlCodeFirst.Model
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }//var tabel - kan läggatill new tabel här

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"connect string _local DB");-- local DB

            // optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[SglMyConnection].ConnectionString); //? funka inte ???

            optionsBuilder.UseSqlServer(@"Server=tcp:sqlserver-ec.database.windows.net,1433;Initial Catalog=AzureSqlCodeFirst;Persist Security Info=False;User ID=natlee;Password={};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }//ta bort local connec string
    //copy connect string från azure och lägg it till app.config--- den file skickas inte in github
    //her vi referera till app.config
}
