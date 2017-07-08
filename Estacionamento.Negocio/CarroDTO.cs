using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class CarroDTO:IComparable
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

        public int CompareTo(object obj)
        {
            return ((CarroDTO)obj).GetPlaca().Equals(this.Placa) ? 1 : 0;
        }
    }
}
