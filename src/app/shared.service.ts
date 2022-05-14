import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = "http://localhost:64637/api";
readonly PhotoUrl = "http://localhost:64637/Poze";

  constructor(private http:HttpClient) { }

  getEmpList():Observable<any[]>{
    return this.http.get<any>(this.APIUrl+'/Angajat');
  }

  addEmployee(val:any){
    return this.http.post(this.APIUrl+'/Angajat',val);
  }

  updateEmployee(val:any){
    return this.http.put(this.APIUrl+'/Angajat',val);
  }

  deleteEmployee(val:any){
    return this.http.delete(this.APIUrl+'/Angajat'+val);
  }

  UploadPhotos(val:any){
    return this.http.post(this.APIUrl+'/Angajat/SaveFile',val);
  }

  //getAllEmpNames():Observable<any[]>{
  //  return this.http.get<any[]>(this.APIUrl+'/lista/GetAllEmpNames'); //noi nu avem in AngajatController asta
  //}

}

