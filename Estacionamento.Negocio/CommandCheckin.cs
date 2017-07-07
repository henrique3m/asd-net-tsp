using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CommandCheckin : ICommand
    {
        public Double Run(String Param)
        {
            Validate(Param);
            Estacionamento.GetInstance().AddPlaca(Param);
            return 0.0;
        }

        public bool Validate(String Param)
        {
            if (String.Equals(Param.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", Param));

            if (Estacionamento.GetInstance().EstacionamentoCheio())
                throw new Exception("Estacionamento cheio!");

            if (Estacionamento.GetInstance().ContemPlaca(Param))
                throw new Exception(String.Format("Carro placa '{0} já existe!", Param));

            return true;
        }
    }
}
