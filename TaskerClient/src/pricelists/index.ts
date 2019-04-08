import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IPriceList} from "../interfaces/IPriceList";
import {PriceListsService} from "../services/pricelist-service";

export var log = LogManager.getLogger('PriceLists.Index');

@autoinject
export class Index {

  private priceLists : IPriceList[] = [];

  constructor(
    private priceListsService : PriceListsService
  ) {
    log.debug('constructor');
    this.priceLists.push({id: 99, priceListValue: 'testing', priceListCount: 2});
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
    this.priceListsService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.priceLists = jsonData;
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
