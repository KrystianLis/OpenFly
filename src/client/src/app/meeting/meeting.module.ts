import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingComponent } from './meeting.component';
import { MeetingItemComponent } from './meeting-item/meeting-item.component';



@NgModule({
  declarations: [MeetingComponent, MeetingItemComponent],
  imports: [
    CommonModule
  ],
  exports: [MeetingComponent]
})
export class MeetingModule { }
