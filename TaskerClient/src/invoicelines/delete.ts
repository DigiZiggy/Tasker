import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {InvoiceLinesService} from "../services/invoicelines-service";
import {IInvoiceLine} from "../interfaces/IInvoiceLine";

export var log = LogManager.getLogger('InvoiceLines.Delete');

@autoinject
export class Delete {

  private invoiceLine : IInvoiceLine;

  constructor(
    private router: Router,
    private invoiceLinesService : InvoiceLinesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.invoiceLinesService.delete(this.invoiceLine.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("invoiceLinesIndex");
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
    this.invoiceLinesService.fetch(params.id).then(
      invoiceLine => {
        log.debug('invoiceLine', invoiceLine);
        this.invoiceLine = invoiceLine;
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
