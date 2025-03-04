import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { appsettings } from '../settings/appsettings';
import { Registro } from '../interfaces/registro';
import { Observable } from 'rxjs';
import { User } from '../interfaces/user';
import { Login } from '../interfaces/login';

@Injectable({
     providedIn: 'root'
})
export class AccesoService {

     private http = inject(HttpClient);
     private baseUrl: string = appsettings.base_url;

     constructor() { }

     private getAuthHeaders(): HttpHeaders {
          let headers = new HttpHeaders().set('Content-Type', 'application/json');
          const token = localStorage.getItem('token');
        
          if (token) {
            headers = headers.set('Authorization', `Bearer ${token}`);
          }
        
          return headers;
        }
        
      
        /*
        async getAllProduct(): Promise<objetoModel[]> {
          const response = await fetch(this.baseUrl, {
            method: 'GET',
            headers: this.getAuthHeaders()
          });
          return (await response.json()) ?? [];
        }
     */

     registrarse(objeto: Registro): Observable<User> {
          return this.http.post<User>(`${this.baseUrl}${appsettings.register_path}`, objeto)
     }

     login(objeto: Login): Observable<User> {
          return this.http.post<User>(`${this.baseUrl}${appsettings.login_path}`, objeto)
     }

     validarToken(): Observable<User> {
          return this.http.get<User>(`${this.baseUrl}${appsettings.auth_path}`, {
               headers: this.getAuthHeaders()
             });
     }
}
