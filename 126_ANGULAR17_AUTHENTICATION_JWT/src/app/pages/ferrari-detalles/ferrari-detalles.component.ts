import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { FerrariService } from '../../services/ferrari.service'; 
import { Ferrari } from '../../interfaces/ferrari'; 
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-ferrari-detalles',
  standalone: true,
  imports: [CommonModule, FormsModule, ReactiveFormsModule],
  templateUrl: './ferrari-detalles.component.html',
  styleUrl: './ferrari-detalles.component.css'
})
export class FerrariDetallesComponent {
  private router = inject(Router);
  route: ActivatedRoute = inject(ActivatedRoute);
  
  ferrari: Ferrari | undefined;
  ferrariService: FerrariService;

  constructor(ferrariService: FerrariService) {
    const ferrariId = parseInt(this.route.snapshot.params['id'], 10);
    ferrariService.getFerrariById(ferrariId).subscribe({
      next:(data) =>{
           if(data){
                  this.ferrari=data;
           }else{
                alert("Error")
           }
      },
      error:(error) =>{
           console.log(error.message);
      }
 })

    /*
    // RECIBIR DATOS EN CONSTRUCTOR CON PROMISE EN VEZ DE PARTIAL
    ferrariService.getFerrariById(ferrariId).then((ferrari) => {
      this.ferrari = ferrari;
    });
    */
   
    this.ferrariService=ferrariService;
  }


  async actualizarObjeto() {
    if (this.ferrari?.id) {
      try {
        var response = await this.ferrariService.updateFerrari(this.ferrari?.id, this.ferrari);
        if (response){
          alert('Objeto actualizado correctamente.');
        }
        else{
          alert('Hubo un error al actualizar el objeto.');
        }
        
      } catch (error) {
        console.error('Error al actualizar el objeto', error);
        
      }
    }
  }

  async eliminarObjeto() {
    if (this.ferrari?.id) {
      const confirmacion = confirm('¿Estás seguro de que deseas eliminar este objeto?');
      if (confirmacion) {
        try {
          await this.ferrariService.deleteFerrari(this.ferrari.id);
          alert('Objeto eliminado correctamente.');
          this.router.navigate(['inicio']);
        } catch (error) {
          console.error('Error al eliminar el objeto', error);
          alert('Hubo un error al eliminar el objeto.');
        }
      }
    }
  }

  goBack() {
    this.router.navigate(['inicio']);
  }
}