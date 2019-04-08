import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {PriceListsService} from "../services/pricelist-service";
import {IPriceList} from "../interfaces/IPriceList";

export var log = LogManager.getLogger('PriceLists.Delete');

@autoinject
export class Delete {

  private priceList : IPriceList;

  constructor(
    private router: Router,
    private priceListsService : PriceListsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.priceListsService.delete(this.priceList.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("priceListsIndex");
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
    this.priceListsService.fetch(params.id).then(
      priceList => {
        log.debug('priceList', priceList);
        this.priceList = priceList;
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
