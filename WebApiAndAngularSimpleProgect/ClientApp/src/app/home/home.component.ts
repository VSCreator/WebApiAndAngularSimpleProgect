import { Component, OnInit } from '@angular/core';
import { DataService } from '../models/data.service';
import { BikeBase } from '../models/BikeBase';
import { NgForm, NgModel } from '@angular/forms';
import { Console } from 'console';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  providers: [DataService]
})
export class HomeComponent implements OnInit {

  rentedBikes: BikeBase[];
  availableBikes: BikeBase[];

  currentBike: BikeBase;

  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadRentedBikes();
    this.loadAvailableBikes();
  }

  loadRentedBikes() {
    this.dataService.getRentedBikes()
      .subscribe((data: BikeBase[]) => {
        this.rentedBikes = data;
      });
  }

  loadAvailableBikes() {
    this.dataService.getAvailableBikes()
      .subscribe((data: BikeBase[]) => {
        this.availableBikes = data;
      });
  }

  rentInvert(bycicle: BikeBase) {
    this.currentBike = bycicle;
    this.currentBike.isRented = !this.currentBike.isRented;

    this.updateBikeInfo();
  }

  deleteBike(bike: BikeBase) {
    this.dataService.deleteBike(bike.id)
      .subscribe(data => this.loadAvailableBikes());
  }

  updateBikeInfo() {
    this.dataService.updateBike(this.currentBike)
      .subscribe(data => {
        this.loadAvailableBikes();
        this.loadRentedBikes();
      });
  }

  CreateRentBike(newRentBike: NgModel) {
    this.currentBike = new BikeBase();
    this.currentBike.name = newRentBike.value.name;
    this.currentBike.rentPrice = Number(newRentBike.value.rentPrice);;
    this.currentBike.typeBike = newRentBike.value.typeBike;
    this.currentBike.isRented = false;

    this.dataService.createBike(this.currentBike)
      .subscribe((newBike: BikeBase) => this.availableBikes.push(newBike));
  }
}

