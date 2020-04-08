using exercicio_composição.Entities;
using exercicio_composição.Entities.Enums;
using System;

namespace exercicio_composição
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Qual o nome do departamento ? : ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Entre com os dados do trabalhador : ");
            Console.Write("Nome : ");
            string workerName = Console.ReadLine();
            
            Console.Write("Level (Junior/MidLevel/Senior) : ");
            WorkerLevel workerLevel = Enum.Parse<WorkerLevel>(Console.ReadLine());

            Console.Write("Base salary : R$");
            double baseSalary = double.Parse(Console.ReadLine());

            Departamento departamento = new Departamento(deptName);
            Workers worker = new Workers(workerName, workerLevel, baseSalary, departamento);

            Console.Write("Quantos contratos você vai cadastrar ? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i<= n; i++)
            {
                Console.WriteLine($"Entre com os dados do #{i} contrato");
                
                Console.Write("Data (DD/MM/YYYY) : ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                
                Console.Write("Valor por hora : ");
                double valuePerHour = double.Parse(Console.ReadLine());

                Console.Write("Duração em horas : ");
                int horas = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(data, valuePerHour, horas);
                worker.AddContract(contract);

                Console.WriteLine();
            }
            Console.WriteLine("Entre com o mês e ano para calcular os ganhos (MM/YYYY)");

            string mesEAno = Console.ReadLine();
            int mes = int.Parse(mesEAno.Substring(0, 2));
            int ano = int.Parse(mesEAno.Substring(3));

            Console.WriteLine($"Nome : {worker.Name}");
            Console.WriteLine($"Departamento : {worker.Departamento.Name}");
            Console.WriteLine($"O ganho para {mesEAno} é de : R${worker.income(ano,mes):F2}");


        }
    }
}
