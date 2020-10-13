using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoSql_CodeFirst.Model
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set;}//var tabel - kan läggatill new tabel här

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\46735\Documents\ToDoSql_CodeFirst.mdf;Integrated Security=True;Connect Timeout=30");
        }
    }
}
