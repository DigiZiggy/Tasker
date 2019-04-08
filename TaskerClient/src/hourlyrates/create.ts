import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IHourlyRate} from "../interfaces/IHourlyRate";
import {HourlyRatesService} from "../services/hourlyrates-services";

export var log = LogManager.getLogger('HourlyRates.Create');

@autoinject
export class Create {

  private hourlyRate : IHourlyRate;

  constructor(
    private router: Router,
    private hourlyRatesService : HourlyRatesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('hourlyRate', this.hourlyRate);
    this.hourlyRatesService.post(this.hourlyRate).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("hourlyRatesIndex")
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
