import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IUserOnTask} from "../interfaces/IUserOnTask";
import {UserOnTasksService} from "../services/userontask-service";

export var log = LogManager.getLogger('UserOnTasks.Index');

@autoinject
export class Index {

  private userOnTasks : IUserOnTask[] = [];

  constructor(
    private userOnTasksService : UserOnTasksService
  ) {
    log.debug('constructor');
    this.userOnTasks.push({id: 99, userOnTaskValue: 'testing', userOnTaskCount: 2});
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
    this.userOnTasksService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.userOnTasks = jsonData;
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
