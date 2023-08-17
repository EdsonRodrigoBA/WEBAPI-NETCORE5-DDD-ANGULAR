import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoticiaViewModel } from 'src/app/Models/NoticiaViewModel';
import { NoticiaService } from 'src/app/Services/noticia.service';

@Component({
  selector: 'app-noticias',
  templateUrl: './noticias.component.html',
  styleUrls: ['./noticias.component.scss']
})

export class NoticiasComponent  {

  constructor( public router : Router, private noticiaService: NoticiaService ) { }

  noticias !: Array<NoticiaViewModel>;

  ngOnInit(): void {

    this.listarNoticiasCustomizada();
  }


  //lista as noticias de forma padrão
  listarNoticias() {
   // this.router.navigate(["/Login"]);

    this.noticiaService.ListarNoticias().subscribe({
      next: (noticia) => {
        this.noticias = noticia;
      },
      error(err) {
        

      },
      complete: () => {

        console.log("");
      },
    });

  }

  //lista as noticias com os dados completo
  listarNoticiasCustomizada() {
    // this.router.navigate(["/Login"]);
 
     this.noticiaService.ListarNoticiasCustomizado().subscribe({
       next: (noticia) => {
         this.noticias = noticia;
       },
       error(err) {
         
 
       },
       complete: () => {
 
         console.log("");
       },
     });
 
   }
}
