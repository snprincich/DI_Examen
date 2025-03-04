import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegistroComponent } from './pages/registro/registro.component';
import { InicioComponent } from './pages/inicio/inicio.component';
import { authGuard } from './custom/auth.guard';
import { FerrariDetallesComponent } from './pages/ferrari-detalles/ferrari-detalles.component';
import { PageNotFoundComponent } from './pages/page-not-found/page-not-found.component';
import { AddComponent } from './pages/add/add.component';

export const routes: Routes = [
     {path:"", component:LoginComponent},
     {path:"registro", component:RegistroComponent},
     {path:"inicio", component:InicioComponent , canActivate:[authGuard]},
     {path:"detalles/:id", component:FerrariDetallesComponent , canActivate:[authGuard]},
     {path:"add", component:AddComponent, canActivate:[authGuard]},
     {path: '**', component: PageNotFoundComponent},
];
