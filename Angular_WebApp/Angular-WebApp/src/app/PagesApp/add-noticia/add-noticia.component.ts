import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-noticia',
  templateUrl: './add-noticia.component.html',
  styleUrls: ['./add-noticia.component.scss']
})
export class AddNoticiaComponent implements OnInit {

  addNoticiaForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router) { }


  ngOnInit(): void {
    this.addNoticiaForm = this.formBuilder.group({

      titulo: ['', [Validators.required, Validators.required]],
      informacao: ['', [Validators.required]]

    });
  }

  submitAddNoticia(){

    const dadosNoticiaForm = this.addNoticiaForm.getRawValue();
    debugger
    this.router.navigate(["/noticias"]);

  }

}