import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

import{Employee} from '../core/models/EmployeeDTO';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.css']
})
export class ListaComponent {

  EmployeeList:Employee[]=[{id: 1, Nume: 'Oprea', Prenume:'Marius'}];

  ModalTitle:string='';
  ActivateAddEmp:boolean=false;
  
  constructor(private service:SharedService) {

   }

  ngOnInit(): void {
    this.refreshEmpList();
  }

  addClick(){
    this.ModalTitle="Add Employee";
    this.ActivateAddEmp=true;
  }

  deleteClick(item: Employee){
    if(confirm("Are you sure?")){
        this.service.deleteEmployee(item.id).subscribe(data=>{
          alert(data.toString());
          this.refreshEmpList();
        })
    }
  }

  closeClick(){
    this.ActivateAddEmp=false;
    this.refreshEmpList();
  }

  refreshEmpList(){
    this.service.getEmpList().subscribe(data=>{
      this.EmployeeList=data;
    });
  }

  closeAddPopup(){

    this.ActivateAddEmp = false;

  }

}
