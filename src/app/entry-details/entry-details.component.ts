import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/shared.service';
import { EmployeeDetailsDTO } from '../core/models/EmployeeDetailsDTO';

import{Employee} from '../core/models/EmployeeDTO';
import { EntryDetailsDTO } from '../core/models/EntryDetailsDTO';

@Component({
  selector: 'entry-details',
  templateUrl: './entry-details.component.html',
  styleUrls: ['./entry-details.component.css']
})
export class DetailsComponent {
    entryDetails: EntryDetailsDTO[] = [];
    id: any;

    constructor(private service:SharedService, private route: ActivatedRoute) {

   }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getDataForTable();
  }

  getDataForTable(){

    this.service.getEmployeeEntryDetails(this.id).subscribe(data=>{
        this.entryDetails = data;

    })

  }

}
