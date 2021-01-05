import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  model : any = {};
  baseUrl:string="https://localhost:5001"
  url:string = this.baseUrl +"/api/account/register/"
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
  register(){
    this.http.post(this.url,this.model).subscribe(response =>{
      this.model = response;
    },
    error=>{
      console.log(error);
    });
  }
}
