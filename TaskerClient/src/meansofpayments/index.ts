import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IMeansOfPayment} from "../interfaces/IMeansOfPayment";
import {MeansOfPaymentsService} from "../services/meansofpayment-service";

export var log = LogManager.getLogger('MeansOfPayments.Index');

@autoinject
export class Index {

  private meansOfPayments : IMeansOfPayment[] = [];

  constructor(
    private meansOfPaymentsService : MeansOfPaymentsService
  ) {
    log.debug('constructor');
    this.meansOfPayments.push({id: 99, meansOfPaymentValue: 'testing', meansOfPaymentCount: 2});
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
    this.meansOfPaymentsService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.meansOfPayments = jsonData;
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
