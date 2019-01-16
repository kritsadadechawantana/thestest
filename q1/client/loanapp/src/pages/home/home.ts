import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import {CalculationPage} from '../calculation/calculation';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  baseUrl: string = "http://localhost:5000";

  interest: number;
  constructor(public navCtrl: NavController, private http: HttpClient) {

  }

  confirmInterest()
  {
    this.http.get(this.baseUrl+"/api/Loan/SetInterest/"+this.interest)
    .subscribe((data) => {
      this.navCtrl.push(CalculationPage);
    });
  }

}
