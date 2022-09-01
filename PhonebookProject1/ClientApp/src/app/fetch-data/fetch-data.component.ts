import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Entries[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Entries[]>('https://localhost:44361/' + 'api/Entries').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface Entries {
  entryId: number;
  name: string;
  mobile: string;
  phonebookId: number;
}
