import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IPrice} from "../interfaces/IPrice";
import {PricesService} from "../services/price-service";

export var log = LogManager.getLogger('Prices.Index');

@autoinject
export class Index {

  private prices : IPrice[] = [];

  constructor(
    private pricesService : PricesService
  ) {
    log.debug('constructor');
    this.prices.push({id: 99, priceValue: 'testing', priceCount: 2});
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
    this.pricesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.prices = jsonData;
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
