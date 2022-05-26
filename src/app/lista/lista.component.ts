import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

import{Employee} from '../core/models/EmployeeDTO';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaComponent {

  EmployeeList:Employee[]=[];
  searchName:string='';
  ModalTitle:string='';
  ActivateAddEmp:boolean=false;
  dropdown: boolean[] = [false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false]
  constructor(private service:SharedService) {

   }

  ngOnInit(): void {
    this.refreshEmpList(this);
  }

  addClick(){
    this.ModalTitle="Add Employee";
    this.ActivateAddEmp=true;
  }

  deleteClick(item: Employee){
    if(confirm("Are you sure?")){
        this.service.deleteEmployee(item.Id).subscribe(data=>{
          alert(data.toString());
          this.refreshEmpList(this);
        })
    }
  }

  dropDown(i: number){
    if(this.dropdown[i] ==true){
      this.dropdown[i] =false;
    }else{
      this.dropdown[i]=true;
    }
  }

  closeClick(){
    this.ActivateAddEmp=false;
    this.refreshEmpList(this);
  }

  refreshEmpList(thisalt: any){
    var text= (<HTMLInputElement>document.getElementById("search-field")).value;
    this.service.getEmpList(text).subscribe(data=>{
      this.EmployeeList=data;
    });
  }

  closeAddPopup(){

    this.ActivateAddEmp = false;

  }

}
