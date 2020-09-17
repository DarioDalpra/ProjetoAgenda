using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda_WPF.Utils
{
    class Valida
    {
        //FUNÇÃO VALIDA CPF
        public static bool ValidarCPF(string cpf)
        {
            int peso = 10, soma = 0, resto, digito1, digito2;
            //int multiplicacao;
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }
            //PRIMEIRO DÍGITO
            switch (cpf)
            {
                case "11111111111": return false;
                case "22222222222": return false;
                case "33333333333": return false;
                case "44444444444": return false;
                case "55555555555": return false;
                case "66666666666": return false;
                case "77777777777": return false;
                case "88888888888": return false;
                case "99999999999": return false;
                case "00000000000": return false;
            }
            for (int i = 0; i < 9; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * peso;
                //Console.WriteLine($"{cpf[i]} x {peso} = {multiplicacao}");
                peso--;
            }
            resto = soma % 11;
            if (resto < 2)
            {
                digito1 = 0;
            }
            else
            {
                digito1 = 11 - resto;
            }
            //TESTA O PRIMEIRO DÍGITO, SE FOR INVÁLIDO RETORNA FALSO
            if (Convert.ToInt32(cpf[9].ToString()) != digito1)
            {
                return false;
            }

            //SEGUNDO DÍGITO
            peso = 11;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += Convert.ToInt32(cpf[i].ToString()) * peso;
                //Console.WriteLine($"{cpf[i]} x {peso} = {multiplicacao}");
                peso--;
            }
            resto = soma % 11;
            if (resto < 2)
            {
                digito2 = 0;
            }
            else
            {
                digito2 = 11 - resto;
            }
            //TESTA O PRIMEIRO DÍGITO, SE FOR INVÁLIDO RETORNA FALSO
            if (Convert.ToInt32(cpf[10].ToString()) != digito2)
            {
                return false;
            }
            //Console.WriteLine($"{digito1}");
            //Console.WriteLine($"{digito2}");
            return true;
        }
    }
}