import { Conta } from "./conta";

export class Endereco {
    Id : number;
    id_conta : number;
    rua : string;
    numero : string;
    bairro : string;
    cidade : string;
    cep : number;

    Conta : Conta;
}