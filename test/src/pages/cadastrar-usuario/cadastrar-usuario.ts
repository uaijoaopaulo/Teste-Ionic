import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController } from 'ionic-angular';
import { Usuario } from '../../modelos/usuario';
import { UsuariosServiceProvider } from '../../providers/usuario-service';
import { Conta } from '../../modelos/conta';

/**
 * Generated class for the CadastrarUsuarioPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-cadastrar-usuario',
  templateUrl: 'cadastrar-usuario.html',
}) 
export class CadastrarUsuarioPage {

  private _usuarioCadastrar : Usuario = new Usuario();
  private _ContaCadastrar : Conta = new Conta();

  constructor(public navCtrl: NavController, public navParams: NavParams, 
    private _usuarioService : UsuariosServiceProvider, private _alertCtrl : AlertController) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad CadastrarUsuarioPage');
  }
 
  cadastrarUsuario(){


    this._usuarioService.cadastraUsuario(this._usuarioCadastrar).subscribe((resultado : boolean)=>{
      if(resultado){
        this._alertCtrl.create({
          title : 'Cadastrado com Sucesso!', 
          subTitle : 'Aproveite o $ist³mA', 
          buttons: [
            { text : 'Ok'}
          ]
        }).present();
        this.navCtrl.pop();
      }else if(!resultado){
        this._alertCtrl.create({
          title : 'Falha ao cadastrar', 
          subTitle : 'Algo de Er#adO não está $erto.', 
          buttons: [
            { text : 'Ok'}
          ]
        }).present();
      }
    });
  }
}
