import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IInvoiceLine} from "../interfaces/IInvoiceLine";
import {InvoiceLinesService} from "../services/invoicelines-service";

export var log = LogManager.getLogger('invoiceLines.Create');

@autoinject
export class Create {

  private invoiceLine : IInvoiceLine;

  constructor(
    private router: Router,
    private invoiceLinesService : InvoiceLinesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('invoiceLine', this.invoiceLine);
    this.invoiceLinesService.post(this.invoiceLine).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("invoiceLinesIndex")
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
