import { AvaliacaoItem } from "./avaliacaoitem";
import { Servico } from "./servico";

export class Avaliacao{
    id : number;
    id_avaliacaoitem : number;
    id_servico : number;
    descricao : string;

    AvaliacaoItem : AvaliacaoItem;
    Servico : Servico;
}