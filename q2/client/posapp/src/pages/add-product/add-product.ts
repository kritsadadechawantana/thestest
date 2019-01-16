import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastController } from 'ionic-angular';

/**
 * Generated class for the AddProductPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-add-product',
  templateUrl: 'add-product.html',
})
export class AddProductPage {
  baseUrl: string = "http://localhost:5000";
  name: number;
  price: number;

  constructor(public navCtrl: NavController, public navParams: NavParams, private http: HttpClient, private toastCtrl: ToastController) {
  }

  Add()
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    
    this.http.post(this.baseUrl+"/api/POS/AddProduct", {name: this.name, price: this.price}, httpOptions)
    .subscribe((data) => {
      let toast = this.toastCtrl.create({
        message: 'เพิ่มสินค้าสำเร็จ',
        duration: 1000,
        position: 'top'
      });
    
      toast.onDidDismiss(() => {
      });
    
      toast.present();
    });
  }

}
