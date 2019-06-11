import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {HourlyRatesService} from "../services/hourlyrates-services";
import {IHourlyRate} from "../interfaces/IHourlyRate";

export var log = LogManager.getLogger('HourlyRates.Delete');

@autoinject
export class Delete {

  private hourlyRate : IHourlyRate;

  constructor(
    private router: Router,
    private hourlyRatesService : HourlyRatesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.hourlyRatesService.delete(this.hourlyRate.id).then(response => {
      if (response.status == 204) {
        this.router.navigateToRoute("hourlyRatesIndex");
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
    this.hourlyRatesService.fetch(params.id).then(
      hourlyRate => {
        log.debug('hourlyRate', hourlyRate);
        this.hourlyRate = hourlyRate;
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
