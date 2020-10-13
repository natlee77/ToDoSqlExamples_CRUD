using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ToDoSql_DB_First.Models
{
    public partial class ToDo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Activity { get; set; }
        public bool Completed { get; set; }
        public DateTime Created { get; set; }

        //lägga till ctor
        public ToDo(string activity) 
        {           
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
            
        }
        public ToDo()
        {

        }
    }
}
