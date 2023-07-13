import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { LoginModel } from 'src/app/Models/LoginModel';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {


  loginForm!: FormGroup;
  constructor(private formBuilder: FormBuilder, private router: Router){}

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({

      email:['', [Validators.required,Validators.email]],
      senha:['', [Validators.required]]

    });

    }
  submitLogin(){

    debugger
    var dadosLogin = this.loginForm.getRawValue() as LoginModel;
    
  }
}
