import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IUserOnAddress} from "../interfaces/IUserOnAddress";
import {UserOnAddressesService} from "../services/useronaddress-service";

export var log = LogManager.getLogger('UserOnAddresses.Index');

@autoinject
export class Index {

  private userOnAddresses : IUserOnAddress[] = [];

  constructor(
    private userOnAddressesService : UserOnAddressesService
  ) {
    log.debug('constructor');
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
    this.userOnAddressesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.userOnAddresses = jsonData;
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
