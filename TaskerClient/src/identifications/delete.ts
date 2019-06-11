import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IdentificationsService} from "../services/identifications-service";
import {IIdentification} from "../interfaces/IIdentification";

export var log = LogManager.getLogger('Identifications.Delete');

@autoinject
export class Delete {

  private identification : IIdentification;

  constructor(
    private router: Router,
    private identificationsService : IdentificationsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.identificationsService.delete(this.identification.id).then(response => {
      if (response.status == 204) {
        this.router.navigateToRoute("identificationsIndex");
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
    this.identificationsService.fetch(params.id).then(
      identification => {
        log.debug('identification', identification);
        this.identification = identification;
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
