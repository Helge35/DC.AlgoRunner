(window.webpackJsonp=window.webpackJsonp||[]).push([[17],{JSMj:function(l,n,u){"use strict";u.r(n);var e=u("CcnG"),t=function(){},o=u("4lDY"),i=u("u4HF"),a=u("aq8m"),r=u("qcfG"),d=u("xaNE"),c=u("FNNE"),s=u("gW6t"),p=u("pMnS"),g=u("Vez3"),f=u("kZVM"),m=u("gIcY"),v=u("Ip0R"),h=u("Xmcx"),b=u("zGav"),y=u("iCtU"),C=u("ZYCi"),j=u("/KjL"),x=u("FeSO"),R=u("cMcn"),I=u("5NFN"),w=u("NGEN"),P=u("AytR"),k=u("t/Na"),_=function(){function l(l){this._http=l,this.apiUrl=P.a.apiUrl+"projects"}return l.prototype.getProject=function(l){return this._http.get(this.apiUrl+"/"+l)},l.prototype.loadAlgsData=function(l){return this._http.get(this.apiUrl+"/LoadAllAlgs/")},l.prototype.execiteProject=function(l){return this._http.post(this.apiUrl+"ExeciteProject",l)},l.prototype.saveProject=function(l){return this._http.post(this.apiUrl,l)},l.ngInjectableDef=e.defineInjectable({factory:function(){return new l(e.inject(k.c))},token:l,providedIn:"root"}),l}(),A=u("YO4B"),M=u("ct8g"),O=function(){function l(l,n,u,e,t){this.activeRoute=l,this.route=n,this.http=u,this._projectsService=e,this._serviceActivity=t,this.algsCurrentpage=1}return l.prototype.getProject=function(){var l=this;this.http.getProject(this.id).subscribe(function(n){l.project=n,l.project.executionsList.forEach(function(l){l.resultPath=l.projectId.toString()+"_"+l.projectExecutionId.toString()})},function(l){console.log("Error: "+l.message)})},l.prototype.getActivities=function(){var l=this;this._serviceActivity.getActivities().subscribe(function(n){return l.activities=n})},l.prototype.addAlgToProject=function(l){this.project.algorithmsList.push(l),this.filterAlgs()},l.prototype.removeAlgFromProject=function(l){this.project.algorithmsList=this.project.algorithmsList.filter(function(n){return n!=l}),this.algs.find(function(n){return n.id==l.id}).isAttached=!1,this.filterAlgs()},l.prototype.saveProject=function(l){this.http.saveProject(l).subscribe(),this.route.navigate([""])},l.prototype.loadPageAlgs=function(l){var n=this;this._projectsService.loadAlgsData(l).subscribe(function(l){n.algs=l.algorithmsList,n.filterAlgs(),n.algsTotalItems=l.algorithmsTotalSize},function(l){console.log("Error: "+l.message)})},l.prototype.filterAlgs=function(){var l=this;this.project.algorithmsList.forEach(function(n){l.algs.find(function(l){return l.id==n.id}).isAttached=!0})},l.prototype.ngOnInit=function(){var l=this;this.activeRoute.params.subscribe(function(n){l.id=+n.id}),this.id?this.getProject():(this.project=new function(){},this.project.algorithmsList=[],this.getActivities(),this.loadPageAlgs(1))},l}(),T=e["\u0275crt"]({encapsulation:0,styles:[[".algo-ico[_ngcontent-%COMP%]{width:85%;height:60px;margin-left:16px;margin-bottom:5px;border:2px solid #125673;border-radius:6px;font-family:calibri;font-size:22px;color:#fff;background:#125673}.projects-section-header[_ngcontent-%COMP%]{font-family:calibri;font-size:22px;margin:10px 0 -10px 20px;height:50px}label[_ngcontent-%COMP%]{color:#125673}.submit-btn[_ngcontent-%COMP%]{background:0 0;font-family:calibri;font-size:22px;color:#fff;border-right:1px solid #a09c9c;border-radius:0}.btn-footer[_ngcontent-%COMP%]{height:50px;background:#125673;border:2px solid #125673;border-bottom-left-radius:6px;border-bottom-right-radius:6px}td[_ngcontent-%COMP%]{font-family:calibri;font-size:16px}th[_ngcontent-%COMP%]{max-width:80px;text-align:center}.attach-btn[_ngcontent-%COMP%]{background:0 0;border:transparent;margin-top:8px}.show-btn[_ngcontent-%COMP%]{background:#125673;font-family:calibri;font-size:12px;color:#fff}.execution-row[_ngcontent-%COMP%]{font-size:14px}.execution-row-ico[_ngcontent-%COMP%]{height:26px;width:26px}"]],data:{}});function E(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"projects-page-header",[],null,null,null,g.b,g.a)),e["\u0275did"](1,114688,null,0,f.a,[],{header:[0,"header"]},null)],function(l,n){l(n,1,0,n.component.project.name)},null)}function V(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"projects-page-header",[],null,null,null,g.b,g.a)),e["\u0275did"](1,114688,null,0,f.a,[],{header:[0,"header"]},null)],function(l,n){l(n,1,0,"New project")},null)}function L(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,4,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Project:"])),(l()(),e["\u0275eld"](3,0,null,null,1,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](4,0,null,null,0,"input",[["class","form-control"],["readonly",""],["type","text"]],[[8,"value",0]],null,null,null,null))],null,function(l,n){l(n,4,0,e["\u0275inlineInterpolate"](1,"",n.component.project.activity.name,""))})}function S(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,3,"option",[],null,null,null,null,null)),e["\u0275did"](1,147456,null,0,m.p,[e.ElementRef,e.Renderer2,[2,m.s]],{ngValue:[0,"ngValue"]},null),e["\u0275did"](2,147456,null,0,m.y,[e.ElementRef,e.Renderer2,[8,null]],{ngValue:[0,"ngValue"]},null),(l()(),e["\u0275ted"](3,null,[" "," "]))],function(l,n){l(n,1,0,n.context.$implicit),l(n,2,0,n.context.$implicit)},function(l,n){l(n,3,0,n.context.$implicit.name)})}function D(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Activity is required "]))],null,null)}function N(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,15,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Project:"])),(l()(),e["\u0275eld"](3,0,null,null,12,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](4,0,null,null,9,"select",[["name","projactivity"],["required",""]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"change"],[null,"blur"]],function(l,n,u){var t=!0,o=l.component;return"change"===n&&(t=!1!==e["\u0275nov"](l,5).onChange(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,5).onTouched()&&t),"ngModelChange"===n&&(t=!1!==(o.project.activity=u)&&t),t},null,null)),e["\u0275did"](5,16384,null,0,m.s,[e.Renderer2,e.ElementRef],null,null),e["\u0275did"](6,16384,null,0,m.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,m.i,function(l){return[l]},[m.r]),e["\u0275prd"](1024,null,m.j,function(l){return[l]},[m.s]),e["\u0275did"](9,671744,[["projactivity",4]],0,m.o,[[8,null],[6,m.i],[8,null],[6,m.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,m.k,null,[m.o]),e["\u0275did"](11,16384,null,0,m.l,[[4,m.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,S)),e["\u0275did"](13,278528,null,0,v.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,D)),e["\u0275did"](15,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null)],function(l,n){var u=n.component;l(n,6,0,""),l(n,9,0,"projactivity",u.project.activity),l(n,13,0,u.activities),l(n,15,0,u.submitted&&u.algactivity.invalid)},function(l,n){l(n,4,0,e["\u0275nov"](n,6).required?"":null,e["\u0275nov"](n,11).ngClassUntouched,e["\u0275nov"](n,11).ngClassTouched,e["\u0275nov"](n,11).ngClassPristine,e["\u0275nov"](n,11).ngClassDirty,e["\u0275nov"](n,11).ngClassValid,e["\u0275nov"](n,11).ngClassInvalid,e["\u0275nov"](n,11).ngClassPending)})}function F(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,2,"button",[["aria-label","Close"],["class","close float-left attach-btn"],["style","margin-left: 5px; color: #125673;"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.removeAlgFromProject(l.parent.context.$implicit)&&e),e},null,null)),(l()(),e["\u0275eld"](1,0,null,null,1,"span",[["aria-hidden","true"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xd7"]))],null,null)}function $(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,5,"div",[],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,2,"div",[["class","algo-ico float-left"]],null,null,null,null,null)),(l()(),e["\u0275eld"](2,0,null,null,1,"algo-ico",[],null,null,null,h.b,h.a)),e["\u0275did"](3,114688,null,0,b.a,[y.a,C.l],{activityName:[0,"activityName"],alg:[1,"alg"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,F)),e["\u0275did"](5,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null)],function(l,n){var u=n.component;l(n,3,0,n.context.$implicit.activity?n.context.$implicit.activity.name:"",n.context.$implicit),l(n,5,0,!u.project.id)},null)}function U(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,3,"button",[["class","btn btn-lg submit-btn"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0,t=l.component;return"click"===n&&(e=!1!==t.saveProject(t.project)&&e),e},null,null)),(l()(),e["\u0275eld"](1,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),e["\u0275eld"](2,0,null,null,0,"i",[["class","fa fa-save"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xa0\xa0Save"]))],null,null)}function z(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,5,"button",[["class","btn btn-lg submit-btn"],["type","button"]],null,[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==e["\u0275nov"](l,1).onClick()&&t),t},null,null)),e["\u0275did"](1,16384,null,0,C.m,[C.l,C.a,[8,null],e.Renderer2,e.ElementRef],{routerLink:[0,"routerLink"]},null),e["\u0275pad"](2,3),(l()(),e["\u0275eld"](3,0,null,null,2,"span",[],null,null,null,null,null)),(l()(),e["\u0275eld"](4,0,null,null,0,"i",[["class","fa fa-arrow-circle-right"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xa0\xa0Execute"]))],function(l,n){l(n,1,0,l(n,2,0,"/algoexe",n.component.project.id,0))},null)}function q(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,26,"tr",[],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,1,"td",[["class","execution-row"]],null,null,null,null,null)),(l()(),e["\u0275ted"](2,null,["",""])),(l()(),e["\u0275eld"](3,0,null,null,2,"td",[["class","execution-row"]],null,null,null,null,null)),(l()(),e["\u0275ted"](4,null,["",""])),e["\u0275ppd"](5,2),(l()(),e["\u0275eld"](6,0,null,null,2,"td",[["class","execution-row"]],null,null,null,null,null)),(l()(),e["\u0275ted"](7,null,["",""])),e["\u0275ppd"](8,2),(l()(),e["\u0275eld"](9,0,null,null,10,"td",[],null,null,null,null,null)),(l()(),e["\u0275eld"](10,16777216,null,null,4,"div",[["triggers","hover:blur click:blur focus:blur"]],[[8,"hidden",0]],null,null,null,null)),e["\u0275did"](11,278528,null,0,v.p,[e.KeyValueDiffers,e.ElementRef,e.Renderer2],{ngStyle:[0,"ngStyle"]},null),e["\u0275pod"](12,{"left.px":0,"top.px":1}),e["\u0275did"](13,212992,null,0,j.a,[e.ElementRef,e.Renderer2,e.Injector,e.ComponentFactoryResolver,e.ViewContainerRef,x.a,e.NgZone],{triggers:[0,"triggers"],ngbTooltip:[1,"ngbTooltip"]},null),(l()(),e["\u0275eld"](14,0,null,null,0,"img",[["class","execution-row-ico"],["src","../../../assets/images/Ic_execution_failure.svg"]],null,null,null,null,null)),(l()(),e["\u0275eld"](15,16777216,null,null,4,"div",[["triggers","hover:blur click:blur focus:blur"]],[[8,"hidden",0]],null,null,null,null)),e["\u0275did"](16,278528,null,0,v.p,[e.KeyValueDiffers,e.ElementRef,e.Renderer2],{ngStyle:[0,"ngStyle"]},null),e["\u0275pod"](17,{"left.px":0,"top.px":1}),e["\u0275did"](18,212992,null,0,j.a,[e.ElementRef,e.Renderer2,e.Injector,e.ComponentFactoryResolver,e.ViewContainerRef,x.a,e.NgZone],{triggers:[0,"triggers"],ngbTooltip:[1,"ngbTooltip"]},null),(l()(),e["\u0275eld"](19,0,null,null,0,"img",[["class","execution-row-ico"],["src","../../../assets/images/Ic_execution_warnning.svg"]],null,null,null,null,null)),(l()(),e["\u0275eld"](20,0,null,null,6,"td",[],null,null,null,null,null)),(l()(),e["\u0275eld"](21,0,null,null,5,"button",[["class","show-btn"],["type","button"]],[[8,"hidden",0]],[[null,"click"]],function(l,n,u){var t=!0;return"click"===n&&(t=!1!==e["\u0275nov"](l,22).onClick()&&t),t},null,null)),e["\u0275did"](22,16384,null,0,C.m,[C.l,C.a,[8,null],e.Renderer2,e.ElementRef],{routerLink:[0,"routerLink"]},null),e["\u0275pad"](23,2),(l()(),e["\u0275ted"](-1,null,["Show \xa0 "])),(l()(),e["\u0275eld"](25,0,null,null,1,"span",[],null,null,null,null,null)),(l()(),e["\u0275eld"](26,0,null,null,0,"i",[["class","fa fa-arrow-right"]],null,null,null,null,null))],function(l,n){var u=n.component;l(n,11,0,l(n,12,0,u.leftPosition,u.topPosition)),l(n,13,0,"hover:blur click:blur focus:blur",e["\u0275inlineInterpolate"](1,"",n.context.$implicit.failureReason,"")),l(n,16,0,l(n,17,0,u.leftPosition,u.topPosition)),l(n,18,0,"hover:blur click:blur focus:blur",e["\u0275inlineInterpolate"](1,"",n.context.$implicit.failureReason,"")),l(n,22,0,l(n,23,0,"/results",n.context.$implicit.resultPath))},function(l,n){l(n,2,0,n.context.$implicit.executedBy),l(n,4,0,e["\u0275unv"](n,4,0,l(n,5,0,e["\u0275nov"](n.parent.parent.parent,0),n.context.$implicit.startDate,"dd/MM/yy HH:mm"))),l(n,7,0,e["\u0275unv"](n,7,0,l(n,8,0,e["\u0275nov"](n.parent.parent.parent,0),n.context.$implicit.endDate,"dd/MM/yy HH:mm"))),l(n,10,0,2!=n.context.$implicit.executionResult),l(n,15,0,1!=n.context.$implicit.executionResult),l(n,21,0,2==n.context.$implicit.executionResult)})}function Z(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,19,"div",[],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,18,"div",[["class","card mb-3"]],null,null,null,null,null)),(l()(),e["\u0275eld"](2,0,null,null,1,"div",[["class","projects-section-header"],["style","color: #125673;"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" EXECUTION PLANS "])),(l()(),e["\u0275eld"](4,0,null,null,15,"table",[["class","table table-hover "]],null,null,null,null,null)),(l()(),e["\u0275eld"](5,0,null,null,11,"thead",[],null,null,null,null,null)),(l()(),e["\u0275eld"](6,0,null,null,10,"tr",[],null,null,null,null,null)),(l()(),e["\u0275eld"](7,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["By"])),(l()(),e["\u0275eld"](9,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Started"])),(l()(),e["\u0275eld"](11,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Ended"])),(l()(),e["\u0275eld"](13,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xa0"])),(l()(),e["\u0275eld"](15,0,null,null,1,"th",[],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xa0"])),(l()(),e["\u0275eld"](17,0,null,null,2,"tbody",[],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,q)),e["\u0275did"](19,278528,null,0,v.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null)],function(l,n){l(n,19,0,n.component.project.executionsList)},null)}function B(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,6,"div",[],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,2,"button",[["class","float-left attach-btn"],["type","button"]],[[1,"disabled",0]],[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.addAlgToProject(l.context.$implicit)&&e),e},null,null)),(l()(),e["\u0275eld"](2,0,null,null,1,"span",[],null,null,null,null,null)),(l()(),e["\u0275eld"](3,0,null,null,0,"i",[["class","fa fa-2x fa-arrow-circle-left"]],null,null,null,null,null)),(l()(),e["\u0275eld"](4,0,null,null,2,"div",[["class","algo-ico"],["style","margin-left: 38px"]],null,null,null,null,null)),(l()(),e["\u0275eld"](5,0,null,null,1,"algo-ico",[],null,null,null,h.b,h.a)),e["\u0275did"](6,114688,null,0,b.a,[y.a,C.l],{activityName:[0,"activityName"],alg:[1,"alg"]},null)],function(l,n){l(n,6,0,n.context.$implicit.activity?n.context.$implicit.activity.name:"",n.context.$implicit)},function(l,n){l(n,1,0,!!n.context.$implicit.isAttached||null)})}function G(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,9,"div",[["class","col-xl-3"]],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,8,"div",[["class","card mb-3"]],null,null,null,null,null)),(l()(),e["\u0275eld"](2,0,null,null,1,"div",[["class","projects-section-header"],["style","color: #125673;"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" AVAILABLE ALGORITHMS "])),(l()(),e["\u0275eld"](4,0,null,null,2,"div",[["style","height:72vh;"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,B)),e["\u0275did"](6,278528,null,0,v.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275eld"](7,0,null,null,2,"div",[["style","height:50px; margin-top: 2px"]],null,null,null,null,null)),(l()(),e["\u0275eld"](8,0,null,null,1,"ngb-pagination",[["class","d-flex justify-content-center"],["role","navigation"]],null,[[null,"pageChange"]],function(l,n,u){var e=!0,t=l.component;return"pageChange"===n&&(e=!1!==(t.algsCurrentpage=u)&&e),"pageChange"===n&&(e=!1!==t.loadPageAlgs(u)&&e),e},R.b,R.a)),e["\u0275did"](9,573440,null,0,I.a,[w.a],{collectionSize:[0,"collectionSize"],page:[1,"page"],pageSize:[2,"pageSize"]},{pageChange:"pageChange"})],function(l,n){var u=n.component;l(n,6,0,u.algs),l(n,9,0,u.algsTotalItems,u.algsCurrentpage,14)},null)}function Y(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,62,"div",[],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,E)),e["\u0275did"](2,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,V)),e["\u0275did"](4,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](5,0,null,null,57,"div",[["class","row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](6,0,null,null,52,"div",[["class","col-xl-9"]],null,null,null,null,null)),(l()(),e["\u0275eld"](7,0,null,null,51,"div",[["class","card mb-3"]],null,null,null,null,null)),(l()(),e["\u0275eld"](8,0,null,null,45,"div",[["class","modal-body"],["style","height:77vh;"]],null,null,null,null,null)),(l()(),e["\u0275eld"](9,0,null,null,44,"div",[["class","row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](10,0,null,null,35,"div",[["class","col-xl-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](11,0,null,null,34,"fieldset",[],null,null,null,null,null)),(l()(),e["\u0275eld"](12,0,null,null,9,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](13,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Name:"])),(l()(),e["\u0275eld"](15,0,null,null,6,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](16,0,null,null,5,"input",[["class","form-control"],["type","text"]],[[8,"readOnly",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,17)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,17).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,17)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,17)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.project.name=u)&&t),t},null,null)),e["\u0275did"](17,16384,null,0,m.d,[e.Renderer2,e.ElementRef,[2,m.a]],null,null),e["\u0275prd"](1024,null,m.j,function(l){return[l]},[m.d]),e["\u0275did"](19,671744,null,0,m.o,[[8,null],[8,null],[8,null],[6,m.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,m.k,null,[m.o]),e["\u0275did"](21,16384,null,0,m.l,[[4,m.k]],null,null),(l()(),e["\u0275eld"](22,0,null,null,9,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](23,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Description:"])),(l()(),e["\u0275eld"](25,0,null,null,6,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](26,0,null,null,5,"textarea",[["class","form-control"],["rows","3"]],[[8,"readOnly",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,27)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,27).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,27)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,27)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.project.desc=u)&&t),t},null,null)),e["\u0275did"](27,16384,null,0,m.d,[e.Renderer2,e.ElementRef,[2,m.a]],null,null),e["\u0275prd"](1024,null,m.j,function(l){return[l]},[m.d]),e["\u0275did"](29,671744,null,0,m.o,[[8,null],[8,null],[8,null],[6,m.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,m.k,null,[m.o]),e["\u0275did"](31,16384,null,0,m.l,[[4,m.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,L)),e["\u0275did"](33,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,N)),e["\u0275did"](35,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](36,0,null,null,9,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](37,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Created by:"])),(l()(),e["\u0275eld"](39,0,null,null,6,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](40,0,null,null,5,"input",[["class","form-control"],["type","text"]],[[8,"readOnly",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,o=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,41)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,41).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,41)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,41)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(o.project.createdBy=u)&&t),t},null,null)),e["\u0275did"](41,16384,null,0,m.d,[e.Renderer2,e.ElementRef,[2,m.a]],null,null),e["\u0275prd"](1024,null,m.j,function(l){return[l]},[m.d]),e["\u0275did"](43,671744,null,0,m.o,[[8,null],[8,null],[8,null],[6,m.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,m.k,null,[m.o]),e["\u0275did"](45,16384,null,0,m.l,[[4,m.k]],null,null),(l()(),e["\u0275eld"](46,0,null,null,7,"div",[["class","col-xl-4"]],null,null,null,null,null)),(l()(),e["\u0275eld"](47,0,null,null,6,"div",[["class","form-group"]],null,null,null,null,null)),(l()(),e["\u0275eld"](48,0,null,null,1,"label",[["class"," col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["Algorithms:"])),(l()(),e["\u0275eld"](50,0,null,null,3,"div",[["class","card mb-4"]],null,null,null,null,null)),(l()(),e["\u0275eld"](51,0,null,null,2,"div",[["class","card-body"],["style","height:70vh; overflow-y: auto; overflow-x: hidden;"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,$)),e["\u0275did"](53,278528,null,0,v.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275eld"](54,0,null,null,4,"div",[["class","col-xl-12 btn-footer"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,U)),e["\u0275did"](56,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,z)),e["\u0275did"](58,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,Z)),e["\u0275did"](60,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275and"](16777216,null,null,1,null,G)),e["\u0275did"](62,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null)],function(l,n){var u=n.component;l(n,2,0,u.project.id),l(n,4,0,!u.project.id),l(n,19,0,u.project.name),l(n,29,0,u.project.desc),l(n,33,0,u.project.activity&&u.project.id),l(n,35,0,!u.project.id),l(n,43,0,u.project.createdBy),l(n,53,0,u.project.algorithmsList),l(n,56,0,!u.project.id),l(n,58,0,u.project.id),l(n,60,0,u.project.id),l(n,62,0,!u.project.id)},function(l,n){var u=n.component;l(n,16,0,u.project.id,e["\u0275nov"](n,21).ngClassUntouched,e["\u0275nov"](n,21).ngClassTouched,e["\u0275nov"](n,21).ngClassPristine,e["\u0275nov"](n,21).ngClassDirty,e["\u0275nov"](n,21).ngClassValid,e["\u0275nov"](n,21).ngClassInvalid,e["\u0275nov"](n,21).ngClassPending),l(n,26,0,u.project.id,e["\u0275nov"](n,31).ngClassUntouched,e["\u0275nov"](n,31).ngClassTouched,e["\u0275nov"](n,31).ngClassPristine,e["\u0275nov"](n,31).ngClassDirty,e["\u0275nov"](n,31).ngClassValid,e["\u0275nov"](n,31).ngClassInvalid,e["\u0275nov"](n,31).ngClassPending),l(n,40,0,u.project.id,e["\u0275nov"](n,45).ngClassUntouched,e["\u0275nov"](n,45).ngClassTouched,e["\u0275nov"](n,45).ngClassPristine,e["\u0275nov"](n,45).ngClassDirty,e["\u0275nov"](n,45).ngClassValid,e["\u0275nov"](n,45).ngClassInvalid,e["\u0275nov"](n,45).ngClassPending)})}function H(l){return e["\u0275vid"](0,[e["\u0275pid"](0,v.d,[e.LOCALE_ID]),(l()(),e["\u0275and"](16777216,null,null,1,null,Y)),e["\u0275did"](2,16384,null,0,v.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null)],function(l,n){l(n,2,0,n.component.project)},null)}var K=e["\u0275ccf"]("app-projects-detail",O,function(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"app-projects-detail",[],null,null,null,H,T)),e["\u0275did"](1,114688,null,0,O,[C.a,C.l,_,M.a,A.a],null,null)],function(l,n){l(n,1,0)},null)},{},{},[]),J=u("9eRs"),X=u("Ovjw"),W=u("e5OV"),Q=u("8NoF"),ll=u("ysnj"),nl=u("5sLU"),ul=u("oYRQ"),el=u("q7oS"),tl=u("OU4G"),ol=u("bSlz"),il=u("9n00"),al=u("/onb"),rl=u("Ok6J"),dl=u("ebCm"),cl=u("ejuw"),sl=u("swaV"),pl=u("Zt+D"),gl=u("lMb6"),fl=u("Bia8"),ml=u("bt6x"),vl=u("0XGt"),hl=u("nhl2"),bl=u("gpiN"),yl=u("MVL9"),Cl=u("j2fZ"),jl=u("LKjY"),xl=u("PsaP"),Rl=u("InZo"),Il=u("C9m0"),wl=u("+NDo"),Pl=u("4WQT"),kl=u("wtSO"),_l=u("NlYj"),Al=u("neuq"),Ml=u("y+WT"),Ol=u("eUd/"),Tl=function(){},El=u("XfKo"),Vl=u("ZyC5");u.d(n,"ProjectsDetailModuleNgFactory",function(){return Ll});var Ll=e["\u0275cmf"](t,[],function(l){return e["\u0275mod"]([e["\u0275mpd"](512,e.ComponentFactoryResolver,e["\u0275CodegenComponentFactoryResolver"],[[8,[o.a,i.a,a.a,r.a,d.a,c.a,s.a,p.a,K]],[3,e.ComponentFactoryResolver],e.NgModuleRef]),e["\u0275mpd"](4608,v.o,v.n,[e.LOCALE_ID,[2,v.A]]),e["\u0275mpd"](4608,m.w,m.w,[]),e["\u0275mpd"](4608,J.a,J.a,[v.c]),e["\u0275mpd"](4608,X.a,X.a,[e.ApplicationRef,e.Injector,e.ComponentFactoryResolver,v.c,J.a]),e["\u0275mpd"](4608,y.a,y.a,[e.ComponentFactoryResolver,e.Injector,X.a]),e["\u0275mpd"](4608,W.a,W.a,[]),e["\u0275mpd"](4608,Q.a,Q.a,[]),e["\u0275mpd"](4608,x.a,x.a,[]),e["\u0275mpd"](135680,ll.c,ll.c,[v.c,ll.a]),e["\u0275mpd"](4608,nl.a,nl.a,[]),e["\u0275mpd"](4608,ul.a,ul.a,[]),e["\u0275mpd"](4608,el.a,el.a,[]),e["\u0275mpd"](4608,tl.a,tl.b,[]),e["\u0275mpd"](4608,v.d,v.d,[e.LOCALE_ID]),e["\u0275mpd"](4608,ol.a,ol.b,[e.LOCALE_ID,v.d]),e["\u0275mpd"](4608,il.b,il.a,[]),e["\u0275mpd"](4608,al.a,al.b,[]),e["\u0275mpd"](4608,rl.a,rl.a,[]),e["\u0275mpd"](4608,dl.a,dl.a,[]),e["\u0275mpd"](4608,w.a,w.a,[]),e["\u0275mpd"](4608,cl.a,cl.a,[]),e["\u0275mpd"](4608,sl.a,sl.a,[]),e["\u0275mpd"](4608,pl.a,pl.a,[]),e["\u0275mpd"](4608,gl.a,gl.a,[]),e["\u0275mpd"](4608,fl.a,fl.b,[]),e["\u0275mpd"](1073742336,v.b,v.b,[]),e["\u0275mpd"](1073742336,m.t,m.t,[]),e["\u0275mpd"](1073742336,m.h,m.h,[]),e["\u0275mpd"](1073742336,ml.a,ml.a,[]),e["\u0275mpd"](1073742336,vl.a,vl.a,[]),e["\u0275mpd"](1073742336,hl.a,hl.a,[]),e["\u0275mpd"](1073742336,bl.a,bl.a,[]),e["\u0275mpd"](1073742336,yl.a,yl.a,[]),e["\u0275mpd"](1073742336,Cl.a,Cl.a,[]),e["\u0275mpd"](1073742336,jl.a,jl.a,[]),e["\u0275mpd"](1073742336,xl.a,xl.a,[]),e["\u0275mpd"](1073742336,Rl.a,Rl.a,[]),e["\u0275mpd"](1073742336,Il.a,Il.a,[]),e["\u0275mpd"](1073742336,wl.b,wl.b,[]),e["\u0275mpd"](1073742336,Pl.a,Pl.a,[]),e["\u0275mpd"](1073742336,kl.a,kl.a,[]),e["\u0275mpd"](1073742336,_l.a,_l.a,[]),e["\u0275mpd"](1073742336,Al.a,Al.a,[]),e["\u0275mpd"](1073742336,Ml.a,Ml.a,[]),e["\u0275mpd"](1073742336,Ol.b,Ol.b,[]),e["\u0275mpd"](1073742336,C.o,C.o,[[2,C.u],[2,C.l]]),e["\u0275mpd"](1073742336,Tl,Tl,[]),e["\u0275mpd"](1073742336,El.a,El.a,[]),e["\u0275mpd"](1073742336,Vl.a,Vl.a,[]),e["\u0275mpd"](1073742336,t,t,[]),e["\u0275mpd"](256,ll.a,ll.b,[]),e["\u0275mpd"](1024,C.j,function(){return[[{path:"",component:O}]]},[])])})}}]);