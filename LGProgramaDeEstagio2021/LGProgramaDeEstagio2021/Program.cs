﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGProgramaDeEstagio2021
{
    class Program
    {
        static void Main(string[] args)
        {            
            var funcionario = new FuncionarioCLT("Teste", 1, 0, DateTime.Now);
            Console.WriteLine(funcionario.Nome);
            Console.Read();
        }
    }
}
