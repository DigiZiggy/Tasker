import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IInvoice} from "../interfaces/IInvoice";
import {InvoicesService} from "../services/invoices-service";

export var log = LogManager.getLogger('Invoices.Create');

@autoinject
export class Create {

  private invoice : IInvoice;

  constructor(
    private router: Router,
    private invoicesService : InvoicesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('invoice', this.invoice);
    this.invoicesService.post(this.invoice).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("invoicesIndex")
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
