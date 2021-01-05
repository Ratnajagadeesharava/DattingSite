import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model:any={};
  baseUrl:string="https://localhost:5001/api/";
  url:string= this.baseUrl+"account/login";
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
  }
  login(){
    this.http.post(this.url,this.model).subscribe(
      response =>{
        localStorage.setItem('user',response.token);
      },
      error =>{
        console.log(error);
      }
    );
  }
}
