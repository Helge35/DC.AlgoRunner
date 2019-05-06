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
  newActivitie: Activity;
  commonActivitie: Activity;
  submitted = false;


  getAdminInfo() {
    this._serviceActivity.getActivities().subscribe(info => {
      this.commonActivitie = info.find(c => c.id == 1);
      this.activities = info.filter(item => item.id > 1);
    });
  }

  addActivity({ valid }: { valid: boolean }){
    this.submitted = true;
    if (!valid) { return }

    this._serviceActivity.addActivity(this.newActivitie).subscribe(info => {
      this.newActivitie = new Activity();
      this.activities.push(info);
    });
    this.submitted = false;
  }

  removeActivity(activityId: number) {
    if (confirm("Are you sure to delete activity")) {
      this._serviceActivity.removeActivity(activityId);
      this.activities = this.activities.filter(item => item.id !== activityId);
    }
  }

  saveCommonPath() {
    this._serviceActivity.saveCommonPath(this.commonActivitie);
  }

  constructor(private _service: AuthService, private _serviceActivity: ActivityService) { }

  ngOnInit() {
    this.newActivitie = new Activity();
    this.getAdminInfo();

    this.commonActivitie = new Activity()
  }

}
