(window.webpackJsonp=window.webpackJsonp||[]).push([[15],{YeLj:function(l,n,u){"use strict";u.r(n);var e=u("CcnG"),t=function(){},o=u("4lDY"),i=u("u4HF"),a=u("aq8m"),d=u("qcfG"),r=u("xaNE"),s=u("FNNE"),c=u("gW6t"),g=u("pMnS"),p=u("gIcY"),m=u("Ip0R"),v=u("Vez3"),f=u("kZVM"),h=u("9Li1"),C=[{id:1,name:"Text"},{id:2,name:"Table"},{id:3,name:"Graph-Lines"},{id:4,name:"Graph-Pie"},{id:5,name:"Graph-Bars"},{id:6,name:"Graph-Dotes"}],b=u("YO4B"),y=function(){this.range=[]},R=u("eUd/"),w=[{key:1,value:"Number"},{key:2,value:"Text"},{key:3,value:"Boolean"},{key:4,value:"Enum"}],T=u("eT13"),P=function(){function l(l,n,u,e){this._serviceActivity=l,this._serviceAlgo=n,this.modalService=u,this._route=e,this.resultTypes=C,this.propertyTypes=w,this.fileToUpload=null,this.enumList=[],this.submitted=!1}return l.prototype.getActivities=function(){var l=this;this._serviceActivity.getActivities().subscribe(function(n){return l.activities=n})},l.prototype.addNewParameter=function(){this.alg.algoParams.push(this.newParameter),this.newParameter=new y,this.enumList=[],this.newEnum=""},l.prototype.openModal=function(l,n){this.updatedParam=n,this.enumList=n.range,this.avtiveModal=this.modalService.open(l)},l.prototype.addEnumValue=function(){this.enumList.push(this.newEnum),this.newEnum=""},l.prototype.addEnumListToProperty=function(){this.avtiveModal.dismiss(),this.updatedParam.range=this.enumList},l.prototype.onFormSubmit=function(){console.log("Full Address","ol")},l.prototype.uploadAndSaveAlg=function(l){var n=this,u=l.valid;if(this.submitted=!0,u||this.algoFile){var e=0;this.alg.activity&&(e=this.alg.activity.id),this._serviceAlgo.uploadAlg(this.algoFile,e).subscribe(function(l){n.alg.fileServerPath=l,n._serviceAlgo.saveAlg(n.alg).subscribe(function(){return n._route.navigate([""])})},function(l){return alert(l)})}},l.prototype.fileChange=function(l){var n=l.target.files;n.length>0&&(this.algoFile=n[0])},l.prototype.ngOnInit=function(){this.alg=new h.a,this.newParameter=new y,this.getActivities()},l}(),k=u("iCtU"),x=u("ZYCi"),E=e["\u0275crt"]({encapsulation:0,styles:[[""]],data:{}});function I(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Algorithm Name is required "]))],null,null)}function V(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,3,"option",[],null,null,null,null,null)),e["\u0275did"](1,147456,null,0,p.p,[e.ElementRef,e.Renderer2,[2,p.s]],{ngValue:[0,"ngValue"]},null),e["\u0275did"](2,147456,null,0,p.y,[e.ElementRef,e.Renderer2,[8,null]],{ngValue:[0,"ngValue"]},null),(l()(),e["\u0275ted"](3,null,[" "," "]))],function(l,n){l(n,1,0,n.context.$implicit),l(n,2,0,n.context.$implicit)},function(l,n){l(n,3,0,n.context.$implicit.name)})}function M(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Activity is required "]))],null,null)}function q(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,3,"option",[],null,null,null,null,null)),e["\u0275did"](1,147456,null,0,p.p,[e.ElementRef,e.Renderer2,[2,p.s]],{ngValue:[0,"ngValue"]},null),e["\u0275did"](2,147456,null,0,p.y,[e.ElementRef,e.Renderer2,[8,null]],{ngValue:[0,"ngValue"]},null),(l()(),e["\u0275ted"](3,null,[" "," "]))],function(l,n){l(n,1,0,n.context.$implicit),l(n,2,0,n.context.$implicit)},function(l,n){l(n,3,0,n.context.$implicit.name)})}function j(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Result Type is required "]))],null,null)}function F(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Algorithm file is required "]))],null,null)}function A(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,3,"option",[],null,null,null,null,null)),e["\u0275did"](1,147456,null,0,p.p,[e.ElementRef,e.Renderer2,[2,p.s]],{ngValue:[0,"ngValue"]},null),e["\u0275did"](2,147456,null,0,p.y,[e.ElementRef,e.Renderer2,[8,null]],{ngValue:[0,"ngValue"]},null),(l()(),e["\u0275ted"](3,null,[" "," "]))],function(l,n){l(n,1,0,n.context.$implicit),l(n,2,0,n.context.$implicit)},function(l,n){l(n,3,0,n.context.$implicit.value)})}function S(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"a",[["class","float-right card-inverse"],["href","javascript:void(0)"]],null,[[null,"click"]],function(l,n,u){var t=!0,o=l.component;return"click"===n&&(t=!1!==o.openModal(e["\u0275nov"](l.parent,131),o.newParameter)&&t),t},null,null)),(l()(),e["\u0275ted"](-1,null,[" Set Enum"]))],null,null)}function _(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"a",[["href","javascript:void(0)"]],null,[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==l.component.openModal(e["\u0275nov"](l.parent.parent,131),l.parent.context.$implicit)&&t),t},null,null)),(l()(),e["\u0275ted"](-1,null,[" Set Enum"]))],null,null)}function D(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,7,"div",[["class"," list-group-item "]],null,null,null,null,null)),(l()(),e["\u0275ted"](1,null,[" "," "])),(l()(),e["\u0275eld"](2,0,null,null,2,"span",[["class","float-right text-muted small"]],null,null,null,null,null)),(l()(),e["\u0275eld"](3,0,null,null,1,"em",[],null,null,null,null,null)),(l()(),e["\u0275ted"](4,null,["",""])),(l()(),e["\u0275eld"](5,0,null,null,2,"span",[["style","float: right; margin-right: 50px"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,_)),e["\u0275did"](7,16384,null,0,m.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null)],function(l,n){l(n,7,0,n.context.$implicit.type&&4==n.context.$implicit.type.key)},function(l,n){l(n,1,0,n.context.$implicit.name),l(n,4,0,n.context.$implicit.type.value)})}function O(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"li",[["class","list-group-item"]],null,null,null,null,null)),(l()(),e["\u0275ted"](1,null,[" ",""]))],null,function(l,n){l(n,1,0,n.context.$implicit)})}function L(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,5,"div",[["class","modal-header bg-default"]],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,1,"span",[["style","margin-left: 10px; "]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Enum values"])),(l()(),e["\u0275eld"](3,0,null,null,2,"button",[["aria-label","Close"],["class","close"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.context.dismiss("Cross click")&&e),e},null,null)),(l()(),e["\u0275eld"](4,0,null,null,1,"span",[["aria-hidden","true"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xd7"])),(l()(),e["\u0275eld"](6,0,null,null,14,"div",[["class","modal-body"]],null,null,null,null,null)),(l()(),e["\u0275eld"](7,0,null,null,3,"div",[],null,null,null,null,null)),(l()(),e["\u0275eld"](8,0,null,null,2,"ul",[["class","list-group"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,O)),e["\u0275did"](10,278528,null,0,m.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275eld"](11,0,null,null,9,"div",[["class","row"],["style","margin-top: 10px"]],null,null,null,null,null)),(l()(),e["\u0275eld"](12,0,null,null,6,"div",[["class","col-9"]],null,null,null,null,null)),(l()(),e["\u0275eld"](13,0,null,null,5,"input",[["class","form-control"],["placeholder","Enter value"],["type","text"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,14)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,14).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,14)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,14)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.newEnum=u)&&t),t},null,null)),e["\u0275did"](14,16384,null,0,p.d,[e.Renderer2,e.ElementRef,[2,p.a]],null,null),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.d]),e["\u0275did"](16,671744,null,0,p.o,[[8,null],[8,null],[8,null],[6,p.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](18,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275eld"](19,0,null,null,1,"button",[["class","btn btn-default btn-block col-2 float-right"],["style","width: 80px;"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.addEnumValue()&&e),e},null,null)),(l()(),e["\u0275ted"](-1,null,["+"])),(l()(),e["\u0275eld"](21,0,null,null,4,"div",[["class","modal-footer "]],null,null,null,null,null)),(l()(),e["\u0275eld"](22,0,null,null,1,"button",[["class","btn btn-sm  btn-info float-left col-3"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.addEnumListToProperty()&&e),e},null,null)),(l()(),e["\u0275ted"](-1,null,["Save"])),(l()(),e["\u0275eld"](24,0,null,null,1,"button",[["class","btn btn-sm btn-secondary float-right col-3"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.context.close("Close click")&&e),e},null,null)),(l()(),e["\u0275ted"](-1,null,["Close"]))],function(l,n){var u=n.component;l(n,10,0,u.enumList),l(n,16,0,u.newEnum)},function(l,n){l(n,13,0,e["\u0275nov"](n,18).ngClassUntouched,e["\u0275nov"](n,18).ngClassTouched,e["\u0275nov"](n,18).ngClassPristine,e["\u0275nov"](n,18).ngClassDirty,e["\u0275nov"](n,18).ngClassValid,e["\u0275nov"](n,18).ngClassInvalid,e["\u0275nov"](n,18).ngClassPending)})}function N(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"projects-page-header",[],null,null,null,v.b,v.a)),e["\u0275did"](1,114688,null,0,f.a,[],{header:[0,"header"]},null),(l()(),e["\u0275eld"](2,0,null,null,129,"div",[["class","row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](3,0,null,null,85,"fieldset",[["class","col-6"]],null,null,null,null,null)),(l()(),e["\u0275eld"](4,0,null,null,84,"form",[["novalidate",""]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngSubmit"],[null,"submit"],[null,"reset"]],function(l,n,u){var t=!0,o=l.component;return"submit"===n&&(t=!1!==e["\u0275nov"](l,6).onSubmit(u)&&t),"reset"===n&&(t=!1!==e["\u0275nov"](l,6).onReset()&&t),"ngSubmit"===n&&(t=!1!==o.uploadAndSaveAlg(e["\u0275nov"](l,6))&&t),t},null,null)),e["\u0275did"](5,16384,null,0,p.v,[],null,null),e["\u0275did"](6,4210688,[["mform",4]],0,p.n,[[8,null],[8,null]],null,{ngSubmit:"ngSubmit"}),e["\u0275prd"](2048,null,p.c,null,[p.n]),e["\u0275did"](8,16384,null,0,p.m,[[4,p.c]],null,null),(l()(),e["\u0275eld"](9,0,null,null,13,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](10,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Name:"])),(l()(),e["\u0275eld"](12,0,null,null,10,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](13,0,null,null,7,"input",[["class","form-control"],["name","algname"],["required",""],["type","text"]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,14)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,14).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,14)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,14)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.alg.name=u)&&t),t},null,null)),e["\u0275did"](14,16384,null,0,p.d,[e.Renderer2,e.ElementRef,[2,p.a]],null,null),e["\u0275did"](15,16384,null,0,p.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,p.i,function(l){return[l]},[p.r]),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.d]),e["\u0275did"](18,671744,[["algname",4]],0,p.o,[[2,p.c],[6,p.i],[8,null],[6,p.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](20,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,I)),e["\u0275did"](22,16384,null,0,m.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](23,0,null,null,9,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](24,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Description:"])),(l()(),e["\u0275eld"](26,0,null,null,6,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](27,0,null,null,5,"textarea",[["class","form-control"],["name","algdesc"],["placeholder","Write unclassified info only"],["rows","3"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,28)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,28).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,28)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,28)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.alg.desc=u)&&t),t},null,null)),e["\u0275did"](28,16384,null,0,p.d,[e.Renderer2,e.ElementRef,[2,p.a]],null,null),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.d]),e["\u0275did"](30,671744,null,0,p.o,[[2,p.c],[8,null],[8,null],[6,p.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](32,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275eld"](33,0,null,null,15,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](34,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Project:"])),(l()(),e["\u0275eld"](36,0,null,null,12,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](37,0,null,null,9,"select",[["name","algactivity"],["required",""]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"change"],[null,"blur"]],function(l,n,u){var t=!0,o=l.component;return"change"===n&&(t=!1!==e["\u0275nov"](l,38).onChange(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,38).onTouched()&&t),"ngModelChange"===n&&(t=!1!==(o.alg.activity=u)&&t),t},null,null)),e["\u0275did"](38,16384,null,0,p.s,[e.Renderer2,e.ElementRef],null,null),e["\u0275did"](39,16384,null,0,p.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,p.i,function(l){return[l]},[p.r]),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.s]),e["\u0275did"](42,671744,[["algactivity",4]],0,p.o,[[2,p.c],[6,p.i],[8,null],[6,p.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](44,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,V)),e["\u0275did"](46,278528,null,0,m.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,M)),e["\u0275did"](48,16384,null,0,m.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](49,0,null,null,9,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](50,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Created By:"])),(l()(),e["\u0275eld"](52,0,null,null,6,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](53,0,null,null,5,"input",[["class","form-control"],["name","algcreatedBy"],["type","text"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,54)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,54).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,54)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,54)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.alg.createdBy=u)&&t),t},null,null)),e["\u0275did"](54,16384,null,0,p.d,[e.Renderer2,e.ElementRef,[2,p.a]],null,null),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.d]),e["\u0275did"](56,671744,null,0,p.o,[[2,p.c],[8,null],[8,null],[6,p.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](58,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275eld"](59,0,null,null,15,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](60,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Result Type:"])),(l()(),e["\u0275eld"](62,0,null,null,12,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](63,0,null,null,9,"select",[["name","algresultType"],["required",""]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"change"],[null,"blur"]],function(l,n,u){var t=!0,o=l.component;return"change"===n&&(t=!1!==e["\u0275nov"](l,64).onChange(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,64).onTouched()&&t),"ngModelChange"===n&&(t=!1!==(o.alg.resultType=u)&&t),t},null,null)),e["\u0275did"](64,16384,null,0,p.s,[e.Renderer2,e.ElementRef],null,null),e["\u0275did"](65,16384,null,0,p.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,p.i,function(l){return[l]},[p.r]),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.s]),e["\u0275did"](68,671744,[["algresultType",4]],0,p.o,[[2,p.c],[6,p.i],[8,null],[6,p.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](70,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,q)),e["\u0275did"](72,278528,null,0,m.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,j)),e["\u0275did"](74,16384,null,0,m.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](75,0,null,null,6,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](76,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["File Upload:"])),(l()(),e["\u0275eld"](78,0,null,null,3,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](79,0,null,null,0,"input",[["accept",".py"],["name","algfile"],["placeholder","Upload file"],["type","file"]],null,[[null,"change"]],function(l,n,u){var e=!0;return"change"===n&&(e=!1!==l.component.fileChange(u)&&e),e},null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,F)),e["\u0275did"](81,16384,null,0,m.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](82,0,null,null,6,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](83,0,null,null,0,"label",[["class","col-8 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275eld"](84,0,null,null,4,"div",[["class","col-2"]],null,null,null,null,null)),(l()(),e["\u0275eld"](85,0,null,null,3,"button",[["class","btn btn-lg btn-success"],["type","submit"]],null,null,null,null,null)),(l()(),e["\u0275eld"](86,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Upload & Save\xa0\xa0"])),(l()(),e["\u0275eld"](88,0,null,null,0,"i",[["class","fa fa-arrow-circle-up"]],null,null,null,null,null)),(l()(),e["\u0275eld"](89,0,null,null,0,"div",[["class","col-2"]],null,null,null,null,null)),(l()(),e["\u0275eld"](90,0,null,null,40,"div",[["class","col-4"]],null,null,null,null,null)),(l()(),e["\u0275eld"](91,0,null,null,39,"div",[["class","col-xl-12 text-xs-center"]],null,null,null,null,null)),(l()(),e["\u0275eld"](92,0,null,null,2,"div",[["class","alert alert-info"]],null,null,null,null,null)),(l()(),e["\u0275eld"](93,0,null,null,1,"strong",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Properties "])),(l()(),e["\u0275eld"](95,0,null,null,35,"div",[["class","card mb-3"]],null,null,null,null,null)),(l()(),e["\u0275eld"](96,0,null,null,31,"div",[["class","card-header"]],null,null,null,null,null)),(l()(),e["\u0275eld"](97,0,null,null,30,"div",[["class","row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](98,0,null,null,10,"fieldset",[["class","col-xl-6 text-xs-center"]],null,null,null,null,null)),(l()(),e["\u0275eld"](99,0,null,null,1,"label",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Name"])),(l()(),e["\u0275eld"](101,0,null,null,7,"input",[["class","form-control"],["placeholder","Enter name"],["required",""]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,102)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,102).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,102)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,102)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.newParameter.name=u)&&t),t},null,null)),e["\u0275did"](102,16384,null,0,p.d,[e.Renderer2,e.ElementRef,[2,p.a]],null,null),e["\u0275did"](103,16384,null,0,p.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,p.i,function(l){return[l]},[p.r]),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.d]),e["\u0275did"](106,671744,null,0,p.o,[[8,null],[6,p.i],[8,null],[6,p.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](108,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275eld"](109,0,null,null,12,"fieldset",[["class","col-xl-6 text-xs-center"]],null,null,null,null,null)),(l()(),e["\u0275eld"](110,0,null,null,1,"label",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Type"])),(l()(),e["\u0275eld"](112,0,null,null,9,"select",[["class","form-control"],["required",""]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"change"],[null,"blur"]],function(l,n,u){var t=!0,o=l.component;return"change"===n&&(t=!1!==e["\u0275nov"](l,113).onChange(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,113).onTouched()&&t),"ngModelChange"===n&&(t=!1!==(o.newParameter.type=u)&&t),t},null,null)),e["\u0275did"](113,16384,null,0,p.s,[e.Renderer2,e.ElementRef],null,null),e["\u0275did"](114,16384,null,0,p.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,p.i,function(l){return[l]},[p.r]),e["\u0275prd"](1024,null,p.j,function(l){return[l]},[p.s]),e["\u0275did"](117,671744,null,0,p.o,[[8,null],[6,p.i],[8,null],[6,p.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,p.k,null,[p.o]),e["\u0275did"](119,16384,null,0,p.l,[[4,p.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,A)),e["\u0275did"](121,278528,null,0,m.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275eld"](122,0,null,null,2,"fieldset",[["class","col-xl-9"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,S)),e["\u0275did"](124,16384,null,0,m.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](125,0,null,null,2,"fieldset",[["class","col-xl-3 "]],null,null,null,null,null)),(l()(),e["\u0275eld"](126,0,null,null,1,"button",[["class","btn btn-info form-control"],["style","float: right;width: 80px; margin-top: 10px"],["type","button"]],[[8,"disabled",0]],[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.addNewParameter()&&e),e},null,null)),(l()(),e["\u0275ted"](-1,null,["+ Add"])),(l()(),e["\u0275eld"](128,0,null,null,2,"div",[["class","card-body"],["style","height:60vh; overflow: auto"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,D)),e["\u0275did"](130,278528,null,0,m.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275and"](0,[["content",2]],null,0,null,L))],function(l,n){var u=n.component;l(n,1,0,"New Algorithm"),l(n,15,0,""),l(n,18,0,"algname",u.alg.name),l(n,22,0,u.submitted&&e["\u0275nov"](n,18).invalid),l(n,30,0,"algdesc",u.alg.desc),l(n,39,0,""),l(n,42,0,"algactivity",u.alg.activity),l(n,46,0,u.activities),l(n,48,0,u.submitted&&e["\u0275nov"](n,42).invalid),l(n,56,0,"algcreatedBy",u.alg.createdBy),l(n,65,0,""),l(n,68,0,"algresultType",u.alg.resultType),l(n,72,0,u.resultTypes),l(n,74,0,u.submitted&&e["\u0275nov"](n,68).invalid),l(n,81,0,u.submitted&&!u.algoFile),l(n,103,0,""),l(n,106,0,u.newParameter.name),l(n,114,0,""),l(n,117,0,u.newParameter.type),l(n,121,0,u.propertyTypes),l(n,124,0,u.newParameter.type&&4==u.newParameter.type.key),l(n,130,0,u.alg.algoParams)},function(l,n){var u=n.component;l(n,4,0,e["\u0275nov"](n,8).ngClassUntouched,e["\u0275nov"](n,8).ngClassTouched,e["\u0275nov"](n,8).ngClassPristine,e["\u0275nov"](n,8).ngClassDirty,e["\u0275nov"](n,8).ngClassValid,e["\u0275nov"](n,8).ngClassInvalid,e["\u0275nov"](n,8).ngClassPending),l(n,13,0,e["\u0275nov"](n,15).required?"":null,e["\u0275nov"](n,20).ngClassUntouched,e["\u0275nov"](n,20).ngClassTouched,e["\u0275nov"](n,20).ngClassPristine,e["\u0275nov"](n,20).ngClassDirty,e["\u0275nov"](n,20).ngClassValid,e["\u0275nov"](n,20).ngClassInvalid,e["\u0275nov"](n,20).ngClassPending),l(n,27,0,e["\u0275nov"](n,32).ngClassUntouched,e["\u0275nov"](n,32).ngClassTouched,e["\u0275nov"](n,32).ngClassPristine,e["\u0275nov"](n,32).ngClassDirty,e["\u0275nov"](n,32).ngClassValid,e["\u0275nov"](n,32).ngClassInvalid,e["\u0275nov"](n,32).ngClassPending),l(n,37,0,e["\u0275nov"](n,39).required?"":null,e["\u0275nov"](n,44).ngClassUntouched,e["\u0275nov"](n,44).ngClassTouched,e["\u0275nov"](n,44).ngClassPristine,e["\u0275nov"](n,44).ngClassDirty,e["\u0275nov"](n,44).ngClassValid,e["\u0275nov"](n,44).ngClassInvalid,e["\u0275nov"](n,44).ngClassPending),l(n,53,0,e["\u0275nov"](n,58).ngClassUntouched,e["\u0275nov"](n,58).ngClassTouched,e["\u0275nov"](n,58).ngClassPristine,e["\u0275nov"](n,58).ngClassDirty,e["\u0275nov"](n,58).ngClassValid,e["\u0275nov"](n,58).ngClassInvalid,e["\u0275nov"](n,58).ngClassPending),l(n,63,0,e["\u0275nov"](n,65).required?"":null,e["\u0275nov"](n,70).ngClassUntouched,e["\u0275nov"](n,70).ngClassTouched,e["\u0275nov"](n,70).ngClassPristine,e["\u0275nov"](n,70).ngClassDirty,e["\u0275nov"](n,70).ngClassValid,e["\u0275nov"](n,70).ngClassInvalid,e["\u0275nov"](n,70).ngClassPending),l(n,101,0,e["\u0275nov"](n,103).required?"":null,e["\u0275nov"](n,108).ngClassUntouched,e["\u0275nov"](n,108).ngClassTouched,e["\u0275nov"](n,108).ngClassPristine,e["\u0275nov"](n,108).ngClassDirty,e["\u0275nov"](n,108).ngClassValid,e["\u0275nov"](n,108).ngClassInvalid,e["\u0275nov"](n,108).ngClassPending),l(n,112,0,e["\u0275nov"](n,114).required?"":null,e["\u0275nov"](n,119).ngClassUntouched,e["\u0275nov"](n,119).ngClassTouched,e["\u0275nov"](n,119).ngClassPristine,e["\u0275nov"](n,119).ngClassDirty,e["\u0275nov"](n,119).ngClassValid,e["\u0275nov"](n,119).ngClassInvalid,e["\u0275nov"](n,119).ngClassPending),l(n,126,0,!u.newParameter.name||!u.newParameter.type)})}var U=e["\u0275ccf"]("app-algorithm",P,function(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"app-algorithm",[],null,null,null,N,E)),e["\u0275did"](1,114688,null,0,P,[b.a,T.a,k.a,x.l],null,null)],function(l,n){l(n,1,0)},null)},{},{},[]),$=u("9eRs"),B=u("Ovjw"),G=u("e5OV"),Y=u("8NoF"),Z=u("FeSO"),W=u("ysnj"),J=u("5sLU"),z=u("oYRQ"),K=u("q7oS"),Q=u("OU4G"),X=u("bSlz"),H=u("9n00"),ll=u("/onb"),nl=u("Ok6J"),ul=u("ebCm"),el=u("NGEN"),tl=u("ejuw"),ol=u("swaV"),il=u("Zt+D"),al=u("lMb6"),dl=u("Bia8"),rl=u("bt6x"),sl=u("0XGt"),cl=u("nhl2"),gl=u("gpiN"),pl=u("MVL9"),ml=u("j2fZ"),vl=u("LKjY"),fl=u("PsaP"),hl=u("InZo"),Cl=u("C9m0"),bl=u("+NDo"),yl=u("4WQT"),Rl=u("wtSO"),wl=u("NlYj"),Tl=u("neuq"),Pl=u("y+WT"),kl=u("XfKo"),xl=function(){};u.d(n,"AlgorithmModuleNgFactory",function(){return El});var El=e["\u0275cmf"](t,[],function(l){return e["\u0275mod"]([e["\u0275mpd"](512,e.ComponentFactoryResolver,e["\u0275CodegenComponentFactoryResolver"],[[8,[o.a,i.a,a.a,d.a,r.a,s.a,c.a,g.a,U]],[3,e.ComponentFactoryResolver],e.NgModuleRef]),e["\u0275mpd"](4608,m.o,m.n,[e.LOCALE_ID,[2,m.A]]),e["\u0275mpd"](4608,p.w,p.w,[]),e["\u0275mpd"](4608,$.a,$.a,[m.c]),e["\u0275mpd"](4608,B.a,B.a,[e.ApplicationRef,e.Injector,e.ComponentFactoryResolver,m.c,$.a]),e["\u0275mpd"](4608,k.a,k.a,[e.ComponentFactoryResolver,e.Injector,B.a]),e["\u0275mpd"](4608,G.a,G.a,[]),e["\u0275mpd"](4608,Y.a,Y.a,[]),e["\u0275mpd"](4608,Z.a,Z.a,[]),e["\u0275mpd"](135680,W.c,W.c,[m.c,W.a]),e["\u0275mpd"](4608,J.a,J.a,[]),e["\u0275mpd"](4608,z.a,z.a,[]),e["\u0275mpd"](4608,K.a,K.a,[]),e["\u0275mpd"](4608,Q.a,Q.b,[]),e["\u0275mpd"](4608,m.d,m.d,[e.LOCALE_ID]),e["\u0275mpd"](4608,X.a,X.b,[e.LOCALE_ID,m.d]),e["\u0275mpd"](4608,H.b,H.a,[]),e["\u0275mpd"](4608,ll.a,ll.b,[]),e["\u0275mpd"](4608,nl.a,nl.a,[]),e["\u0275mpd"](4608,ul.a,ul.a,[]),e["\u0275mpd"](4608,el.a,el.a,[]),e["\u0275mpd"](4608,tl.a,tl.a,[]),e["\u0275mpd"](4608,ol.a,ol.a,[]),e["\u0275mpd"](4608,il.a,il.a,[]),e["\u0275mpd"](4608,al.a,al.a,[]),e["\u0275mpd"](4608,dl.a,dl.b,[]),e["\u0275mpd"](1073742336,m.b,m.b,[]),e["\u0275mpd"](1073742336,p.t,p.t,[]),e["\u0275mpd"](1073742336,p.h,p.h,[]),e["\u0275mpd"](1073742336,rl.a,rl.a,[]),e["\u0275mpd"](1073742336,sl.a,sl.a,[]),e["\u0275mpd"](1073742336,cl.a,cl.a,[]),e["\u0275mpd"](1073742336,gl.a,gl.a,[]),e["\u0275mpd"](1073742336,pl.a,pl.a,[]),e["\u0275mpd"](1073742336,ml.a,ml.a,[]),e["\u0275mpd"](1073742336,vl.a,vl.a,[]),e["\u0275mpd"](1073742336,fl.a,fl.a,[]),e["\u0275mpd"](1073742336,hl.a,hl.a,[]),e["\u0275mpd"](1073742336,Cl.a,Cl.a,[]),e["\u0275mpd"](1073742336,bl.b,bl.b,[]),e["\u0275mpd"](1073742336,yl.a,yl.a,[]),e["\u0275mpd"](1073742336,Rl.a,Rl.a,[]),e["\u0275mpd"](1073742336,wl.a,wl.a,[]),e["\u0275mpd"](1073742336,Tl.a,Tl.a,[]),e["\u0275mpd"](1073742336,Pl.a,Pl.a,[]),e["\u0275mpd"](1073742336,R.b,R.b,[]),e["\u0275mpd"](1073742336,x.o,x.o,[[2,x.u],[2,x.l]]),e["\u0275mpd"](1073742336,kl.a,kl.a,[]),e["\u0275mpd"](1073742336,xl,xl,[]),e["\u0275mpd"](1073742336,t,t,[]),e["\u0275mpd"](256,W.a,W.b,[]),e["\u0275mpd"](1024,x.j,function(){return[[{path:"",component:P}]]},[])])})}}]);