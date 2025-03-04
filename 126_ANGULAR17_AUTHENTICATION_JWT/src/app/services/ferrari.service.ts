import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../settings/appsettings';
import { Observable } from 'rxjs';
import { Ferrari } from '../interfaces/ferrari';

@Injectable({
     providedIn: 'root'
})
export class FerrariService {
     private http = inject(HttpClient);
     private baseUrl: string = appsettings.base_url;
     constructor() { }

     lista() : Observable<Ferrari[]>{
          return  this.http.get<Ferrari[]>(`${this.baseUrl}${appsettings.ferrari_url}`)
       }

       private getAuthHeaders(): { [key: string]: string } {
          const token = localStorage.getItem('token');
          return {
            'Authorization': `Bearer ${token}`,
            'Content-Type': 'application/json'
          };
        }

      /*
       async getFerrariById(id: number): Promise<Ferrari | undefined> {
          const response = await fetch(`${this.baseUrl}${appsettings.ferrari_url}/${id}`, {
            method: 'GET',
            headers: this.getAuthHeaders()
          });
          return (await response.json()) as Ferrari | undefined;
        }
      */

        getFerrariById(id: number): Observable<Ferrari> {
          return this.http.get<Ferrari>(`${this.baseUrl}${appsettings.ferrari_url}/${id}`);
        }



        async updateFerrari(id: number, product: Ferrari): Promise<Ferrari | undefined> {
          const response = await fetch(`${this.baseUrl}${appsettings.ferrari_url}/${id}`, {
            method: "PATCH",
            headers: this.getAuthHeaders(),
            body: JSON.stringify(product)
          });
          if (response.ok){
            return await response.json();
          }
          else{
            alert(response.status)
          }
          return undefined;
        }
      
        async createFerrari(product: Ferrari): Promise<Ferrari | undefined> {
          const response = await fetch(`${appsettings.base_url}${appsettings.ferrari_url}`, {
            method: "POST",
            headers: this.getAuthHeaders(),
            body: JSON.stringify(product)
          });
      
          if (response.ok){
            return await response.json();
          }
          else{
            alert(response.status)
          }
          return undefined;
        }
        
        async deleteFerrari(id: number): Promise<boolean> {
          const response = await fetch(`${appsettings.base_url}${appsettings.ferrari_url}/${id}`, {
            method: "DELETE",
            headers: this.getAuthHeaders()
          });
        
          return response.ok; // Devuelve `true` si la eliminación fue exitosa
        }

}
