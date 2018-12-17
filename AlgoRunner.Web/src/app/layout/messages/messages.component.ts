import { Component, OnInit } from '@angular/core';
import { MessagesService } from './messages.service';
import { MessageInfo } from './models/messageInfo';
import { AuthService } from '../../shared/services/auth.service';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'messages',
  templateUrl: './messages.component.html',
  styleUrls: ['./messages.component.scss']
})
export class MessagesComponent implements OnInit {

  messages: MessageInfo[];
  private _hubConnection: HubConnection | undefined;
  messageInfo: string;

  getMessages() {
    this._service.getMessages().subscribe(i => this.messages = i);
  }

  deleteMessage(id: number) {
    /* this._service.deleteMessage(id).subscribe();
     this.messages = this.messages.filter(item => item.id !== id);*/
    this.sendMessage();
  }

  public sendMessage(): void {
    const data = `Sent: Oleg + 1`;

    let mess: MessageInfo = { id: 111, title: "Finaly", context: data, createDate: new Date() };


    if (this._hubConnection) {
      this._hubConnection.invoke('Send', mess);
    }

  }

  constructor(private _service: MessagesService, private authService: AuthService) { }

  ngOnInit() {
    this.authService.getAuthChangeEmitter().subscribe(u => this.getMessages());

    this._hubConnection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:53066/hubs/message')
      .build();

    this._hubConnection.start().catch(err => console.error(err.toString()));

    this._hubConnection.on('Send', (message: any) => {
      this.messages.push(message)
    });
  }
}
