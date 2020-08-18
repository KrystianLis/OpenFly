import { IPagination } from './../shared/models/pagination';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MeetingService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getMeetings() {
    return this.http.get<IPagination>(this.baseUrl + 'meetings?pageSize=50');
  } 
}
