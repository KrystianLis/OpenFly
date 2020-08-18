import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MeetingComponent } from './meeting.component';



@NgModule({
  declarations: [MeetingComponent],
  imports: [
    CommonModule
  ],
  exports: [MeetingComponent]
})
export class MeetingModule { }
