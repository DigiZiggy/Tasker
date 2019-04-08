import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {SkillsService} from "../services/skill-service";
import {ISkill} from "../interfaces/ISkill";

export var log = LogManager.getLogger('Skills.Delete');

@autoinject
export class Delete {

  private skill : ISkill;

  constructor(
    private router: Router,
    private skillsService : SkillsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.skillsService.delete(this.skill.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("skillsIndex");
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
    this.skillsService.fetch(params.id).then(
      skill => {
        log.debug('skill', skill);
        this.skill = skill;
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
