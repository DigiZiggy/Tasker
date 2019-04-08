import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IIdentificationType} from "../interfaces/IIdentificationType";
import {IdentificationTypesService} from "../services/identificationtypes-service";

export var log = LogManager.getLogger('IdentificationTypes.Index');

@autoinject
export class Index {

  private identificationTypes : IIdentificationType[] = [];

  constructor(
    private identificationTypesService : IdentificationTypesService
  ) {
    log.debug('constructor');
    this.identificationTypes.push({id: 99, identificationTypeValue: 'testing', identificationTypeCount: 2});
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
    this.identificationTypesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.identificationTypes = jsonData;
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
