using System;
using System.Threading.Tasks;
using ToDo_Cosmos.Services;

namespace ToDo_Cosmos
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ToDoService.InitializeCosmosDb();//koppla till DB
            await CreateToDoAsync();
            await ListAllToDosAsync();
            await GetToDoAsync();//skapa namn
            await Update_MarkToDoAsCompletedAsync();  //update
            await DeleteToDoAsync();
        }


        private static async Task CreateToDoAsync()//skapa nån
        {  // ska tilläga utskriv f.  för de programm som har inte console 


            Console.Write("Enter a new activity :  ");// fråga user
            string activity = Console.ReadLine();

            await ToDoService.AddToDoAsync(activity);
            Console.WriteLine("Create new ToDo in Datebase");
        }

        private static async Task ListAllToDosAsync() //lista upp
        {
            //1. hämtning
            var todos = await ToDoService.GetToDosAsync();


            Console.WriteLine("Listing all ToDos in Datebase"); // skriva 
            foreach (var todo in todos)
            {
                // vi skara göra nånting
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Created: {todo.Created}");
                Console.WriteLine($"Completed: {todo.Completed}");
                Console.WriteLine($"Activity: {todo.Activity}");
                Console.WriteLine(new string('-', 30));

            }
            //+ in  main 
        }


        private static async Task GetToDoAsync(string id = null) //namn skapa
        {
            if (id == null) 
            { 
                Console.Write("Enter id of the ToDo :  ");// fråga user vilka vi vila ha
                id = Console.ReadLine();
            }
            var todo = await ToDoService.GetToDoAsync(id);//

            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Created: {todo.Created}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"Activity: {todo.Activity}");
            Console.WriteLine(new string('-', 30));

        }


      
        //updatera 
        private static async Task Update_MarkToDoAsCompletedAsync()
        { ///tala om vilken jag vill ha
            Console.Write("Enter id of the Completed ToDo :  ");// fråga user
            var id = Console.ReadLine();

            await ToDoService.UpdateToDoAsync(id);
            // om jag vill lista -hämta specifika:
            await GetToDoAsync(id);// den ta inte (ID) men jag vill har ID
        }

        private static async Task DeleteToDoAsync()
        {
            Console.Write("Enter Id of the ToDo that you want Delete :  ");
            var id = Console.ReadLine();

            await ToDoService.RemoveToDoAsync(id);
            await ListAllToDosAsync();
        }// + upp i main
    }
}
