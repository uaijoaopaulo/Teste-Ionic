import {Servico} from './servico';
import { Recomendacao_Usuario } from './recomendacao_usuario';
import { Conta } from './conta';
import { AvaliacaoItem } from './avaliacaoitem';

export class Usuario{
    id : number;
    email: string;
    senha : string;
    tipousuario : string;
    nickname : string;
    status: Boolean;
    
    Conta : Conta;
    /*Servico : Array<Servico>;
    AvaliacaoItem : Array<AvaliacaoItem>; 
    Recomendacao_Usuario : Array<Recomendacao_Usuario>;*/
}