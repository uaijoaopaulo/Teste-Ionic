import { Servico_Categoria } from "./servico_categoria";
import { ItemAvaliacaoCategoria } from "./itemavaliacaocategoria";

export class Categoria{
    id : number;
    nome : string;
    status : boolean;

    ItemAvaliacaoCategoria : Array<ItemAvaliacaoCategoria>;
    Servico_Categoria : Array<Servico_Categoria>;
}