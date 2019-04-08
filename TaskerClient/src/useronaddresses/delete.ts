import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {UserOnAddressesService} from "../services/useronaddress-service";
import {IUserOnAddress} from "../interfaces/IUserOnAddress";

export var log = LogManager.getLogger('UserOnAddresses.Delete');

@autoinject
export class Delete {

  private userOnAddress : IUserOnAddress;

  constructor(
    private router: Router,
    private userOnAddressesService : UserOnAddressesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.userOnAddressesService.delete(this.userOnAddress.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("userOnAddressesIndex");
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
    this.userOnAddressesService.fetch(params.id).then(
      userOnAddress => {
        log.debug('userOnAddress', userOnAddress);
        this.userOnAddress = userOnAddress;
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
