import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IdentificationTypesService} from "../services/identificationtypes-service";
import {IIdentificationType} from "../interfaces/IIdentificationType";

export var log = LogManager.getLogger('IdentificationTypes.Delete');

@autoinject
export class Delete {

  private identificationType : IIdentificationType;

  constructor(
    private router: Router,
    private identificationTypesService : IdentificationTypesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.identificationTypesService.delete(this.identificationType.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("identificationTypesIndex");
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
    this.identificationTypesService.fetch(params.id).then(
      identificationType => {
        log.debug('identificationType', identificationType);
        this.identificationType = identificationType;
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
