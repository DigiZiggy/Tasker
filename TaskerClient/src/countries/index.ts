import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICountry} from "../interfaces/ICountry";
import {CountriesService} from "../services/countries-services";

export var log = LogManager.getLogger('Countries.Index');

@autoinject
export class Index {

  private countries : ICountry[] = [];

  constructor(
    private countriesService : CountriesService
  ) {
    log.debug('constructor');
    this.countries.push({id: 99, countryValue: 'testing', countryCount: 2});
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
    this.countriesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.countries = jsonData;
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
