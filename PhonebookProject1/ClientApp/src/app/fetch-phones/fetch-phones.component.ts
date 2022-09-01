import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-phones',
  templateUrl: './fetch-phones.component.html'
})
export class FetchPhonesComponent {
  public forecasts: PhoneBooks[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<PhoneBooks[]>('https://localhost:44361/' + 'api/PhoneBooks').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface PhoneBooks {
  id: number;
  name: string;
}
