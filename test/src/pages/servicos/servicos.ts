import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { ServicosProvider } from '../../providers/servicos-service';
import { Servico } from '../../modelos/servico';
import { VisualizaServicoPage } from '../visualiza-servico/visualiza-servico';

/**
 * Generated class for the ServicosPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-servicos',
  templateUrl: 'servicos.html',
})
export class ServicosPage {

  public servicos = new Array<Servico>();
  constructor(public navCtrl: NavController, public navParams: NavParams, private _ServicoService : ServicosProvider) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad ServicosPage');
    this.GetTodos();
  }

  VisualizaServico(entity : Servico){
    this.navCtrl.push(VisualizaServicoPage, entity);
  }

  GetTodos(){
    this._ServicoService.getAll().subscribe(data=>{
      this.servicos = (data as Servico[]);
    })
  }
}
