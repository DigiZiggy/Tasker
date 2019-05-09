import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {UserTasksService} from "../services/usertask-service";
import {IUserTask} from "../interfaces/IUserTask";

export var log = LogManager.getLogger('UserTasks.Delete');

@autoinject
export class Delete {

  private userTask : IUserTask;

  constructor(
    private router: Router,
    private userTasksService : UserTasksService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.userTasksService.delete(this.userTask.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("userTasksIndex");
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
    this.userTasksService.fetch(params.id).then(
      userOnTask => {
        log.debug('userOnTask', userOnTask);
        this.userTask = userOnTask;
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
