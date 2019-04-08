import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {InvoicesService} from "../services/invoices-service";
import {IInvoice} from "../interfaces/IInvoice";

export var log = LogManager.getLogger('Invoices.Delete');

@autoinject
export class Delete {

  private invoice : IInvoice;

  constructor(
    private router: Router,
    private invoicesService : InvoicesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.invoicesService.delete(this.invoice.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("invoicesIndex");
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
    this.invoicesService.fetch(params.id).then(
      invoice => {
        log.debug('invoice', invoice);
        this.invoice = invoice;
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
