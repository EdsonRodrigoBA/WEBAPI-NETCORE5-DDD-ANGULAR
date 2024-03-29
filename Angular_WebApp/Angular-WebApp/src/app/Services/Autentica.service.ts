import { Injectable } from "@angular/core";

@Injectable({
    providedIn: 'root'
})

export class AutenticSaervice {

    private autenticado : boolean = false;


    public DefineToken(token : string){

        sessionStorage.setItem('token',token);
    }

    public ObterToken(){
        
        return sessionStorage.getItem('token');
    }

    
    public LimparToken(){
        
        sessionStorage.removeItem('token')
    }
}