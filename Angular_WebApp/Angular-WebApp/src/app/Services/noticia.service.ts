import { Injectable } from "@angular/core";
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { NoticiaViewModel } from "../Models/NoticiaViewModel";
@Injectable(
    {
        providedIn: "root"
    }
)
export class NoticiaService{
    constructor(private httpClient : HttpClient){

    }

    private readonly baseUrl = environment["endPoint"] ;  

    ListarNoticias(){
        return this.httpClient.get<any>(`${this.baseUrl}/ListarNoticias`)
    }

    ListarNoticiasCustomizado(){
        return this.httpClient.get<Array<NoticiaViewModel>>(`${this.baseUrl}/ListarNoticiasCustomizado`)
    }

}