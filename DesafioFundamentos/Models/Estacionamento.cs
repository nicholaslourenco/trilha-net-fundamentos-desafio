using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa = string.Empty;
            bool placaValida = false;

            do
            {
                Console.WriteLine("Digite a placa do veículo para estacionar (formato: AAA-0000):");
                placa = Console.ReadLine().ToUpper();

                // Usando expressão regular para validar o formato da placa (AAA-0000)
                string padrao = @"^[A-Z]{3}-\d{4}$";

                if (Regex.IsMatch(placa, padrao))
                {
                    placaValida = true;
                }
                else
                {
                    Console.WriteLine("Formato de placa inválido. A placa deve ter 3 letras, um traço e 4 números. Tente novamente.");
                }
            } while (!placaValida);

            veiculos.Add(placa);
            Console.WriteLine($"Placa {placa} adicionada com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine().ToUpper();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x == placa)) // Só fiz essa alteração para funcionar a validação de placas
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
