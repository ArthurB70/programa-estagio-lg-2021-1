﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGProgramaDeEstagio2021
{
    public class FuncionarioAutonomo : Funcionario
    {
        public FuncionarioAutonomo(string nome, int matricula, float salarioContratual, DateTime dataAdmissao) : 
            base(nome, matricula, salarioContratual, dataAdmissao)
        {
        }
    }
}
