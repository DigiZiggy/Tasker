import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IHourlyRate} from "../interfaces/IHourlyRate";
import {HourlyRatesService} from "../services/hourlyrates-services";

export var log = LogManager.getLogger('HourlyRates.Index');

@autoinject
export class Index {

  private hourlyRates : IHourlyRate[] = [];

  constructor(
    private hourlyRatesService : HourlyRatesService
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
    this.hourlyRatesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.hourlyRates = jsonData;
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
