import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController } from 'ionic-angular';
import { Servico } from '../../modelos/servico';

/**
 * Generated class for the VisualizaServicoPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-visualiza-servico',
  templateUrl: 'visualiza-servico.html',
})
export class VisualizaServicoPage {

  public servico = new Servico();

  constructor(public navCtrl: NavController, public navParams: NavParams, public alertCtrl: AlertController) {
    this.servico = navParams.data;
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad VisualizaServicoPage');
  }

  showCheckbox() {
    let alert = this.alertCtrl.create();
    alert.setTitle('Telefones para contato:');

    alert.addInput({
      type: 'checkbox',
      label: 'Alderaan',
      value: 'value1',
      checked: true
    });

    alert.addInput({
      type: 'checkbox',
      label: 'Bespin',
      value: 'value2'
    });

    alert.addButton('Cancel');
    alert.addButton({
      text: 'Okay',
      handler: data => {
        console.log('Checkbox data:', data);
        //this.testCheckboxOpen = false;
        //this.testCheckboxResult = data;
      }
    });
    alert.present();
  }
}
