using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo_Cosmos_EntityFraimework.Model
{
   
    public class ToDo
    {
        // ska köra GUID -global idintify unik

       
        public string Id { get; set; } //int till string

        
        public string Activity { get; set; }

       
        public bool Completed { get; set; }

       
        public DateTime Created { get; set; }
               
        public ToDo(string activity) 
        {
            Id = Guid.NewGuid().ToString();
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }
    }
}
