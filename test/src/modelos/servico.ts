import { Usuario } from "./usuario";
import { Avaliacao } from "./avaliacao";
import { Promocao } from "./promocao";
import { Servico_Categoria } from "./servico_categoria";

export class Servico{
    Id : number;
    id_usuario : number;
    nome : string;
    descricao : string;
    localizacao : string;
    longitude : number;
    latitude: number;
    status: boolean;

    /*Avaliacao : Array<Avaliacao>;
    Promocao : Array<Promocao>;
    Servico_Categoria : Array<Servico_Categoria>;
    Usuario : Usuario;*/
}