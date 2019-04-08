import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ICity} from "../interfaces/ICity";
import {AddressesService} from "../services/cities-service";

export var log = LogManager.getLogger('Addresses.Create');

@autoinject
export class Create {

  private address : IAddress;

  constructor(
    private router: Router,
    private addressesService : AddressesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('address', this.address);
    this.addressesService.post(this.address).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("addressesIndex")
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
