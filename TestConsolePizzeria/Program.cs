using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using Data;
using Data.Repository;
using Newtonsoft.Json;

namespace TestConsolePizzeria
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(5000); //Lance le projet 5 secondes plus tard car la console se lance plus rapidement que l'API et donc connection refusée

            HttpClient client = new HttpClient();
            //HttpResponseMessage responseMessage = client.GetAsync("http://localhost:55434/api/client").Result;

            //string reponseBody = responseMessage.Content.ReadAsStringAsync().Result;

            //var reponse = JsonConvert.DeserializeObject<Client[]>(reponseBody);

            //foreach (var item in reponse)
            //{
            //    Console.WriteLine(item.LastName);
            //}

            //HttpResponseMessage responseMessage = client.GetAsync("http://localhost:55434/api/client/2").Result;

            //string reponseBody = responseMessage.Content.ReadAsStringAsync().Result;
            //var reponse = JsonConvert.DeserializeObject<Client>(reponseBody);

            //Console.WriteLine(reponse.LastName);

            //var content = new Client{ ClientId = 14, LastName = "Maradona", FirstName = "Diego", Adresse = "Buenos Aires", PizzaId = 4, Coment = "", DateEtHeure = DateTime.Now };
            //string json = JsonConvert.SerializeObject(content);

            //HttpContent httpContent = new StringContent(json);
            //httpContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");


            //HttpResponseMessage responseMessage = client.PostAsync("http://localhost:55434/api/client/", httpContent).Result;


            //HttpResponseMessage responseMessage = client.DeleteAsync("http://localhost:55434/api/client/12").Result;

        }

    }
}
