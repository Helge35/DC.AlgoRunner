(window.webpackJsonp=window.webpackJsonp||[]).push([[16],{"7mP2":function(l,n,u){"use strict";u.r(n);var e=u("CcnG"),t=function(){},i=u("4lDY"),o=u("u4HF"),a=u("aq8m"),d=u("qcfG"),r=u("xaNE"),c=u("FNNE"),s=u("gW6t"),m=u("pMnS"),v=u("Vez3"),p=u("kZVM"),g=u("gIcY"),f=u("Ip0R"),h=u("obJw"),b=u("IYfF"),C=u("YO4B"),y=function(){function l(l,n){this._service=l,this._serviceActivity=n,this.submitted=!1}return l.prototype.getAdminInfo=function(){var l=this;this._serviceActivity.getActivities().subscribe(function(n){l.commonActivitie=n.find(function(l){return 1==l.id}),l.activities=n.filter(function(l){return l.id>1})})},l.prototype.addActivity=function(l){var n=this,u=l.valid;this.submitted=!0,u&&(this._serviceActivity.addActivity(this.newActivitie).subscribe(function(l){n.newActivitie=new h.a,n.activities.push(l)}),this.submitted=!1)},l.prototype.removeActivity=function(l){confirm("Are you sure to delete activity")&&(this._serviceActivity.removeActivity(l),this.activities=this.activities.filter(function(n){return n.id!==l}))},l.prototype.saveCommonPath=function(){this._serviceActivity.saveCommonPath(this.commonActivitie)},l.prototype.ngOnInit=function(){this.newActivitie=new h.a,this.getAdminInfo(),this.commonActivitie=new h.a},l}(),A=e["\u0275crt"]({encapsulation:0,styles:[[""]],data:{}});function w(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,11,"div",[["class","list-group-item clearfix d-block"],["href","#"]],null,null,null,null,null)),(l()(),e["\u0275eld"](1,0,null,null,10,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](2,0,null,null,1,"label",[["class","col-3 col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](3,null,["",""])),(l()(),e["\u0275eld"](4,0,null,null,2,"div",[["class","col-8"]],null,null,null,null,null)),(l()(),e["\u0275eld"](5,0,null,null,1,"label",[["class","col-form-label"]],null,null,null,null,null)),(l()(),e["\u0275ted"](6,null,["",""])),(l()(),e["\u0275eld"](7,0,null,null,4,"span",[["class","float-right text-muted small"]],null,null,null,null,null)),(l()(),e["\u0275eld"](8,0,null,null,3,"em",[],null,null,null,null,null)),(l()(),e["\u0275eld"](9,0,null,null,2,"button",[["aria-label","Close"],["class","close"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.removeActivity(l.context.$implicit.id)&&e),e},null,null)),(l()(),e["\u0275eld"](10,0,null,null,1,"span",[["aria-hidden","true"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,["\xd7"]))],null,function(l,n){l(n,3,0,n.context.$implicit.name),l(n,6,0,n.context.$implicit.serverPath)})}function I(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Activity name is required "]))],null,null)}function P(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"div",[["style","color:red"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Activity server path is required "]))],null,null)}function R(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"projects-page-header",[],null,null,null,v.b,v.a)),e["\u0275did"](1,114688,null,0,p.a,[],{header:[0,"header"]},null),(l()(),e["\u0275eld"](2,0,null,null,57,"div",[["class","row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](3,0,null,null,38,"div",[["class","col-lg-6"]],null,null,null,null,null)),(l()(),e["\u0275eld"](4,0,null,null,37,"form",[["novalidate",""]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngSubmit"],[null,"submit"],[null,"reset"]],function(l,n,u){var t=!0,i=l.component;return"submit"===n&&(t=!1!==e["\u0275nov"](l,6).onSubmit(u)&&t),"reset"===n&&(t=!1!==e["\u0275nov"](l,6).onReset()&&t),"ngSubmit"===n&&(t=!1!==i.addActivity(e["\u0275nov"](l,6))&&t),t},null,null)),e["\u0275did"](5,16384,null,0,g.v,[],null,null),e["\u0275did"](6,4210688,[["mform",4]],0,g.n,[[8,null],[8,null]],null,{ngSubmit:"ngSubmit"}),e["\u0275prd"](2048,null,g.c,null,[g.n]),e["\u0275did"](8,16384,null,0,g.m,[[4,g.c]],null,null),(l()(),e["\u0275eld"](9,0,null,null,32,"div",[["class","card card-default mb-6"]],null,null,null,null,null)),(l()(),e["\u0275eld"](10,0,null,null,2,"div",[["class","card-header"]],null,null,null,null,null)),(l()(),e["\u0275eld"](11,0,null,null,0,"i",[["class","fa fa-bolt fa-fw"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Activities "])),(l()(),e["\u0275eld"](13,0,null,null,3,"div",[["class","card-body"]],null,null,null,null,null)),(l()(),e["\u0275eld"](14,0,null,null,2,"div",[["class","list-group"]],null,null,null,null,null)),(l()(),e["\u0275and"](16777216,null,null,1,null,w)),e["\u0275did"](16,278528,null,0,f.l,[e.ViewContainerRef,e.TemplateRef,e.IterableDiffers],{ngForOf:[0,"ngForOf"]},null),(l()(),e["\u0275eld"](17,0,null,null,24,"div",[["class","card-footer"]],null,null,null,null,null)),(l()(),e["\u0275eld"](18,0,null,null,23,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](19,0,null,null,10,"div",[["class","col-5"]],null,null,null,null,null)),(l()(),e["\u0275eld"](20,0,null,null,7,"input",[["class","form-control"],["name","newActivitieName"],["placeholder","Activity name"],["required",""],["type","text"]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,i=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,21)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,21).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,21)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,21)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(i.newActivitie.name=u)&&t),t},null,null)),e["\u0275did"](21,16384,null,0,g.d,[e.Renderer2,e.ElementRef,[2,g.a]],null,null),e["\u0275did"](22,16384,null,0,g.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,g.i,function(l){return[l]},[g.r]),e["\u0275prd"](1024,null,g.j,function(l){return[l]},[g.d]),e["\u0275did"](25,671744,[["newActivitieName",4]],0,g.o,[[2,g.c],[6,g.i],[8,null],[6,g.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,g.k,null,[g.o]),e["\u0275did"](27,16384,null,0,g.l,[[4,g.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,I)),e["\u0275did"](29,16384,null,0,f.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](30,0,null,null,10,"div",[["class","col-5"]],null,null,null,null,null)),(l()(),e["\u0275eld"](31,0,null,null,7,"input",[["class","form-control"],["name","newActivitieServerPath"],["placeholder","Algorithm path"],["required",""],["type","text"]],[[1,"required",0],[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,i=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,32)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,32).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,32)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,32)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(i.newActivitie.serverPath=u)&&t),t},null,null)),e["\u0275did"](32,16384,null,0,g.d,[e.Renderer2,e.ElementRef,[2,g.a]],null,null),e["\u0275did"](33,16384,null,0,g.r,[],{required:[0,"required"]},null),e["\u0275prd"](1024,null,g.i,function(l){return[l]},[g.r]),e["\u0275prd"](1024,null,g.j,function(l){return[l]},[g.d]),e["\u0275did"](36,671744,[["newActivitieServerPath",4]],0,g.o,[[2,g.c],[6,g.i],[8,null],[6,g.j]],{name:[0,"name"],model:[1,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,g.k,null,[g.o]),e["\u0275did"](38,16384,null,0,g.l,[[4,g.k]],null,null),(l()(),e["\u0275and"](16777216,null,null,1,null,P)),e["\u0275did"](40,16384,null,0,f.m,[e.ViewContainerRef,e.TemplateRef],{ngIf:[0,"ngIf"]},null),(l()(),e["\u0275eld"](41,0,null,null,0,"button",[["class","fa fa-save fa-2x col-2"],["type","submit"]],null,null,null,null,null)),(l()(),e["\u0275eld"](42,0,null,null,17,"div",[["class","col-lg-6"]],null,null,null,null,null)),(l()(),e["\u0275eld"](43,0,null,null,16,"div",[["class","card card-default mb-6"]],null,null,null,null,null)),(l()(),e["\u0275eld"](44,0,null,null,2,"div",[["class","card-header"]],null,null,null,null,null)),(l()(),e["\u0275eld"](45,0,null,null,0,"i",[["class","fa fa-bolt fa-fw"]],null,null,null,null,null)),(l()(),e["\u0275ted"](-1,null,[" Common activity "])),(l()(),e["\u0275eld"](47,0,null,null,11,"div",[],null,null,null,null,null)),(l()(),e["\u0275eld"](48,0,null,null,10,"div",[["class","list-group"]],null,null,null,null,null)),(l()(),e["\u0275eld"](49,0,null,null,9,"div",[["class","list-group-item clearfix d-block"],["href","#"]],null,null,null,null,null)),(l()(),e["\u0275eld"](50,0,null,null,8,"div",[["class","form-group row"]],null,null,null,null,null)),(l()(),e["\u0275eld"](51,0,null,null,6,"div",[["class","col-11"]],null,null,null,null,null)),(l()(),e["\u0275eld"](52,0,null,null,5,"input",[["class","form-control"],["type","text"]],[[2,"ng-untouched",null],[2,"ng-touched",null],[2,"ng-pristine",null],[2,"ng-dirty",null],[2,"ng-valid",null],[2,"ng-invalid",null],[2,"ng-pending",null]],[[null,"ngModelChange"],[null,"input"],[null,"blur"],[null,"compositionstart"],[null,"compositionend"]],function(l,n,u){var t=!0,i=l.component;return"input"===n&&(t=!1!==e["\u0275nov"](l,53)._handleInput(u.target.value)&&t),"blur"===n&&(t=!1!==e["\u0275nov"](l,53).onTouched()&&t),"compositionstart"===n&&(t=!1!==e["\u0275nov"](l,53)._compositionStart()&&t),"compositionend"===n&&(t=!1!==e["\u0275nov"](l,53)._compositionEnd(u.target.value)&&t),"ngModelChange"===n&&(t=!1!==(i.commonActivitie.serverPath=u)&&t),t},null,null)),e["\u0275did"](53,16384,null,0,g.d,[e.Renderer2,e.ElementRef,[2,g.a]],null,null),e["\u0275prd"](1024,null,g.j,function(l){return[l]},[g.d]),e["\u0275did"](55,671744,null,0,g.o,[[8,null],[8,null],[8,null],[6,g.j]],{model:[0,"model"]},{update:"ngModelChange"}),e["\u0275prd"](2048,null,g.k,null,[g.o]),e["\u0275did"](57,16384,null,0,g.l,[[4,g.k]],null,null),(l()(),e["\u0275eld"](58,0,null,null,0,"button",[["class","fa fa-save fa-2x"],["type","button"]],null,[[null,"click"]],function(l,n,u){var e=!0;return"click"===n&&(e=!1!==l.component.saveCommonPath()&&e),e},null,null)),(l()(),e["\u0275eld"](59,0,null,null,0,"div",[["class","card-footer"]],null,null,null,null,null))],function(l,n){var u=n.component;l(n,1,0,"Admin Panel"),l(n,16,0,u.activities),l(n,22,0,""),l(n,25,0,"newActivitieName",u.newActivitie.name),l(n,29,0,u.submitted&&e["\u0275nov"](n,25).invalid),l(n,33,0,""),l(n,36,0,"newActivitieServerPath",u.newActivitie.serverPath),l(n,40,0,u.submitted&&e["\u0275nov"](n,36).invalid),l(n,55,0,u.commonActivitie.serverPath)},function(l,n){l(n,4,0,e["\u0275nov"](n,8).ngClassUntouched,e["\u0275nov"](n,8).ngClassTouched,e["\u0275nov"](n,8).ngClassPristine,e["\u0275nov"](n,8).ngClassDirty,e["\u0275nov"](n,8).ngClassValid,e["\u0275nov"](n,8).ngClassInvalid,e["\u0275nov"](n,8).ngClassPending),l(n,20,0,e["\u0275nov"](n,22).required?"":null,e["\u0275nov"](n,27).ngClassUntouched,e["\u0275nov"](n,27).ngClassTouched,e["\u0275nov"](n,27).ngClassPristine,e["\u0275nov"](n,27).ngClassDirty,e["\u0275nov"](n,27).ngClassValid,e["\u0275nov"](n,27).ngClassInvalid,e["\u0275nov"](n,27).ngClassPending),l(n,31,0,e["\u0275nov"](n,33).required?"":null,e["\u0275nov"](n,38).ngClassUntouched,e["\u0275nov"](n,38).ngClassTouched,e["\u0275nov"](n,38).ngClassPristine,e["\u0275nov"](n,38).ngClassDirty,e["\u0275nov"](n,38).ngClassValid,e["\u0275nov"](n,38).ngClassInvalid,e["\u0275nov"](n,38).ngClassPending),l(n,52,0,e["\u0275nov"](n,57).ngClassUntouched,e["\u0275nov"](n,57).ngClassTouched,e["\u0275nov"](n,57).ngClassPristine,e["\u0275nov"](n,57).ngClassDirty,e["\u0275nov"](n,57).ngClassValid,e["\u0275nov"](n,57).ngClassInvalid,e["\u0275nov"](n,57).ngClassPending)})}var _=e["\u0275ccf"]("app-admin",y,function(l){return e["\u0275vid"](0,[(l()(),e["\u0275eld"](0,0,null,null,1,"app-admin",[],null,null,null,R,A)),e["\u0275did"](1,114688,null,0,y,[b.a,C.a],null,null)],function(l,n){l(n,1,0)},null)},{},{},[]),j=u("9eRs"),k=u("Ovjw"),q=u("iCtU"),S=u("e5OV"),M=u("8NoF"),N=u("FeSO"),x=u("ysnj"),F=u("5sLU"),O=u("oYRQ"),E=u("q7oS"),T=u("OU4G"),V=u("bSlz"),D=u("9n00"),L=u("/onb"),U=u("Ok6J"),Y=u("ebCm"),G=u("NGEN"),Z=u("ejuw"),J=u("swaV"),W=u("Zt+D"),$=u("lMb6"),z=u("Bia8"),B=u("bt6x"),K=u("0XGt"),Q=u("nhl2"),X=u("gpiN"),H=u("MVL9"),ll=u("j2fZ"),nl=u("LKjY"),ul=u("PsaP"),el=u("InZo"),tl=u("C9m0"),il=u("+NDo"),ol=u("4WQT"),al=u("wtSO"),dl=u("NlYj"),rl=u("neuq"),cl=u("y+WT"),sl=u("eUd/"),ml=u("ZYCi"),vl=function(){},pl=u("XfKo");u.d(n,"AdminModuleNgFactory",function(){return gl});var gl=e["\u0275cmf"](t,[],function(l){return e["\u0275mod"]([e["\u0275mpd"](512,e.ComponentFactoryResolver,e["\u0275CodegenComponentFactoryResolver"],[[8,[i.a,o.a,a.a,d.a,r.a,c.a,s.a,m.a,_]],[3,e.ComponentFactoryResolver],e.NgModuleRef]),e["\u0275mpd"](4608,f.o,f.n,[e.LOCALE_ID,[2,f.A]]),e["\u0275mpd"](4608,g.w,g.w,[]),e["\u0275mpd"](4608,j.a,j.a,[f.c]),e["\u0275mpd"](4608,k.a,k.a,[e.ApplicationRef,e.Injector,e.ComponentFactoryResolver,f.c,j.a]),e["\u0275mpd"](4608,q.a,q.a,[e.ComponentFactoryResolver,e.Injector,k.a]),e["\u0275mpd"](4608,S.a,S.a,[]),e["\u0275mpd"](4608,M.a,M.a,[]),e["\u0275mpd"](4608,N.a,N.a,[]),e["\u0275mpd"](135680,x.c,x.c,[f.c,x.a]),e["\u0275mpd"](4608,F.a,F.a,[]),e["\u0275mpd"](4608,O.a,O.a,[]),e["\u0275mpd"](4608,E.a,E.a,[]),e["\u0275mpd"](4608,T.a,T.b,[]),e["\u0275mpd"](4608,f.d,f.d,[e.LOCALE_ID]),e["\u0275mpd"](4608,V.a,V.b,[e.LOCALE_ID,f.d]),e["\u0275mpd"](4608,D.b,D.a,[]),e["\u0275mpd"](4608,L.a,L.b,[]),e["\u0275mpd"](4608,U.a,U.a,[]),e["\u0275mpd"](4608,Y.a,Y.a,[]),e["\u0275mpd"](4608,G.a,G.a,[]),e["\u0275mpd"](4608,Z.a,Z.a,[]),e["\u0275mpd"](4608,J.a,J.a,[]),e["\u0275mpd"](4608,W.a,W.a,[]),e["\u0275mpd"](4608,$.a,$.a,[]),e["\u0275mpd"](4608,z.a,z.b,[]),e["\u0275mpd"](1073742336,f.b,f.b,[]),e["\u0275mpd"](1073742336,g.t,g.t,[]),e["\u0275mpd"](1073742336,g.h,g.h,[]),e["\u0275mpd"](1073742336,B.a,B.a,[]),e["\u0275mpd"](1073742336,K.a,K.a,[]),e["\u0275mpd"](1073742336,Q.a,Q.a,[]),e["\u0275mpd"](1073742336,X.a,X.a,[]),e["\u0275mpd"](1073742336,H.a,H.a,[]),e["\u0275mpd"](1073742336,ll.a,ll.a,[]),e["\u0275mpd"](1073742336,nl.a,nl.a,[]),e["\u0275mpd"](1073742336,ul.a,ul.a,[]),e["\u0275mpd"](1073742336,el.a,el.a,[]),e["\u0275mpd"](1073742336,tl.a,tl.a,[]),e["\u0275mpd"](1073742336,il.b,il.b,[]),e["\u0275mpd"](1073742336,ol.a,ol.a,[]),e["\u0275mpd"](1073742336,al.a,al.a,[]),e["\u0275mpd"](1073742336,dl.a,dl.a,[]),e["\u0275mpd"](1073742336,rl.a,rl.a,[]),e["\u0275mpd"](1073742336,cl.a,cl.a,[]),e["\u0275mpd"](1073742336,sl.b,sl.b,[]),e["\u0275mpd"](1073742336,ml.o,ml.o,[[2,ml.u],[2,ml.l]]),e["\u0275mpd"](1073742336,vl,vl,[]),e["\u0275mpd"](1073742336,pl.a,pl.a,[]),e["\u0275mpd"](1073742336,t,t,[]),e["\u0275mpd"](256,x.a,x.b,[]),e["\u0275mpd"](1024,ml.j,function(){return[[{path:"",component:y}]]},[])])})}}]);