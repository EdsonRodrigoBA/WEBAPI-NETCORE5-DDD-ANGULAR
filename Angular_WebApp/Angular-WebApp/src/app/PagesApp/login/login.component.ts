import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { LoginModel } from 'src/app/Models/LoginModel';
import { AutenticSaervice } from 'src/app/Services/Autentica.service';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {


  loginForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router, public loginService: LoginService, private autenticaService : AutenticSaervice){}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({

      email:['', [Validators.required,Validators.email]],
      senha:['', [Validators.required]]

    });

    }
  submitLogin(){
    
    var dadosLogin = this.loginForm.getRawValue() as LoginModel;

    this.loginService.LoginUsuario(dadosLogin).subscribe({
      next: (value) => {
        this.autenticaService.DefineToken(value);
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

 /*
 Forma ensinada no curso   
    var dadosLogin = this.loginForm.getRawValue() as LoginModel;
    
    this.loginService.LoginUsuario(dadosLogin).subscribe(
      token => {
        debugger
        var nossoToken = token
      },
      erro =>{
        
      }
    );*/

  }
}
