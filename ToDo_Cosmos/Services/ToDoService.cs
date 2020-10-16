using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using ToDo_Cosmos.Model;

namespace ToDo_Cosmos.Services
{
    
    class ToDoService
    {

        private static CosmosClient cosmosClient;
        private static Database database;
        private static Container container;


        // kommer skapa DB som inte existera , conteiner som inte existera / 2 f. som gör den 
        private static async Task CreateDatabaseAsync()
        {
            database = await cosmosClient.CreateDatabaseIfNotExistsAsync(
                ConfigurationManager.AppSettings["DatabaseName"]);
        }

        private static async Task CreateContainerAsync()
        {
            container = await database.CreateContainerIfNotExistsAsync(
                ConfigurationManager.AppSettings["ContainerName"], "/id", 400);

                //ska ha partitional key- primery key from conteiner (/id)
        }

        public static async Task InitializeCosmosDb()
        {
            //initiera var client: att skapa koppling:
            cosmosClient = new CosmosClient(
                ConfigurationManager.AppSettings["EndpointUri"],
                ConfigurationManager.AppSettings["PrimaryKey"]);

            await CreateDatabaseAsync();
            await CreateContainerAsync();
        }

        public static  async Task AddToDoAsync(string activity)
        {//skapa f.
            await container.CreateItemAsync(new ToDo(activity));
        }

        public static async Task <IEnumerable<ToDo>> GetToDosAsync()
        { //list - lite annat var. hämta alla ToDo
            var query = new QueryDefinition( " SELECT * FROM c"); // from DB azure cosmos
            FeedIterator<ToDo> result = container.GetItemQueryIterator<ToDo>(query);//hämta lista, kolla genom lista

            var todos = new List<ToDo>();//skapa new lista 
            while(result.HasMoreResults)
            {
                var data = await result.ReadNextAsync();
                foreach(var todo in data)
                {//läga till i lista de värderna som jag får
                    todos.Add(todo);
                }
            }

            return todos;
        
        }


        public static async Task<ToDo> GetToDoAsync(string id)
        {//hämta 1 ToDo
            var result = await container.ReadItemAsync<ToDo>(id, new PartitionKey(id));
            return result.Resource;//själva TOdO delen,när vi gör

        }//test -fel


        public static async Task UpdateToDoAsync(string id)
        {// updatera , behöver inte hämta tillbacka
            var result = await container.ReadItemAsync<ToDo>(id, new PartitionKey(id));//hämtas
            
            if(result != null)
            {
                var todo = result.Resource;
                todo.Completed = true;//andra på object

                await container.ReplaceItemAsync(todo, todo.Id, new PartitionKey(todo.Id));//updatera
            }
            
        }


        public static async Task RemoveToDoAsync(string id)
        {//tabort f.
            var result = await container.ReadItemAsync<ToDo>(id, new PartitionKey(id));//hämta, söka - om vi har 

            if (result != null)
            {
                var todo = result.Resource;//så sätta till vår object
                
                await container.DeleteItemAsync<ToDo>( todo.Id, new PartitionKey(todo.Id));//<typen>
            }
        }
    }

}
