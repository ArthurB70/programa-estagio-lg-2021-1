﻿using System;

namespace LGProgramaDeEstagio2021
{
    public class CalculaSalarioAutonomo : ICalcularSalario
    {
        public DateTime MesCalculo;
        private IRepositorio<ValoresCalculados> repositorio;

        public CalculaSalarioAutonomo(
            IRepositorio<ValoresCalculados> repositorio,
            int mes,
            int ano)
        {
            MesCalculo = new DateTime(ano, mes, 1);
            this.repositorio = repositorio;
        }

        public void CalculaSalario(Funcionario funcionario)
        {
            int diasUteis = CalcularDiasUteis.Calcula(MesCalculo.Month, MesCalculo.Year);
            int diasMes = DateTime.DaysInMonth(MesCalculo.Year , MesCalculo.Month);
            repositorio.Insert(new ValoresCalculados
            {
                Matricula = funcionario.Codigo,
                Mes = MesCalculo,
                Salario = (funcionario.SalarioContratual / diasMes) * diasUteis
            });
        }
    }
}