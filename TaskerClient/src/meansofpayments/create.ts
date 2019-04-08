import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IMeansOfPayment} from "../interfaces/IMeansOfPayment";
import {MeansOfPaymentsService} from "../services/meansofpayment-service";

export var log = LogManager.getLogger('MeansOfPayments.Create');

@autoinject
export class Create {

  private meansOfPayment : IMeansOfPayment;

  constructor(
    private router: Router,
    private meansOfPaymentsService : MeansOfPaymentsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('meansOfPayment', this.meansOfPayment);
    this.meansOfPaymentsService.post(this.meansOfPayment).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("MeansOfPaymentsIndex")
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
