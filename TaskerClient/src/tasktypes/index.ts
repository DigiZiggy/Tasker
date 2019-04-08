import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ITaskType} from "../interfaces/ITaskType";
import {TaskTypesService} from "../services/tasktype-service";

export var log = LogManager.getLogger('TaskTypes.Index');

@autoinject
export class Index {

  private taskTypes : ITaskType[] = [];

  constructor(
    private taskTypesService : TaskTypesService
  ) {
    log.debug('constructor');
    this.taskTypes.push({id: 99, taskTypeValue: 'testing', taskTypeCount: 2});
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
    this.taskTypesService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.taskTypes = jsonData;
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
