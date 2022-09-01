import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-entry',
  templateUrl: './add-entry.component.html'
})
export class AddEntryComponent {
  public forecasts: PEntries[] = [];

  //constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.post<Entries[]>('https://localhost:44361/' + 'api/Entries').subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  //}

  constructor(private http: HttpClient, private router: Router) { }

  addEntryRequest: PEntries = {
    mobile: '',
    name: ''
  };


  addEntry(addEntryRequest: PEntries) {
    return this.http.post<PEntries>('https://localhost:44361/' + 'api/Entries', addEntryRequest);
  }

  addEntries() {
    this.addEntry(this.addEntryRequest).subscribe({
      next: (entry) => {
        console.log(entry);
        this.router.navigate(['api/Entries'])
      }
    });
  }

}




interface PEntries {

  name: string;
  mobile: string;
 
}
