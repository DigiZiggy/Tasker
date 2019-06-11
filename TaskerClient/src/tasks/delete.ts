import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {TasksService} from "../services/task-service";
import {ITask} from "../interfaces/ITask";

export var log = LogManager.getLogger('Tasks.Delete');

@autoinject
export class Delete {

  private task : ITask;

  constructor(
    private router: Router,
    private tasksService : TasksService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.tasksService.delete(this.task.id).then(response => {
      if (response.status == 204) {
        this.router.navigateToRoute("tasksIndex");
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
    this.tasksService.fetch(params.id).then(
      task => {
        log.debug('task', task);
        this.task = task;
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
