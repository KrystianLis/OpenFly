import { IType } from './../shared/models/meetingType';
import { IPagination } from './../shared/models/pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class MeetingService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getMeetings(typeId?: number) {
    let params = new HttpParams();

    if (typeId) {
      params = params.append('typeId', typeId.toString());
    }

    return this.http.get<IPagination>(this.baseUrl + 'meetings', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'meetings/types');
  }
}
