import { AvaliacaoItem } from "./avaliacaoitem";
import { Categoria } from "./categoria";

export class ItemAvaliacaoCategoria{
    id : number;
    id_categoria : number;
    nome : string;
    status : boolean;

    AvaliacaoItem : Array<AvaliacaoItem>;
    Categoria : Categoria;
}