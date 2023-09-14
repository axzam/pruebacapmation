import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';


@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.ApiUrlClient; // API URL


  getClients(pageSize: number, page: number): Observable<any> {
    const url = `${this.apiUrl}/Clientes/List`;
    var result = this.http.get<any>(url); 

    return result;
  }

  getClientById(id: number): Observable<any> {
    const url = `${this.apiUrl}/Clientes?id=${id}`;
    var result = this.http.get<any>(url); 

    return result;
  }
}
