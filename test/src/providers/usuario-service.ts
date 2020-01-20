import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from '../modelos/usuario';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UsuariosServiceProvider {

  private _usuarioLogado: Usuario;


  private API_URL = '/api/Usuario/';

  constructor(private http: HttpClient) {
    console.log('Hello UsuariosServiceProvider Provider');
  }

  efetuaLogin(_usuarioInformado) {
    let url = this.API_URL + 'Logar';
    return this.http.post<Usuario>(url, _usuarioInformado)
      .do((usuario: Usuario) => this._usuarioLogado = usuario);
  }

  recuperaSenha(email: string) {
    let url = this.API_URL + 'RecuperarSenha/' + email;
    return this.http.get<boolean>(url);
  }

  cadastraUsuario(usuario: Usuario) {
    let url = this.API_URL + 'Save';
    return this.http.post<boolean>(url, usuario)/*.subscribe(data => {
      if (data)
        this._usuarioLogado = usuario;
    })*/;

    /*return new Promise((resolve, reject) => {
      
      let url = this.API_URL+'Create';

      this.http.post(url,usuario) 

     .subscribe((result: any) => {
      resolve(result.json())
      },
      (error)=> {
        reject(error.json());
      })
    }); */
  }


  obtemUsuarioLogado() {
    return this._usuarioLogado;
  }





}
