import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {MeansOfPaymentsService} from "../services/meansofpayment-service";
import {IMeansOfPayment} from "../interfaces/IMeansOfPayment";

export var log = LogManager.getLogger('MeansOfPayment.Delete');

@autoinject
export class Delete {

  private meansOfPayment : IMeansOfPayment;

  constructor(
    private router: Router,
    private meansOfPaymentsService : MeansOfPaymentsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.meansOfPaymentsService.delete(this.meansOfPayment.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("meansOfPaymentsIndex");
      } else {
        log.debug('response', response);
      }
    });
  }


  // ============ View LifeCycle events ==============
  created(owningView: View, myView: View) {
    log.debug('created');
  }

  bind(bindingContext: Object, overrideContext: Object) {
    log.debug('bind');
  }

  attached() {
    log.debug('attached');
  }

  detached() {
    log.debug('detached');
  }

  unbind() {
    log.debug('unbind');
  }

  // ============= Router Events =============
  canActivate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('canActivate');
  }

  activate(params: any, routerConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
    log.debug('activate');
    this.meansOfPaymentsService.fetch(params.id).then(
      meansOfPayment => {
        log.debug('meansOfPayment', meansOfPayment);
        this.meansOfPayment = meansOfPayment;
      }
    );

  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
