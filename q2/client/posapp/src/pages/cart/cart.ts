import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { CartVM } from '../../models/models';

/**
 * Generated class for the CartPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-cart',
  templateUrl: 'cart.html',
})
export class CartPage {
  baseUrl: string = "http://localhost:5000";
  cart: any;

  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient) {
    
  }

  ionViewDidEnter()
  {
    this.http.get(this.baseUrl+"/api/POS/GetCart")
    .subscribe((data) => {
      this.cart = data;
      console.log(data);
    });
  }

}
