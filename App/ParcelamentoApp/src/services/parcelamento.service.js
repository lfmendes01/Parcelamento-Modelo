import http from "../http-common";

class ParcelamentoService {
  getCliente(id) {
    return http.get(`cliente/${id}`);
  }

  getCalculo(id,data) {
    return http.get(`parcelamento/parcelar/${id}/${data}`);
  }

  getDivida(id) {
    return http.get(`parcelamento/divida/${id}`);
  }

 
}

export default new ParcelamentoService();