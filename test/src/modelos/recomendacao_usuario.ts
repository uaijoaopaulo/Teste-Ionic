import { Usuario } from "./usuario";

export class Recomendacao_Usuario{
    id : number;
    id_usuario : number;
    email : string;
    comentario : string;
    nota : number;

    Usuario : Usuario;
}