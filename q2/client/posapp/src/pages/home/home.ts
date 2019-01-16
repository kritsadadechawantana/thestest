import { Component } from '@angular/core';
import { NavController } from 'ionic-angular';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToastController } from 'ionic-angular';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {
  baseUrl: string = "http://localhost:5000";
  products: any;

  constructor(public navCtrl: NavController, private http: HttpClient, private toastCtrl: ToastController) {
  }

  ionViewDidEnter()
  {
    this.http.get(this.baseUrl+"/api/POS/GetAllProduct")
    .subscribe((data) => {
      this.products = data;
    });
  }

  AddToCart(id)
  {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    
    this.http.post(this.baseUrl+"/api/POS/AddItem/"+id+"/"+1, null, httpOptions)
    .subscribe((data) => {
      let toast = this.toastCtrl.create({
        message: 'เพิ่มสินค้าเข้าตะกร้าสำเร็จ',
        duration: 1000,
        position: 'top'
      });
    
      toast.onDidDismiss(() => {
      });
    
      toast.present();
    });
  }
}
