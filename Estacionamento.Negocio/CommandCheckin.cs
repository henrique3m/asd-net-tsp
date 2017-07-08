using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CommandCheckin : ICommand
    {

        Estacionamento estacionamento = null;
        public CommandCheckin()
        {
            estacionamento = Estacionamento.GetInstance();
        }

        public Object Run(CarroDTO Param)
        {
            Validate(Param);
            estacionamento.EntradaCarro(Param);
            return true;
        }

        public bool Validate(CarroDTO Param)
        {
            if (String.Equals(Param.GetPlaca().Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", Param));

            if (estacionamento.Cheio())
                throw new Exception("Estacionamento cheio!");

            if (estacionamento.ContemCarro(Param))
                throw new Exception(String.Format("Carro placa '{0} já existe!", Param.GetPlaca()));

            return true;
        }
    }
}
