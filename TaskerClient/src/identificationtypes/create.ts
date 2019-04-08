import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IIdentificationType} from "../interfaces/IIdentificationType";
import {IdentificationTypesService} from "../services/identificationtypes-service";

export var log = LogManager.getLogger('IdentificationTypes.Create');

@autoinject
export class Create {

  private identificationType : IIdentificationType;

  constructor(
    private router: Router,
    private identificationTypesService : IdentificationTypesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('identificationType', this.identificationType);
    this.identificationTypesService.post(this.identificationType).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("identificationTypesIndex")
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
