using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class Estacionamento
    {
        private const int VAGAS_TOTAIS = 15;
        private static IDictionary<String, DateTime> _estacionamento = new Dictionary<String, DateTime>();
        private static Estacionamento Instance = null;

        public static Estacionamento GetInstance()
        {
            if (Instance != null)
                return Instance;

            Instance = new Estacionamento();
            return Instance;
        }

        public bool Cheio()
        {
            return _estacionamento.Count == VAGAS_TOTAIS;
        }

        public bool ContemCarro(CarroDTO carro) {
            return _estacionamento.ContainsKey(carro.GetPlaca());
        }   

        public void EntradaCarro(CarroDTO carro)
        {            
            _estacionamento.Add(carro.GetPlaca(), DateTime.Now);
        }

        public double SaidaCarro(CarroDTO carro)
        {
            DateTime horaEntrada = _estacionamento[carro.GetPlaca()];
            _estacionamento.Remove(carro.GetPlaca());
            return CalculaValor(horaEntrada);
        }

        private double CalculaValor(DateTime HoraEntrada)
        {            
            var permanencia = DateTime.Now.Subtract(HoraEntrada);
            return Math.Round((permanencia.TotalMinutes / 3), 2); // 3 reais é o valor mínimo
        }
    }
}
