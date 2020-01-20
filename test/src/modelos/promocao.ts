import { DateTime } from "ionic-angular";
import { Servico } from "./servico";

export class Promocao{
    id : number;
    id_servico : number;
    datainicio : DateTime;
    datafim : DateTime;
    descricao : string;
    status : boolean;

    Servico : Servico;
}