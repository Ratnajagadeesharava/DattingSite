import { Component, OnInit } from '@angular/core';
import { LoginComponent} from '../login/login.component';
import {MatDialog} from '@angular/material/dialog';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(public dialog:MatDialog) { }

  ngOnInit(): void {
  }
  onLogin(){
      this.dialog.open(LoginComponent);
  }
}
