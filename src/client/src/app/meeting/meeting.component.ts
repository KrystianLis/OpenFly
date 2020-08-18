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

  constructor(private meetingService: MeetingService) {}

  ngOnInit(): void {
    this.meetingService.getMeetings().subscribe(
      (response) => {
        this.meetings = response.data;
      },
      (error) => {
        console.log(error);
      }
    );
  }
}
