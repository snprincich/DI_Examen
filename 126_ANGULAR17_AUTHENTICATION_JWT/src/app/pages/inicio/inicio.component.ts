import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatCardModule } from '@angular/material/card'
import { MatTableModule } from '@angular/material/table'

import { FerrariService } from '../../services/ferrari.service';
import { Ferrari } from '../../interfaces/ferrari';
import { FerrariComponent } from "../../component/ferrari/ferrari.component";
import { Router } from '@angular/router';

@Component({
     selector: 'app-inicio',
     standalone: true,
     imports: [CommonModule ,FerrariComponent],
     templateUrl: './inicio.component.html',
     styleUrl: './inicio.component.css'
})
export class InicioComponent {
     private router = inject(Router);

     private ferrariServicio = inject(FerrariService)
     public listaFerrari: Ferrari[] = []

     constructor() {
          this.ferrariServicio.lista().subscribe({
               next: (data) => {
                    if (data.length > 0) {
                         this.listaFerrari = data;
                    }
               },
               error: (err) => {
                    console.log(err.message);
               }
          })
     }

     logout() {
          localStorage.setItem("token",'')
          this.router.navigate(['']);
        }
     add() {

          this.router.navigate(['add']);
     }
}
