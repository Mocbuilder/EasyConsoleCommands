using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EasyConsoleCommands.Commands
{
    internal class JokeResponse
    {
        public string type { get; set; }
        public string setup { get; set; }
        public string punchline { get; set; }
        public int id { get; set; }
    }

    internal class CommandJoke : ICommand
    {
        private readonly HttpClient client;

        public CommandJoke()
        {
            client = new HttpClient();
        }

        public string Name => "joke";

        public string HelpText => "joke [-ten] -> Get a random joke, or optionally ten random jokes.";

        public List<Type> ParameterTypes => new List<Type> { typeof(StringInfo)};

        public async void Execute(List<VariableInfo> inputParams)
        {
            StringInfo param = inputParams[0] as StringInfo;

            string apiUrl = "https://official-joke-api.appspot.com/random_joke";
            if (param.Value == "ten")
            {
                apiUrl = "https://official-joke-api.appspot.com/jokes/ten";

                try
                {
                    HttpResponseMessage tenresponse = await client.GetAsync(apiUrl);

                    if (tenresponse.IsSuccessStatusCode)
                    {
                        string result = await tenresponse.Content.ReadAsStringAsync();
                        JokeResponse[] jokes = JsonSerializer.Deserialize<JokeResponse[]>(result);

                        foreach (var joke in jokes)
                        {
                            Console.WriteLine($"Joke ID: {joke.id}");
                            Console.WriteLine($"Type: {joke.type}");
                            Console.WriteLine($"Setup: {joke.setup}");
                            Console.WriteLine($"Punchline: {joke.punchline}");
                            Console.WriteLine();
                        }
                        return;
                    }
                    else
                    {
                        throw new Exception("Couldn't reach the API");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Failed to get jokes from API");
                }
            }

            try
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    JokeResponse joke = JsonSerializer.Deserialize<JokeResponse>(result);

                    Console.WriteLine($"Joke ID: {joke.id}");
                    Console.WriteLine($"Type: {joke.type}");
                    Console.WriteLine($"Setup: {joke.setup}");
                    Console.WriteLine($"Punchline: {joke.punchline}");
                }
                else
                {
                    throw new Exception("Couldn't reach the API");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to get joke from API");
            }
        }
    }
}
