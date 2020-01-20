import { ItemAvaliacaoCategoria } from "./itemavaliacaocategoria";
import { Usuario } from "./usuario";
import { Avaliacao } from "./avaliacao";

export class AvaliacaoItem{
    Id : number;
    id_itemavaliacaocategoria : number;
    id_usuario : number;
    nota : number;

    Avaliacao : Array<Avaliacao>;
    ItemAvaliacaoCategoria : Array<ItemAvaliacaoCategoria>;
    Usuario : Usuario;
}