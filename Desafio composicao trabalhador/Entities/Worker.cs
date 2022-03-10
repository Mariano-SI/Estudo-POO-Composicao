using Desafio_composicao_trabalhador.Entities.Enums;
using System.Collections.Generic;


namespace Desafio_composicao_trabalhador.Entities
{
    class Worker
    {
        //ATRIBUTOS
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }

        /*COMPOSIÇÂO:
        já que cada trabalhador está ligado a um departamento, dentro dessa classe deve haver
        a propriedade dizendo a qual departamento ele esta interligado, assim eu associo
        classes diferentes*/

        public Department Department { get; set; }

        public List<HourContract> Contrats { get; set; } = new List<HourContract>(); // Lista, pois um trabalhador pode ter vários contratos

        //CONSTRUTORES

        public Worker()
        {
        }
        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //METODOS
        public void AddContract(HourContract contract)
        {
            Contrats.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contrats.Remove(contract);
        }
        public double Income(int year, int month) //Income é quanto ele ganhou em um periodo
        {
            double sum = BaseSalary; // Acumulador de ganhos alem do salario base

            foreach (HourContract contract in Contrats)
            {
                if (contract.Date.Year == year && contract.Date.Month == month )
                {
                    sum += contract.TotalValue(); 
                }
            }
            return sum;



        }
    }
}
