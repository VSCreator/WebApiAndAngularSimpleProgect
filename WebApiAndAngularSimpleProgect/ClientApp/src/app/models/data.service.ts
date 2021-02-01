import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BikeBase } from './BikeBase';

@Injectable()
export class DataService {

  private url = "/api/bikes";

  constructor(private http: HttpClient) {
  }

  getBikes() {
    return this.http.get(this.url);
  }

  getRentedBikes() {
    return this.http.get(this.url + '/' + "rented");
  }

  getAvailableBikes() {
    return this.http.get(this.url + '/' + "available");
  }

  createBike(bike: BikeBase) {
    return this.http.post(this.url, bike);
  }

  updateBike(bike: BikeBase) {
    return this.http.put(this.url, bike)
  }

  deleteBike(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
