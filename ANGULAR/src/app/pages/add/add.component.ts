import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { FerrariService } from '../../services/ferrari.service';
import { Ferrari } from '../../interfaces/ferrari';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [MatCardModule,MatFormFieldModule,MatInputModule,MatButtonModule,ReactiveFormsModule],
  templateUrl: './add.component.html',
  styleUrl: './add.component.css'
})
export class AddComponent {
      private ferrariService = inject(FerrariService);
       private router = inject(Router);
       public formBuild = inject(FormBuilder);
  
       public formAdd: FormGroup = this.formBuild.group({
            name: ['',Validators.required],
            image: ['',Validators.required],
            description: ['',Validators.required],
            anoSalida: ['',Validators.required],
            cv: ['',Validators.required],
            precioEstimado: ['',Validators.required],
            pujaInicial: ['',Validators.required],
       })
  
       
       async add(){
        const ferrari:Ferrari = {
                       id:0,
                       name: this.formAdd.value.name,
                       image: this.formAdd.value.image,
                       description: this.formAdd.value.description,
                       anoSalida: this.formAdd.value.anoSalida,
                       cv: this.formAdd.value.cv,
                       precioEstimado: this.formAdd.value.precioEstimado,
                       pujaInicial: this.formAdd.value.pujaInicial
                  }
        var response = await this.ferrariService.createFerrari(ferrari)
        if (response){
          this.router.navigate(['inicio'])
        }
        else{
          alert("Error post")
        }
   }
       volver(){
            this.router.navigate(['inicio'])
       }

}
