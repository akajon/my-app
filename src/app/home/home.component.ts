import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent{
  message = '';
  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.http.get('http://localhost:4200/api/user', {withCredentials: true}).subscribe(
      (res: any) => {
        this.message = 'Hi ${res.name}';
        //Emitters


      },
      err => {
        this.message = 'You are not logged in';
      }
    );
  }

}
