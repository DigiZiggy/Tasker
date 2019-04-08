import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IPayment} from "../interfaces/IPayment";
import {PaymentsService} from "../services/payment-service";

export var log = LogManager.getLogger('Payments.Create');

@autoinject
export class Create {

  private payment : IPayment;

  constructor(
    private router: Router,
    private paymentsService : PaymentsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('payment', this.payment);
    this.paymentsService.post(this.payment).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("PaymentsIndex")
        } else {
          log.error("Error in response " + response);
        }
      }
    );
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
  }

  canDeactivate() {
    log.debug('canDeactivate');
  }

  deactivate() {
    log.debug('deactivate');
  }
}
