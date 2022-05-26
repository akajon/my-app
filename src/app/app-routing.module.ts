import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ListaComponent } from './lista/lista.component';

const routes: Routes = [
{ path: '', component: LoginComponent},
{ path: 'navigation', component: NavigationComponent},
{ path: 'home', component: HomeComponent},
{ path: 'register', component: RegisterComponent},
{ path: 'lista', component: ListaComponent},
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule{}