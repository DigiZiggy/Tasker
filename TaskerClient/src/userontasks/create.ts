import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {IUserOnTask} from "../interfaces/IUserOnTask";
import {UserOnTasksService} from "../services/userontask-service";

export var log = LogManager.getLogger('UserOnTasks.Create');

@autoinject
export class Create {

  private userOnTask : IUserOnTask;

  constructor(
    private router: Router,
    private userOnTasksService : UserOnTasksService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('userOnTask', this.userOnTask);
    this.userOnTasksService.post(this.userOnTask).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("UserOnTasksIndex")
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
