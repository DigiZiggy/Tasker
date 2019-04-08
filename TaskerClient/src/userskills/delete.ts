import {LogManager, View, autoinject} from "aurelia-framework";
import {RouteConfig, NavigationInstruction, Router} from "aurelia-router";
import {UserSkillsService} from "../services/userskill-service";
import {IUserSkill} from "../interfaces/IUserSkill";

export var log = LogManager.getLogger('UserSkills.Delete');

@autoinject
export class Delete {

  private userSkill : IUserSkill;

  constructor(
    private router: Router,
    private userSkillsService : UserSkillsService
  ) {
    log.debug('constructor');
  }


  // ============ View Methods ==============
  submit():void{
    this.userSkillsService.delete(this.userSkill.id).then(response => {
      if (response.status == 200) {
        this.router.navigateToRoute("userSkillsIndex");
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
    this.userSkillsService.fetch(params.id).then(
      userSkill => {
        log.debug('userSkill', userSkill);
        this.userSkill = userSkill;
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
