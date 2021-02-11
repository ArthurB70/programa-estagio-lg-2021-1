﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGProgramaDeEstagio2021
{
    class CalcularDiasUteis
    {
        
        public static int Calcula(int mes, int ano)
        {         
            var MesCalculo = new DateTime(ano, mes, 1);
            int diasMes = DateTime.DaysInMonth(MesCalculo.Year, MesCalculo.Month);
            int diasUteis = 0;
            while (MesCalculo.Day <= diasMes)
            {
                if (!(MesCalculo.DayOfWeek == DayOfWeek.Saturday || MesCalculo.DayOfWeek == DayOfWeek.Sunday))
                    diasUteis += 1;

                MesCalculo = MesCalculo.AddDays(1);
            }
            return diasUteis;
        }
    }
}
