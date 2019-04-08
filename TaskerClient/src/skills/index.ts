import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction} from "aurelia-router";
import {ISkill} from "../interfaces/ISkill";
import {SkillsService} from "../services/skill-service";

export var log = LogManager.getLogger('Skills.Index');

@autoinject
export class Index {

  private skills : ISkill[] = [];

  constructor(
    private skillsService : SkillsService
  ) {
    log.debug('constructor');
    this.skills.push({id: 99, skillValue: 'testing', skillCount: 2});
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
    this.skillsService.fetchAll().then(
      jsonData => {
        log.debug('jsonData', jsonData);
        this.skills = jsonData;
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
