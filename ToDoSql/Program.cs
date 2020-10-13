using System;
using System.Threading.Tasks;
using ToDoSql_CodeFirst.Service;

namespace ToDoSql_CodeFirst
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //await ToDoService.CreateToDoAsync("rast"); //
            //await CreateToDoAsync();
            await ListAllToDosAsync();
            //await GetToDoAsync();
            //await GetToDosByCompletedAsync(true); //false hämta som inte klarad
            //await Update_MarkToDoAsCompletedAsync();  //update
            await DeleteToDoAsync();
        }

        // ska tilläga utskriv f.  för de programm som har inte console 
        private static async Task CreateToDoAsync()//skapa nån
        {
            Console.Write("Enter a new activity :  ");// fråga user
            string activity = Console.ReadLine();

            await ToDoService.AddToDoAsync(activity);//
            Console.WriteLine("Create new ToDo in Datebase");
        }

        private static async Task ListAllToDosAsync() //+ in  main //lista upp
        {
            //1. hämtning
            var todos = await ToDoService.GetReadToDoAsync();


            Console.WriteLine("Listing all ToDos in Datebase"); // skriva 
            foreach (var todo in todos)
            {
                // vi skara göra nånting
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Created: {todo.Created}");
                Console.WriteLine($"Conpleted: {todo.Completed}");
                Console.WriteLine($"Activity: {todo.Activity}");
                Console.WriteLine(new string('-', 30));

            }

        }


        private static async Task GetToDoAsync() //namn skapa


        {
            Console.Write("Enter Id of the ToDo :  ");// fråga user vilka vi vila ha
            int id = Convert.ToInt32(Console.ReadLine());// convertera resultat i int

            var todo = await ToDoService.GetToDoAsync(id);//

            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Created: {todo.Created}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"Activity: {todo.Activity}");
            Console.WriteLine(new string('-', 30));

        }


        private static async Task GetToDosByCompletedAsync(bool completed) //+ in  main //lista upp
        {
            //1. hämtning
            var todos = await ToDoService.GetTodosByCompletedAsync(completed);

            Console.WriteLine("Listing all  Completed ToDos in Datebase"); // skriva 
            foreach (var todo in todos)
            {
                // vi skara göra nånting
                Console.WriteLine($"Id: {todo.Id}");
                Console.WriteLine($"Created: {todo.Created}");
                Console.WriteLine($"Conpleted: {todo.Completed}");
                Console.WriteLine($"Activity: {todo.Activity}");
                Console.WriteLine(new string('-', 30));

            }
        }
    
    
      //updatera 
      private static async Task Update_MarkToDoAsCompletedAsync()
        { ///tala om vilken jag vill ha
            Console.Write("Enter Id of the Completed ToDo :  ");// fråga user
          int id = Convert.ToInt32(Console.ReadLine());

            await ToDoService.UpdateToDoAsync(id);
            // om jag vill lista -hämta specifika:
            await GetToDoAsync(id);// den ta inte (ID) men jag vill har ID
        }

        // copy  +(ID)  --private static async Task GetToDoAsync()
        private static async Task GetToDoAsync(int id=0) //0 -sätta standart värde
        {
            //+ ifsats:
            if (id == 0)
            {
                Console.Write("Enter Id of the ToDo :  ");// fråga user vilka vi vila ha
                id = Convert.ToInt32(Console.ReadLine());// convertera resultat i int

            }


            var todo = await ToDoService.GetToDoAsync(id);//

            Console.WriteLine($"Id: {todo.Id}");
            Console.WriteLine($"Created: {todo.Created}");
            Console.WriteLine($"Completed: {todo.Completed}");
            Console.WriteLine($"Activity: {todo.Activity}");
            Console.WriteLine(new string('-', 30));

        }
    
    private static async Task DeleteToDoAsync()
        { 
            Console.Write("Enter Id of the ToDo that you want Delete :  ");
            int id = Convert.ToInt32(Console.ReadLine());

            await ToDoService.RemoveToDoAsync(id);
            await ListAllToDosAsync();
        }// + upp i main
    }
}
