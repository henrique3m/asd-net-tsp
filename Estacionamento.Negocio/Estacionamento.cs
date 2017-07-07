using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    class Estacionamento
    {
        private const int VAGAS_TOTAIS = 15;
        private static IDictionary<string, DateTime> _estacionamento = new Dictionary<string, DateTime>();
        private static Estacionamento Instance = null;

        public static Estacionamento GetInstance()
        {
            if (Instance != null)
                return Instance;

            Instance = new Estacionamento();
            return Instance;
        }

        public int TotalVagas()
        {
            return VAGAS_TOTAIS;
        }

        public int CountVagas()
        {
            return _estacionamento.Count;
        }

        public bool EstacionamentoCheio()
        {
            return _estacionamento.Count == VAGAS_TOTAIS;
        }

        public bool ContemPlaca(String placa) {
            return _estacionamento.ContainsKey(placa);
        }   

        public void AddPlaca(String placa)
        {
            _estacionamento.Add(placa, DateTime.Now);
        }

        public void RemovePlaca(String placa)
        {
            _estacionamento.Remove(placa);
        }

        public DateTime GetTime(String placa)
        {
            return _estacionamento[placa];
        }
    }
}
