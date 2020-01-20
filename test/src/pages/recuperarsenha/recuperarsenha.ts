import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController } from 'ionic-angular';
import { UsuariosServiceProvider } from '../../providers/usuario-service';

/**
 * Generated class for the RecuperarsenhaPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-recuperarsenha',
  templateUrl: 'recuperarsenha.html',
})
export class RecuperarsenhaPage {
  data: string = "";
  constructor(public navCtrl: NavController, public navParams: NavParams,
    private _usuarioService: UsuariosServiceProvider, private _alertCtrl: AlertController) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad RecuperarsenhaPage');
  }

  enviaEmail() {
    this._usuarioService.recuperaSenha(this.data).subscribe(resp => {
      console.log(resp as boolean);
      if (resp) {
        this.data = "";
        this._alertCtrl.create({
          title: 'Email Enviado',
          subTitle: 'Confira sua caixa de mensagem',
          buttons: [
            { text: 'Ok' }
          ]
        }).present();
        this.navCtrl.pop();
      } else {
        this.data = "";
        this._alertCtrl.create({
          title: 'Email Não Enviado',
          subTitle: 'Não encontramos esse Email ou Usuario em nosso sistema.',
          buttons: [
            { text: 'Ok' }
          ]
        }).present();
      }
    })
  }

}
