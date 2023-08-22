import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutenticSaervice } from 'src/app/Services/Autentica.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit{
  constructor(private router : Router, private autenticaService : AutenticSaervice){
    

  }
  
  ngOnInit(): void {
  }

  sair(){
    this.autenticaService.LimparToken();
    this.router.navigate(["/login"]);
  }

  novaNoticia(){

    this.router.navigate(["/addnoticia"]);

  }

}
