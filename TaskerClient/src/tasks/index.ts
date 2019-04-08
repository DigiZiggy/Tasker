import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ITask} from "../interfaces/ITask";
import {TasksService} from "../services/task-service";

export var log = LogManager.getLogger('Tasks.Index');

@autoinject
export class Index {

  private tasks : ITask[] = [];

  constructor(
    private tasksService : TasksService
  ) {
    log.debug('constructor');
    this.tasks.push({id: 99, taskValue: 'testing', taskCount: 2});
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
    this.tasksService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.tasks = jsonData;
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
