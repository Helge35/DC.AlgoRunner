import { Component, OnInit } from '@angular/core';
import { Activity } from '../../shared/models/activity';
import { AuthService } from '../../shared/services/auth.service';
import { ActivityService } from '../../shared/services/activity.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.scss']
})
export class AdminComponent implements OnInit {


  activities: Activity[];
  newActivityName: string;

  getAdminInfo() {
    this._serviceActivity.getActivities().subscribe(info => {
      this.activities = info;
    });
  }

  addActivity() {
    this._serviceActivity.addActivity(this.newActivityName).subscribe(info => {
      this.newActivityName = '';
      this.activities.push(info);
    });
  }

  removeActivity(activityId: number) {
    
    this._serviceActivity.removeActivity(activityId);
    this.activities = this.activities.filter(item => item.id !== activityId);
  }

  constructor(private _service: AuthService, private _serviceActivity: ActivityService) { }

  ngOnInit() {
    this.getAdminInfo();
  }

}
