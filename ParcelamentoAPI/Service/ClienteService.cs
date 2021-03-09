using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Mock;
using ParcelamentoAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Service
{
    public class ClienteService:IClienteService
    {
        private readonly IClienteRepository _repositoryCliente;
        private readonly IConfiguracaoRepository _repositoryconfiguracao;


        public ClienteService(
            IClienteRepository repositoryCliente, IConfiguracaoRepository repositoryconfiguracao)
        {
            _repositoryCliente = repositoryCliente;
            _repositoryconfiguracao = repositoryconfiguracao;
            MockDados();
        }


        public ClienteDto Get(int idCliente)
        {

            var dto = _repositoryCliente.Get(idCliente);
            var configuracao = _repositoryconfiguracao.GetUltimaConfiguracao();
            dto.TelefoneNegociacao = configuracao.TelefoneContato;

            return dto;
        }


        private void MockDados() 
        {

            var clienteMock = DataMock.MockGetCliente1();
            _repositoryCliente.Add(clienteMock);
            var configMock = DataMock.MockGetConfiguracao();
            _repositoryconfiguracao.Add(configMock);
        }
    }
}
