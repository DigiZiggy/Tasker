import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {AddressesService} from "../services/addresses-service";
import {IAddress} from "../interfaces/IAddress";

export var log = LogManager.getLogger('Addresses.Delete');

@autoinject
export class Delete {

  private address : IAddress;

  constructor(
    private router: Router,
    private addressesService : AddressesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.addressesService.delete(this.address.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("addressesIndex");
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
    this.addressesService.fetch(params.id).then(
      address => {
        log.debug('address', address);
        this.address = address;
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
