import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController } from 'ionic-angular';
import { RecuperarsenhaPage } from '../recuperarsenha/recuperarsenha';
import { UsuariosServiceProvider } from '../../providers/usuario-service';
import { Usuario } from '../../modelos/usuario';
import { ServicosPage } from '../servicos/servicos';

/**
 * Generated class for the LoginPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-login',
  templateUrl: 'login.html',
})
export class LoginPage {

  private _usuarioInformado : Usuario = new Usuario();

  constructor(public navCtrl: NavController, public navParams: NavParams, 
    private _usuarioService : UsuariosServiceProvider, private _alertCtrl : AlertController) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoginPage');
  }
  /*presentToast(position: string, text: string) {
    let toast = this.toastCtrl.create({
      duration: 2000,
      position: position,
      message : text
    });

    toast.present(toast);
  }*/
  recuperarSenha(){
    this.navCtrl.push(RecuperarsenhaPage);
  }
  efetuaLogin(){
    this._usuarioService.efetuaLogin(this._usuarioInformado).subscribe(usuario=>{
      console.log(usuario as Usuario);
      if(usuario.status){ 
        this.navCtrl.setRoot(ServicosPage);
      }
    },
    () => {
      this._alertCtrl.create({

        title : 'Falha no Login', 
        subTitle : 'Email ou senha incorretos ! Verifique!', 
        buttons: [
          { text : 'Ok'}
        ]
      }).present();
    }
  );

                                          /*this._alertCtrl.create({
  
                                            title : 'Falha no Login', 
                                            subTitle : 'Email ou senha incorretos ! Verifique!', 
                                            buttons: [
                                              { text : 'Ok'}
                                            ]
                                          }).present();
                                        }*/                           
  }
}
