using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CarroDTO
    {
        private String Placa;
        
        public CarroDTO(String Param)
        {
            this.Placa = Param;
        }
        public string GetPlaca()
        {
            return Placa;
        }

        public void SetPlaca(string placa)
        {
            this.Placa = placa;
        }
    }
}
