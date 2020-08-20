import { IType } from './../shared/models/meetingType';
import { MeetingService } from './meeting.service';
import { IMeeting } from './../shared/models/meeting';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-meeting',
  templateUrl: './meeting.component.html',
  styleUrls: ['./meeting.component.scss'],
})
export class MeetingComponent implements OnInit {
  meetings: IMeeting[];
  types: IType[];
  typeIdSelected = 0;

  constructor(private meetingService: MeetingService) {}

  ngOnInit(): void {
    this.getMeetings();
    this.getTypes();
  }

  getMeetings() {
    this.meetingService.getMeetings(this.typeIdSelected).subscribe(
      (response) => {
        this.meetings = response.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getTypes() {
    this.meetingService.getTypes().subscribe(
      (response) => {
        this.types = [{id: 0, name: 'All'}, ...response]
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onTypeSelected(typeId: number) {
    this.typeIdSelected = typeId;
    this.getMeetings();
  }
}
