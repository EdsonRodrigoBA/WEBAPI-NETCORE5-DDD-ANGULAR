import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './PagesApp/login/login.component';
import { NoticiasComponent } from './PagesApp/noticias/noticias.component';

const routes: Routes = [
  {
    path:"",
    pathMatch:"full",
    redirectTo:"login"
  },
  {
    path:"login",
    component:LoginComponent
  },
  {
    path:"noticias",
    component:NoticiasComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
