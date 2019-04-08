import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ICity} from "../interfaces/ICity";
import {CitiesService} from "../services/cities-service";

export var log = LogManager.getLogger('Cities.Index');

@autoinject
export class Index {

  private cities : ICity[] = [];

  constructor(
    private citiesService : CitiesService
  ) {
    log.debug('constructor');
    this.cities.push({id: 99, cityValue: 'testing', cityCount: 2});
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
    this.citiesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.cities = jsonData;
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
