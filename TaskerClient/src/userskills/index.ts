import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {IUserSkill} from "../interfaces/IUserSkill";
import {UserSkillsService} from "../services/userskill-service";

export var log = LogManager.getLogger('UserSkills.Index');

@autoinject
export class Index {

  private userSkills : IUserSkill[] = [];

  constructor(
    private userSkillsService : UserSkillsService
  ) {
    log.debug('constructor');
    this.userSkills.push({id: 99, userSkillValue: 'testing', userSkillCount: 2});
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
    this.userSkillsService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.userSkills = jsonData;
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
