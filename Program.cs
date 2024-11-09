using System.Text;
using DesafioProjetoHospedagem.Models;
using Microsoft.VisualBasic;
using System.Globalization;

Console.OutputEncoding = Encoding.UTF8;

 //CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");

List<Pessoa> hospedes = new List<Pessoa>();

System.Console.WriteLine("Quantas pessoas irão hospedar?");
int quantidadeHospesdes = int.TryParse(Console.ReadLine(), out var quantidade) ? quantidade : 1;

for(int i = 0; i < quantidadeHospesdes; i++)
{
    Pessoa hospede = new Pessoa();
    System.Console.WriteLine($"Digite o Nome do hospede {i + 1}:");
    string nome = Console.ReadLine() ?? "";
    hospede.Nome = nome;
    System.Console.WriteLine($"Digite o Sobrenome do hospede {i + 1}:");
    string sobrenome = Console.ReadLine() ?? "";
    hospede.Sobrenome = sobrenome;

    hospedes.Add(hospede);
}

Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

System.Console.WriteLine("Quantos dias irão hospedar?");
int quantidadeDias = int.TryParse(Console.ReadLine(), out var dias) ? dias : 1;

Reserva reserva = new Reserva(diasReservados: quantidadeDias);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

System.Console.WriteLine("\n ---- Detalhes da reserva ---------");

Console.WriteLine($"Total de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor total da reserva para {quantidadeDias} dias: {reserva.CalcularValorDiaria().ToString("C", CultureInfo.GetCultureInfo("pt-BR"))}");


System.Console.WriteLine("\n ---- Lista de Hospedes ---------");

for(int i = 0; i < hospedes.Count; i++)
{
    hospedes[i].ListarHospedes(i + 1);
}