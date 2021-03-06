import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {ISkill} from "../interfaces/ISkill";
import {SkillsService} from "../services/skill-service";

export var log = LogManager.getLogger('Skills.Create');

@autoinject
export class Create {

  private skill : ISkill;

  constructor(
    private router: Router,
    private skillsService : SkillsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void {
    log.debug('skill', this.skill);
    this.skillsService.post(this.skill).then(
      response => {
        if (response.status == 201) {
          this.router.navigateToRoute("SkillsIndex")
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
