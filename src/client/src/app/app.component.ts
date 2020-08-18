import { IPagination } from './models/pagination';
import { IMeeting } from './models/meeting';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'OpenFly';
  meetings: IMeeting[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/meetings?pageSize=50').subscribe(
      (response: IPagination) => {
        this.meetings = response.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
