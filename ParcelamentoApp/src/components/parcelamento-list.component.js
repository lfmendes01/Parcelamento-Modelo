import React, { Component } from "react";
import service from "../services/parcelamento.service";
import  DatePicker, { registerLocale }    from "react-datepicker";
 
import "react-datepicker/dist/react-datepicker.css";

import pt_BR from 'date-fns/locale/pt-BR';
registerLocale('pt-BR', pt_BR)

export default class TutorialsList extends Component {
  constructor(props) {
    super(props);
    this.onChange = this.onChange.bind(this);
    this.calcularParcelas = this.calcularParcelas.bind(this);
    this.dadosCliente = this.dadosCliente.bind(this);
    this.buscarDivida = this.buscarDivida.bind(this);
    
    this.state = {
      id: 1,
      divida: [],
      cliente:null,
      dataCalculo: new Date(),      
    };

  }

  componentDidMount() {
    this.dadosCliente();  
    this.buscarDivida();  
  }

  onChange(data) {

   this.setState({
    dataCalculo: data
    });
  }

  dadosCliente() {
    service.getCliente(this.state.id)
    .then(response => {
      this.setState({
        cliente: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  }

  buscarDivida() {
    service.getDivida(this.state.id)
    .then(response => {
      this.setState({
        divida: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  }

  calcularParcelas() {
    var dataCalculoString =new Date(this.state.dataCalculo).toJSON();

    service.getCalculo(this.state.id,dataCalculoString)
    .then(response => {
      this.setState({
        divida: response.data
      });
      console.log(response.data);
    })
    .catch(e => {
      console.log(e);
    });
  }

  render() {
    const { dataCalculo, cliente,divida } = this.state;
    return (
      <div className="list row">
         {cliente != null &&
            <div className="col-md-12 d-flex flex-row">
              <div className="col-md-4">
                  <label><b>Nome :</b></label>  {cliente.nome}
              </div>
              <div className="col-md-6">
                  <label><b>Telefone Negociação :</b></label>  {cliente.telefoneNegociacao}
              </div>
            </div>
         }

        <div className="col-md-12">
          <div className="input-group mb-3">
            <DatePicker
              className="form-control"
              placeholder="Data Calculo"
              dateFormat="dd/MM/yyyy"
              locale="pt-BR"
              selected={dataCalculo}
              onChange={date => this.onChange(date)}
            />
            <div className="input-group-append">
              <button
                className="btn btn-outline-secondary"
                type="button"
                onClick={this.calcularParcelas}
                
              >
                Calcular
              </button>
            </div>
          </div>
        </div>
        <div>
          { divida &&
              
              divida.map((item) => (
               
                <div>
                    <h4>Divida - Cod.: {item.idDivida}</h4>
                  <div className="col-md-12 d-flex flex-row">
                   <div className="col-md-10">
                    <label><b>Vencimento : </b></label>{new Date(item.dataVencimento).toLocaleDateString() } 
                   </div>
                   <div className="col-md-10">
                   <label><b>Valor Divida :</b></label> R$ {item.valorDivida.toFixed(2).replace('.',',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.')}
                   </div>
                   </div>
                   <div className="col-md-12 d-flex flex-row">
                     { item.diasAtraso &&
                   <div className="col-md-10">
                    <label><b>Dias Atraso :</b></label>  {item.diasAtraso}
                   </div>}
                   { item.valorJuros &&
                   <div className="col-md-10">
                     <label><b>Valor Juros :</b></label> R$ {item.valorJuros.toFixed(2).replace('.',',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.')}
                   </div>}
                   </div>
                   <div className="col-md-12 d-flex flex-row">
                   { item.numeroParcelas &&
                   <div className="col-md-10">
                     <label><b>Parcelado em :</b></label>  {item.numeroParcelas}
                   </div>}
                   { item.valorTotal &&
                   <div className="col-md-10">
                      <label><b>Valor Total :</b></label> R$ {item.valorTotal.toFixed(2).replace('.',',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.')}
                   </div>   
  } 
                   </div>  
                  
                 

          {item.parcelas &&
<div>
  <b>Parcelamento</b>
<br></br>
              <table className="table table-hover table-striped">
                    <thead>
                        <tr>
                            <th>Parcela</th>
                            <th>Data Vencimento</th>
                            <th>Valor</th>
                        </tr>
                    </thead>
                    <tbody>
                    {item.parcelas &&
                          item.parcelas.map((parcela) => (
                          
                            <tr key={parcela.numeroParcela}>
                              <td key={parcela.numeroParcela}>
                              {parcela.numeroParcela}
                            </td>
                            <td>
                            { new Date(parcela.dataVencimento).toLocaleDateString()}
                            </td>
                            <td>
                              R$ {parcela.valorParcela.toFixed(2).replace('.',',').replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1.')}
                            </td>
                            </tr>
                        ))}

               
                    </tbody>
                          </table>
                          </div>
                          }                 
                </div>
                
                
            ))}


         
        </div>
      </div>
    );
  }
}
