import { IMeeting } from './meeting';
export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IMeeting[];
}
