import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IInvoiceLine} from "../interfaces/IInvoiceLine";
import {InvoiceLinesService} from "../services/invoicelines-service";

export var log = LogManager.getLogger('InvoiceLines.Index');

@autoinject
export class Index {

  private invoiceLines : IInvoiceLine[] = [];

  constructor(
    private invoiceLinesService : InvoiceLinesService
  ) {
    log.debug('constructor');
    this.invoiceLines.push({id: 99, invoiceLineValue: 'testing', invoiceLineCount: 2});
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
    this.invoiceLinesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.invoiceLines = jsonData;
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
