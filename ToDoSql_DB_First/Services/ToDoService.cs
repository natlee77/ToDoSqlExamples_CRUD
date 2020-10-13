using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ToDoSql_DB_First;
using ToDoSql_DB_First.Models;

namespace ToDoSql_DB_First.Services

{

    /// <summary>
    /// PREFORMS CRUD operations for Sql ToDos
    /// CRUD- Create Read Update Delete=Add Get Update Delete
    /// </summary>
    public static class ToDoService         // static --slippa göra instance
    {
        public static async Task AddToDoAsync(string activity)
        //om anropa (new ToDo(activity))--måste skriva--(string activity)
        {
            //instance
            //var context = new ToDoContext();
            /*problem med den variant, som vi vanlig gör i Class, 
              om jag inte implementera IDispose, Task ta inte bort */
            //using 
            using ToDoContext context = new ToDoContext();// 1. koopla till DB-oppna och stänga dooren

            context.ToDos.Add(new ToDo(activity));              //2. förberreda vad jag ska göra
            context.ToDos.Add(new ToDo { Activity = activity });// object variant om har inga CTOR
            context.ToDos.Add(new ToDo { Activity = "" });    // kan skriva egna activity i ""
            // hittad från --public DbSet<ToDo> ToDos { get; set;}
            //i {} kan hitta Created från ToDo.cs || ()kan skapa ctor där och använda andra 



            await context.SaveChangesAsync();    //3.utföra handling och gå genom door

            //de 3 raden --skapa nånting i database
        }


        // hämta info- alla rader från tabel
        public static async Task<IEnumerable<ToDo>> GetReadToDoAsync()
        {

            using ToDoContext context = new ToDoContext();//oppna 

            return await context.ToDos.ToListAsync(); //ge list med IENummer i mit programm
        }

        //l spesifict hämta från DB
        public static async Task<ToDo> GetToDoAsync(int id)//retunera=söka ID
                                                           // hämta ut hsjälva todo
        {
            using ToDoContext context = new ToDoContext();//oppna 

            return await context.ToDos.FindAsync(id);//kan göra find -söka genom list specifik Id nummer( i async findasync)

        }

        //söka på nån som t.ex inte completed--kan göra list av flera
        public static async Task<IEnumerable<ToDo>> GetTodosByCompletedAsync(bool completed)
        {
            using ToDoContext context = new ToDoContext();//oppna/stäng

            return await context.ToDos.Where(todo => todo.Completed == completed).ToListAsync();
            //where --Sql link-sats --landa exepretion --kan vara vad som helst (sätta vad jag vill)söka nån speciel 
            //== jämförelse eller true (beroende vad jag stoppar in )alla som klarad ||inte klarad
        }

        // uppdatera
        public static async Task UpdateToDoAsync(int id) //nån form identifiering
        {
            using ToDoContext context = new ToDoContext();

            var todo = await context.ToDos.FindAsync(id);
            /* när vi gör context.ToDos.FindAsync(id)--kör en tracking 
            *den track så den vet att atribyt "context.ToDos.FindAsync(id)" har koopling till "var todo
            *den vet att den object vi har*/

            if (todo != null)
            {
                todo.Completed = true;

                /* här tala jag om då --fören context del  jag har ändrat på den objected*/
                context.Entry(todo).State = EntityState.Modified;
                //Spara om --det som ändrat på object 
                await context.SaveChangesAsync();
            }
            //+ in programm           
        }

        //Delete -remove
        //copy från  public static async Task UpdateToDoAsync(int id ) 
        public static async Task RemoveToDoAsync(int id)
        {
            using ToDoContext context = new ToDoContext();  // koppling till DB

            var todo = await context.ToDos.FindAsync(id);   //vi vill hitta därhär TODO
            /* när vi gör context.ToDos.FindAsync(id)--kör en tracking 
            *den track så den vet att atribyt "context.ToDos.FindAsync(id)" har koopling till "var todo
            *den vet att den object vi har*/

            if (todo != null)//om inte 0 göra nån med det
            {
                context.ToDos.Remove(todo);//om hitta-ta bort ,
                await context.SaveChangesAsync();
            }    //+ in programm
        }
    }


}
