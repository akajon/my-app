import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeDetailsDTO } from '../core/models/EmployeeDetailsDTO';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent{

usernameToSend: string="";
passwordToSend: string="";

  constructor(private sharedService: SharedService,private route: Router) { }

  ngOnInit(){



  }

authenticate(){

this.sharedService.sendAuthenticate(this.usernameToSend,this.passwordToSend).subscribe(result=>{
  console.log(result);
  if(result == true){

    this.route.navigate(['/lista']);

  }
})

}

}
