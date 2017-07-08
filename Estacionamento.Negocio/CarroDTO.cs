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

        //Para comparar objetos através de um campo chave como a placa
        //é necessário sobrescrever o método Equals
        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            return this.Placa.Equals(((CarroDTO)obj).GetPlaca());
        }

        //Para utilizar como key em Dictionary e HashSet é importante que os objetos sejam 
        //comparados através de uma mesma chave retornem sem o mesmo valor hash.
        //Uma abordagem de solução é retornar o hash do campo comum
        public override int GetHashCode()
        {
            return Placa.GetHashCode();
        }


    }
}
