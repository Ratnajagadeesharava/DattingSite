import { Component, OnInit } from '@angular/core';
import  {HttpClient} from '@angular/common/http'
import {SignupComponent} from '../signup/signup.component';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public _users:any ={};
  public title="hello";
  private _url:string="https://localhost:5001/api/users";
  constructor(private _httpClient:HttpClient,public dialog:MatDialog) { }

  ngOnInit(): void {
    this.getUsers();
  }
  getUsers(){
    this._httpClient.get(this._url).subscribe(
      response=>{
        this._users = response;
      },
      error =>{
        console.log(error);
      }

    );
  }
  openDialog(){
    this.dialog.open(SignupComponent);
  }
  
}
