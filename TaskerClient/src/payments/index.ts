import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IPayment} from "../interfaces/IPayment";
import {PaymentsService} from "../services/payment-service";

export var log = LogManager.getLogger('Payments.Index');

@autoinject
export class Index {

  private payments : IPayment[] = [];

  constructor(
    private paymentsService : PaymentsService
  ) {
    log.debug('constructor');
    this.payments.push({id: 99, paymentValue: 'testing', paymentCount: 2});
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
    this.paymentsService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.payments = jsonData;
      }
    );
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
