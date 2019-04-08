import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IUserOnAddress} from "../interfaces/IUserOnAddress";
import {UserOnAddressesService} from "../services/useronaddress-service";

export var log = LogManager.getLogger('UserOnAddresses.Create');

@autoinject
export class Create {

  private userOnAddress : IUserOnAddress;

  constructor(
    private router: Router,
    private userOnAddressesService : UserOnAddressesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('userOnAddress', this.userOnAddress);
    this.userOnAddressesService.post(this.userOnAddress).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("UserOnAddressesIndex")
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
