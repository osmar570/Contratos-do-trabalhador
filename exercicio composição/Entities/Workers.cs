using System;
using System.Collections.Generic;
using System.Text;
using exercicio_composição.Entities.Enums;

namespace exercicio_composição.Entities
{
    class Workers
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Departamento Departamento { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Workers()
        {

        }

        public Workers(string name, WorkerLevel level, double baseSalary, Departamento departamento)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departamento = departamento;

        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double income(int year, int month)
        {
            double sum = BaseSalary;
            foreach(HourContract contracts in Contracts)
            {
                if (contracts.Date.Year == year && contracts.Date.Month == month)
                {
                    sum += contracts.TotalValue();
                }
            }
            return sum;
        }

    }
}
