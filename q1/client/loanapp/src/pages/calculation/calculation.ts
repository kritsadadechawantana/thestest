import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

/**
 * Generated class for the CalculationPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-calculation',
  templateUrl: 'calculation.html',
})
export class CalculationPage {

  baseUrl: string = "http://localhost:5000";
  amount: number;
  years: number;

  loanResult: any;

  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad CalculationPage');
  }

  Calculate()
  {
    this.http.get(this.baseUrl+"/api/Loan/Calculate/"+this.amount+"/"+this.years)
    .subscribe((data) => {
      this.loanResult = data;
    });
  }

}
