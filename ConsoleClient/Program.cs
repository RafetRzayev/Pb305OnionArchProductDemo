namespace ConsoleClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync("https://localhost:7278/api/Products");
            Console.WriteLine(result);
        }
    }
}
