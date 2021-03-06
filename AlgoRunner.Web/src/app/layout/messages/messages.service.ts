import { Injectable, EventEmitter, OnInit } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { MessageInfo } from './models/messageInfo';
import { AuthService } from '../../shared/services/auth.service';

@Injectable({
  providedIn: 'root',
})

export class MessagesService  {

  apiUrl: string = environment.apiUrl + "messages/";

  private _newMessageEvent: EventEmitter<MessageInfo> = new EventEmitter();

  getMessages(): Observable<MessageInfo[]> {
    return this._http.get<MessageInfo[]>(this.apiUrl);
  }

  deleteMessage(id: number): any {
    return this._http.delete(this.apiUrl + id);
  }

  subsrcibeToNewMessageEvent() {
    return this._newMessageEvent;
  }

  setMessagesAsReaded(){
    this._http.get(this.apiUrl+ "SetAsReaded").subscribe();
  }

  riseNewMessageEvent(){
    this._newMessageEvent.emit();
  }

  constructor(private _http: HttpClient, private _authServce: AuthService) {
  }
}