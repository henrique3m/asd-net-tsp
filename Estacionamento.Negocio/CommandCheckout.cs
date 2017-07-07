using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CommandCheckout : ICommand
    {
        public Object Run(Object Param)
        {
            Validate(((CarroDTO)Param).GetPlaca());
            DateTime horaEntrada = Estacionamento.GetInstance().GetTime(((CarroDTO)Param).GetPlaca());

            Estacionamento.GetInstance().RemovePlaca(((CarroDTO)Param).GetPlaca());

            return CalcularValorEstacionamento(horaEntrada, DateTime.Now);

        }

        public bool Validate(Object Param)
        {
            if (String.Equals(((CarroDTO)Param).GetPlaca().Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", Param));

            if (!Estacionamento.GetInstance().ContemPlaca(((CarroDTO)Param).GetPlaca()))
                throw new Exception(String.Format("Carro placa '{0}' NÃO existe!", Param));

            return true;
        }

        private double CalcularValorEstacionamento(DateTime entrada, DateTime saida)
        {
            var permanencia = saida.Subtract(entrada);
            return Math.Round((permanencia.TotalMinutes / 3), 2); // 3 reais é o valor mínimo
        }
    }
}
