using ParcelamentoAPI.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Mock
{
    public static class DataMock
    {
        public static ConfiguracaoDto MockGetConfiguracao()
        {
            ConfiguracaoDto dto = new ConfiguracaoDto()
            {
                Id = 1,
                ComissaoPorcentagem = 10,
                JurosSimples = true,
                Juros = 0.2d,
                MaximoParcelas = 3,
                TelefoneContato = "(11)1234-4567"
            };

            return dto;
        }


        public static ClienteDto MockGetCliente1()
        {
            ClienteDto dto = new ClienteDto()
            {
                Id = 1,
                Nome = "José Alberto"
            };

            return dto;
        }

        public static ClienteDto MockGetCliente2()
        {
            ClienteDto dto = new ClienteDto()
            {
                Id = 2,
                Nome = "Lucio Jose",
            };

            return dto;
        }

        public static List<ClienteDividaDto> MockGetDivida()
        {
            List<ClienteDividaDto> dto = new List<ClienteDividaDto>();
            dto.Add(new ClienteDividaDto()
            {
                DataVencimento = new DateTime(2019, 3, 1),
                IdCliente = 1,
                IdDivida = 1,
                ValorDivida = 3000
            });

            return dto;
        }
    }
}
