import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NoticiaService } from 'src/app/Services/noticia.service';

@Component({
  selector: 'app-noticias',
  templateUrl: './noticias.component.html',
  styleUrls: ['./noticias.component.scss']
})

export class NoticiasComponent  {

  constructor( public router : Router, private noticiaService: NoticiaService ) { }

  noticias !: any;

  ngOnInit(): void {

    this.listarNoticias();
  }

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
}
