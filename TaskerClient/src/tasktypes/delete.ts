import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {TaskTypesService} from "../services/tasktype-service";
import {ITaskType} from "../interfaces/ITaskType";

export var log = LogManager.getLogger('TaskTypes.Delete');

@autoinject
export class Delete {

  private taskType : ITaskType;

  constructor(
    private router: Router,
    private taskTypesService : TaskTypesService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.taskTypesService.delete(this.taskType.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("taskTypesIndex");
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
    this.taskTypesService.fetch(params.id).then(
      taskType => {
        log.debug('taskType', taskType);
        this.taskType = taskType;
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
