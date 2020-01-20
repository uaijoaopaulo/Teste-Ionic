import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import 'rxjs/add/operator/do';

import { MyApp } from './app.component';
import { HomePage } from '../pages/home/home';
import { ListPage } from '../pages/list/list';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { SlidesPage } from '../pages/slides/slides';
import { ServicosPage } from '../pages/servicos/servicos';
import { LoginPage } from '../pages/login/login';
import { RecuperarsenhaPage } from '../pages/recuperarsenha/recuperarsenha';
import { SobrePage } from '../pages/sobre/sobre';
import { AjudaPage } from '../pages/ajuda/ajuda';
import { HttpModule } from '@angular/http';
import { UsuariosServiceProvider } from '../providers/usuario-service';
import { HttpClientModule } from '@angular/common/http';
import { ServicosProvider } from '../providers/servicos-service';
import { VisualizaServicoPage } from '../pages/visualiza-servico/visualiza-servico';

@NgModule({
  declarations: [
    MyApp,
    HomePage,
    ListPage,
    SlidesPage,
    ServicosPage,
    LoginPage,
    RecuperarsenhaPage,
    SobrePage,
    AjudaPage,
    VisualizaServicoPage
  ],
  imports: [
    BrowserModule,
    IonicModule.forRoot(MyApp),
    HttpClientModule
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    HomePage,
    ListPage,
    SlidesPage,
    ServicosPage,
    LoginPage,
    RecuperarsenhaPage,
    SobrePage,
    AjudaPage,
    VisualizaServicoPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    UsuariosServiceProvider,
    ServicosProvider
  ]
})
export class AppModule {}
