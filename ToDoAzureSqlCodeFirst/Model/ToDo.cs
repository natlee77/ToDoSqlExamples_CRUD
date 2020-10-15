using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDoAzureSqlCodeFirst.Model
{
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Activity { get; set; }

        [Required]
        //public bool Completed { get; set; } = false;
        public bool Completed { get; set; }


        //public int Prioriry { get; set; } //+

        [Required]
        //public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Created { get; set; }



        // kan välja mellan de (tomt och Activity)

        /*  NÄR JAG SKAPA   var todo = newToDO() //tomt
         *                      todo.Activity = "activity text";
                                todo.Completed = false;
                                todo.Created = DateTime.Now;
         * new ToDo()
         * newToDo{}
           new ToDo {Activity="activity text ,+ ,+}*/
        public ToDo()
        {
            Completed = false;
            Created = DateTime.Now;
        }
        public ToDo(string activity) //var ToDo = new ToDo ("activity text")
                                     //new ToDo ("activity text")
        {
            // Prioriry = 2; //+ /1.hight 2.normal/3.low
            Activity = activity;
            Completed = false;
            Created = DateTime.Now;
        }
    }
}


