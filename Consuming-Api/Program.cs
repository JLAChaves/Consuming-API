using Consuming_Api.Repositories;
using Refit;

namespace Consuming_Api
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var cepClient = RestService.For<ICepApiServices>("http://viacep.com.br");
                Console.Write("Informe o CEP: ");
                string cepInformed = Console.ReadLine().ToString();
                Console.WriteLine($"Consultando informações do CEP: {cepInformed}");

                var address = await cepClient.GetAddressAsync(cepInformed);
                Console.WriteLine($"\nLogradouro: {address.Logradouro},\nBairro: {address.Bairro},\nCidade: {address.Localidade}" +
                    $"\nIBGE: {address.IBGE}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro na consulta do Cep: {e.Message}");
            }
        }
    }
}