import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IUserTask} from "../interfaces/IUserTask";
import {UserTasksService} from "../services/usertask-service";

export var log = LogManager.getLogger('UserTasks.Create');

@autoinject
export class Create {

  private userTask : IUserTask;

  constructor(
    private router: Router,
    private userTasksService : UserTasksService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('userTask', this.userTask);
    this.userTasksService.post(this.userTask).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("UserTasksIndex")
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
