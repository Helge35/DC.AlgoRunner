import { Component, OnInit } from '@angular/core';
import { MessagesService } from './messages.service';
import { MessageInfo } from './models/messageInfo';
import { AuthService } from '../../shared/services/auth.service';
import { User } from '../../shared/models/user';

@Component({
  selector: 'messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  messages: MessageInfo[];

  getMessages(userId: number) {
    this._service.getMessages(userId).subscribe(i => this.messages = i);
  }

  deleteMessage(id : number){
    this._service.deleteMessage(id).subscribe();
    this.messages = this.messages.filter(item => item.id !== id);
  }

  constructor(private _service: MessagesService, private authService: AuthService) { }

  ngOnInit() {
    this.authService.getAuthChangeEmitter().subscribe(u=>this.getMessages(u.id));
  }
}
