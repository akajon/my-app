import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { ApiMethodType } from './core/models/Enums/ApiMethodTyoe';
import { ApiEndPoints } from './core/models/Enums/ApiEndPoints';
import { EmployeeDetailsDTO } from './core/models/EmployeeDetailsDTO';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly baseUrl = "https://ipproject-api.azurewebsites.net/api";
//readonly baseUrl = "http://localhost:64637/api";
private readonly headers = new HttpHeaders({
  'Content-Type' : 'application/json',
});

  constructor(private httpClient:HttpClient) { }

  getEmpList(searchname:string):Observable<any[]>{
    return this.httpClient.get<any>(this.baseUrl+`/Angajat?SearchArea=${searchname}`);
  }

  addEmployee(val:any){
    return this.httpClient.post(this.baseUrl+'/Angajat',val);
  }

  updateEmployee(val:any){
    return this.httpClient.put(this.baseUrl+'/Angajat',val);
  }

  deleteEmployee(val:number){
    return this.httpClient.delete(this.baseUrl+`/Angajat/delete?IdCNP=${val}`);
  }

  UploadPhotos(val:any){
    return this.httpClient.post(this.baseUrl+'/Angajat/SaveFile',val);
  }

  GetEmployeeDetails(val: number):Observable<any>{
    return this.httpClient.get(this.baseUrl+`/Angajat/details?idAngajat=${val}`);
  }

  sendAuthenticate(username:string, password:string){
    return this.httpClient.get(this.baseUrl+`/Utilizator/login?user=${username}&parola=${password}`);
  }
  getEmployeeEntryDetails(val: any):Observable<any>{
    return this.httpClient.get(this.baseUrl+`/Angajat/entry/details?idAngajat=${val}`);
  }

  makeHttpRequest(endpoint: string, apiMethod: ApiMethodType, body?: any): Observable<any> {

    const url = this.baseUrl + endpoint;
    switch (apiMethod) {
      case ApiMethodType.GET: {
        return this.httpClient.get(url, { headers: this.headers, responseType: 'json' });
      }
      case ApiMethodType.POST: {
        return this.httpClient.post(url, body, { headers: this.headers, responseType: 'json' });
      }
      case ApiMethodType.PUT: {
        return this.httpClient.put(url + "/" + url, body, { headers: this.headers, responseType: 'json' });
      }
      case ApiMethodType.DELETE: {
        return this.httpClient.delete(url, { headers: this.headers, responseType: 'json' });
      }
      default: throw new Error("Invalid api method type");
    }
  }

  

}

