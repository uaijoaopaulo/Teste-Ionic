import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Servico } from '../modelos/servico';

/*
  Generated class for the ServicosProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class ServicosProvider {

    
  private API_URL = '/api/Servico';
  constructor(public http: HttpClient) {
    console.log('Hello ServicosProvider Provider');
  }

  getAll(){
    let url = this.API_URL + "/Search";
    return this.http.get<Servico[]>(url)
  }
}
