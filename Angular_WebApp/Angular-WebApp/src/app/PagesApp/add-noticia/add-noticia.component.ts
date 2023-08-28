import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NoticiaViewModel } from 'src/app/Models/NoticiaViewModel';
import { NoticiaService } from 'src/app/Services/noticia.service';

@Component({
  selector: 'app-add-noticia',
  templateUrl: './add-noticia.component.html',
  styleUrls: ['./add-noticia.component.scss']
})
export class AddNoticiaComponent implements OnInit {

  addNoticiaForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router,private noticiaService: NoticiaService ) { }


  ngOnInit(): void {
    this.addNoticiaForm = this.formBuilder.group({

      titulo: ['', [Validators.required, Validators.required]],
      informacao: ['', [Validators.required]]

    });
  }

  submitAddNoticia(){

    const dadosNoticiaForm = this.addNoticiaForm.getRawValue() as NoticiaViewModel;

    var noticia = new NoticiaViewModel();
    noticia.titulo = dadosNoticiaForm.titulo;
    noticia.informacao = dadosNoticiaForm.informacao;

    this.noticiaService.AdicionarNoticia(noticia).subscribe({
      next: (value) => {
        this.router.navigate(["/noticias"]);
        //console.log(value);
      },
      error(err) {
        
        console.log(err);
      },
      complete: () => {

        console.log("");
      },
    }); 

  }

}
