using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Mock;
using ParcelamentoAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Service
{
    public class ParcelamentoService:IParcelamentoService
    {
        private readonly IConfiguracaoRepository _repositoryconfig;
        private readonly IClienteRepository _repositoryCliente;
        private readonly IDividaRepository _repositoryDivida;
        private readonly IParcelamentoRepository _repositoryParcelamento;


        public ParcelamentoService(IConfiguracaoRepository repositoryconfig,
            IClienteRepository repositoryCliente, IDividaRepository repositoryDivida, IParcelamentoRepository repositoryParcelamento)
        {
            _repositoryconfig = repositoryconfig;
            _repositoryCliente = repositoryCliente;
            _repositoryDivida = repositoryDivida;
            _repositoryParcelamento = repositoryParcelamento;
            MockDados();
        }


        public List<ClienteParcelamentoDto> CalcularParcelamento(int idCliente, DateTime dataCalculo)
        {
            List<ClienteParcelamentoDto> parcelamento = new List<ClienteParcelamentoDto>();

            var dividas = _repositoryDivida.GetByIdCliente(idCliente);

            foreach (var divida in dividas)
            {
                ClienteParcelamentoDto dto = new ClienteParcelamentoDto();

                dto.DataVencimento = divida.DataVencimento;
                dto.ValorDivida = divida.ValorDivida;
                dto.IdDivida = divida.IdDivida;

                var configuracao = _repositoryconfig.GetUltimaConfiguracao();

                dto.DiasAtraso = Convert.ToInt32((dataCalculo - dto.DataVencimento).TotalDays);

                if (configuracao.JurosSimples)
                {
                    dto.ValorJuros = CalcularJurosSimples(dto.ValorDivida, configuracao.Juros, dto.DiasAtraso);

                    dto.ValorTotal = dto.ValorDivida + dto.ValorJuros;
                    var valorParcela = dto.ValorTotal / configuracao.MaximoParcelas;           

                    for (byte n = 1; n <= configuracao.MaximoParcelas; n++)
                    {
                        dto.Parcelas.Add(new ParcelasDto()
                        {
                            NumeroParcela = n,
                            ValorParcela = valorParcela,
                            DataVencimento = dataCalculo.AddMonths(n).AddDays(1)
                        });
                    }
                    dto.NumeroParcelas = dto.Parcelas.Count();
                }

                parcelamento.Add(dto);
            }

            return parcelamento;
        }

        private double CalcularJurosSimples(double valor, double jurosDia, int diasAtraso)
        {
            var resultado = valor * jurosDia / 100 * diasAtraso;
            return resultado;
        }

        private double CalcularComissao(double valorTotal)
        {
            var configuracao = _repositoryconfig.GetUltimaConfiguracao();
            var valorComissao = valorTotal * configuracao.ComissaoPorcentagem / 100;
            return valorComissao;
        }


        public List<ClienteDividaDto> Divida(int idCliente) 
        {
            var dto = _repositoryDivida.GetByIdCliente(idCliente);

            return dto;
        
        }

        private void SalvarParcelas(List<ParcelasDto> dto)
        {
            foreach (var parcela in dto)
            {
                _repositoryParcelamento.Add(parcela);
            }
        }

        public void AtualizarDivida(ClienteParcelamentoDto dto)
        {
            dto.ValorComissao = CalcularComissao(dto.ValorTotal);

            _repositoryDivida.Update(dto);
        }

        public void SalvarParcelamento(ClienteParcelamentoDto dto)
        {
            AtualizarDivida(dto);

            SalvarParcelas(dto.Parcelas);

        }

        private void MockDados() 
        {
            var configuracaoMock = DataMock.MockGetConfiguracao();
            _repositoryconfig.Add(configuracaoMock);

            var clienteMock = DataMock.MockGetCliente1();
            _repositoryCliente.Add(clienteMock);

            var dividaMock = DataMock.MockGetDivida();
            foreach (var divida in dividaMock)
            {
               _repositoryDivida.Add(divida);
            }
        }
    }
}
