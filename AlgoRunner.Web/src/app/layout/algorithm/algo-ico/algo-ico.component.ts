import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Activity } from '../../../shared/models/activity';

@Component({
  selector: 'algo-ico',
  templateUrl: './algo-ico.component.html',
  styleUrls: ['./algo-ico.component.scss']
})
export class AlgoIcoComponent implements OnInit {

  @Input() id: number;
  @Input() title: string;
  @Input() activityName: string;
  @Input() alg: Algorithm;

  closeResult: string;

  open(content) {
    this.modalService.open(content).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
    }, (reason) => {
        this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
}

private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
        return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
        return 'by clicking on a backdrop';
    } else {
        return  `with: ${reason}`;
    }
}

  constructor(private modalService: NgbModal) { }

  ngOnInit() {
  }

}