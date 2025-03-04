import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AccesoService } from '../../services/acceso.service';
import { Router } from '@angular/router';

import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import { Registro } from '../../interfaces/registro';



@Component({
  selector: 'app-registro',
  standalone: true,
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule],
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {

     private accesoService = inject(AccesoService);
     private router = inject(Router);
     public formBuild = inject(FormBuilder);

     public formRegistro: FormGroup = this.formBuild.group({
          name: ['',Validators.required],
          username: ['',Validators.required],
          email: ['',Validators.required],
          password: ['',Validators.required]
     })

     registrarse(){
          if(this.formRegistro.invalid) return;


          const objeto:Registro = {
               name: this.formRegistro.value.name,
               userName: this.formRegistro.value.username,
               email: this.formRegistro.value.email,
               password: this.formRegistro.value.password,
               role: 'admin',
          }

          this.accesoService.registrarse(objeto).subscribe({
               next: (data) =>{
                    if(data.isSuccess){
                         this.router.navigate([''])
                    }else{
                         alert("No se pudo registrar")
                    }
               }, error:(error) =>{
                    console.log(error.message);
               }
          })

     }

     volver(){
          this.router.navigate([''])
     }

}
