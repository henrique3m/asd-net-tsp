using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CommandCheckout : ICommand
    {
        Estacionamento estacionamento = null;
        public CommandCheckout()
        {
            estacionamento = Estacionamento.GetInstance();
        }

        public Object Run(CarroDTO Param)
        {
            Validate(Param);         
            return estacionamento.SaidaCarro(Param);
        }

        public bool Validate(CarroDTO Param)
        {
            if (String.Equals(Param.GetPlaca().Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", Param));

            if (!estacionamento.ContemCarro(Param))
                throw new Exception(String.Format("Carro placa '{0}' NÃO existe!", Param.GetPlaca()));

            return true;
        }
    }
}
