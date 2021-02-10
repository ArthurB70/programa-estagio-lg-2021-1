﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LGProgramaDeEstagio2021
{
    public class FichaCadastral
    {
        private RepositorioFuncionario repositorioFuncionario;

        public FichaCadastral(RepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public void CadastraFuncionario(string nome,
            float salarioContratual,
            DateTime dataAdmissao,
            EnumTipoFuncionario enumTipoFuncionario)
        {
            SalveFuncionario(nome, salarioContratual, dataAdmissao, enumTipoFuncionario, null);
        }

        private bool ValidaDataAdmissao(DateTime dataAdmissao)
            => dataAdmissao > DateTime.Now;

        private bool ValidaSalarioContratual(float salarioContratual)
            => salarioContratual <= 0;
       
        private bool ValidaNome(string nome)
            => string.IsNullOrEmpty(nome);

        public void CadastraFuncionario(string nome, 
            float salarioContratual, 
            DateTime dataAdmissao, 
            EnumTipoFuncionario enumTipoFuncionario,
            CNH cnh)
        {
            SalveFuncionario(nome, salarioContratual, dataAdmissao, enumTipoFuncionario, cnh);

        }

        private void SalveFuncionario(string nome, 
            float salarioContratual,
            DateTime dataAdmissao, 
            EnumTipoFuncionario enumTipoFuncionario, 
            CNH cnh)
        {
            if (ValidaNome(nome))
                throw new ArgumentException();

            if (ValidaSalarioContratual(salarioContratual))
                throw new ArgumentException();

            if (ValidaDataAdmissao(dataAdmissao))
                throw new ArgumentException();

            if (ValidaCNH(cnh))
                throw new ArgumentException();

            Funcionario funcionario = null;

            switch (enumTipoFuncionario)
            {
                case EnumTipoFuncionario.AUTONOMO:
                    funcionario = new FuncionarioAutonomo(nome, 0, salarioContratual, dataAdmissao);
                    break;

                case EnumTipoFuncionario.CLT:
                    funcionario = new FuncionarioCLT(nome, 0, salarioContratual, dataAdmissao);
                    break;

                case EnumTipoFuncionario.PROLABORE:
                    funcionario = new FuncionarioProlabore(nome, 0, salarioContratual, dataAdmissao);
                    break;

            }
            repositorioFuncionario.Insert(funcionario);
        }

        private bool ValidaCNH(CNH cnh)
            => !(cnh == null || (cnh.Numero > 0 && cnh.DataValidade != default(DateTime)));
       
    }
}
