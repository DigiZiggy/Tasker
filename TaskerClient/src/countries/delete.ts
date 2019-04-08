import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {CountriesService} from "../services/countries-services";
import {ICountry} from "../interfaces/ICountry";

export var log = LogManager.getLogger('Countries.Delete');

@autoinject
export class Delete {

  private country : ICountry;

  constructor(
    private router: Router,
    private countriesService : CountriesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.countriesService.delete(this.country.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("countriesIndex");
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
    this.countriesService.fetch(params.id).then(
      country => {
        log.debug('country', country);
        this.country = country;
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
