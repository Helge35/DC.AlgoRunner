import { Component, OnInit } from '@angular/core';
import { User } from '../../shared/models/user';
import { Activity } from '../../shared/models/activity';
import { AuthGuard } from '../../shared';
import { AuthService } from '../../shared/services/auth.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {

  members: User[];
  activities: Activity[];
  newActivityName: string;

  getAdminInfo() {
    this._service.getAdminInfo().subscribe(info => {
      this.members = info.members;
      this.activities = info.activities;
    });
  }

  addActivity() {
    this._service.addActivity(this.newActivityName).subscribe(info => {
      this.newActivityName = '';
      this.activities.push(info);
    });
  }

  removeActivity(activityId: number) {
    
    this._service.removeActivity(activityId);
    this.activities = this.activities.filter(item => item.id !== activityId);
  }

  constructor(private _service: AuthService) { }

  ngOnInit() {
    this.getAdminInfo();
  }

}
