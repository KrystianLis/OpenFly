import { IMeeting } from './../../shared/models/meeting';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-meeting-item',
  templateUrl: './meeting-item.component.html',
  styleUrls: ['./meeting-item.component.scss']
})
export class MeetingItemComponent implements OnInit {
      @Input() meeting: IMeeting;

  constructor() { }

  ngOnInit(): void {

  }

}
