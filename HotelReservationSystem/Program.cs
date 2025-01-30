using HotelReservationSystem.Models;
using HotelReservationSystem.Services;

class Program
{
     static void Main(string[] args)
    {
        Console.WriteLine("--- Cadastro de Suíte ---");
        Console.Write("Digite o tipo da suíte: ");
        string tipoSuite = Console.ReadLine();

        Console.Write("Digite a capacidade da suíte: ");
        int capacidade = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor da diária: ");
        decimal valorDiaria = decimal.Parse(Console.ReadLine());

        Suite suite = new Suite(tipoSuite, capacidade, valorDiaria);

        Console.WriteLine("--- Cadastro de Hóspedes ---");
        List<Pessoa> hospedes = new List<Pessoa>();

        Console.Write("Quantos hóspedes deseja cadastrar? ");
        int quantidadeHospedes = int.Parse(Console.ReadLine());

        for (int i = 0; i < quantidadeHospedes; i++)
        {
            Console.Write($"Digite o primeiro nome do hóspede {i + 1}: ");
            string nome = Console.ReadLine();

            Console.Write($"Digite o sobrenome do hóspede {i + 1}: ");
            string sobrenome = Console.ReadLine();

            hospedes.Add(new Pessoa(nome, sobrenome));
        }

        Console.Write("Digite a quantidade de dias reservados: ");
        int diasReservados = int.Parse(Console.ReadLine());

        Reserva reserva = new Reserva { DiasReservados = diasReservados };
        ReservaService reservaService = new ReservaService(reserva);

        try
        {
            reservaService.CadastrarSuite(suite);
            reservaService.CadastrarHospedes(hospedes);

            Console.WriteLine("--- Reserva Concluída ---");
            Console.WriteLine($"Quantidade de hóspedes: {reservaService.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor total da diária: {reservaService.CalcularValorDiaria():C}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }
}