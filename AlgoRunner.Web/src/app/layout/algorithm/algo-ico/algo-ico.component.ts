import { Component, OnInit, Input, } from '@angular/core';
import { NgbModal, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { Router } from '@angular/router';

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

    avtiveModal: NgbActiveModal;

    open(content) {
        this.avtiveModal = this.modalService.open(content);
    }

    navigateToExe(id: number) {
        this.avtiveModal.dismiss();
        this._route.navigate(['/algoexe', id]);
    }


    constructor(private modalService: NgbModal, private _route: Router) { }

    ngOnInit() {
    }

}