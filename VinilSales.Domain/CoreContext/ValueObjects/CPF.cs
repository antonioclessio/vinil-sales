using System;
using VinilSales.Domain.CoreContext.Interfaces;

namespace VinilSales.Domain.CoreContext.ValueObjects
{
    public class CPF : IValueObjects
    {
        private string _value;

        public CPF(string value)
        {
            this._value = value;
        }

        public string CPFFormatado
        {
            get
            {
                return Convert.ToUInt64(_value).ToString(@"000\.000\.000\-00");
            }
        }

        public int Length
        {
            get
            {
                return _value.Length;
            }
        }

        public bool isValid()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            _value = _value.Trim();
            _value = _value.Replace(".", "").Replace("-", "");
            if (_value.Length != 11)
                return false;
            tempCpf = _value.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return _value.EndsWith(digito);
        }

        public override string ToString()
        {
            return _value;
        }
    }
}
