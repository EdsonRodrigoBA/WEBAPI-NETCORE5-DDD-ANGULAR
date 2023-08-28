import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './PagesApp/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NoticiasComponent } from './PagesApp/noticias/noticias.component';
import { NavbarComponent } from './Components/navbar/navbar.component';
import { Interceptor } from './Interceptor/interceptor';
import { AddNoticiaComponent } from './PagesApp/add-noticia/add-noticia.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

const serviceAutentica = [Interceptor]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NoticiasComponent,
    NavbarComponent,
    AddNoticiaComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSpinnerModule,
    BrowserAnimationsModule

  ],
  providers: [
    serviceAutentica,
    {
      provide : HTTP_INTERCEPTORS, useClass: Interceptor, multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
