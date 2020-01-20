import { Servico } from "./servico";
import { Categoria } from "./categoria";

export class Servico_Categoria{
    id : number;
    id_servico : number;
    id_categoria : number;

    Categoria : Categoria;
    Servico : Servico;
}