using System;
using Desafio_composicao_trabalhador.Entities.Enums;
using System.Globalization;
using Desafio_composicao_trabalhador.Entities;

namespace Desafio_composicao_trabalhador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nome do departamento: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Digite os dados do trabalhador: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); // a opção escrita(string) é convertida para enum
            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //INSTANCIANDO OS OBJETOS

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Quantos contratos o trabalhador possui?: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Entre com os dados do " + i + "º contrato:");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duração (Em horas): ");
                int hour = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hour);

                //ADICIONAR CONTRATOS AO TRABALHADOR

                worker.AddContract(contract);

            }
            Console.WriteLine();
            Console.Write("Entre com o mes e ano para calcular o ganho (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse( monthAndYear.Substring(0, 2)); // mes recebe a string cortada, iniciando no indice 0, com 2 caracteres 
            int year = int.Parse(monthAndYear.Substring(3)); // ano receb a string cortadado 3 ate o final

            Console.WriteLine("Dados do trabalhador: ");
            Console.WriteLine();
            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Ganhos de " + monthAndYear+ ": "+worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture);

        }
    }
}
