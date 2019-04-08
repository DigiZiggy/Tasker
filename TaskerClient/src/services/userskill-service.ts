import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IUserSkill} from "../interfaces/IUserSkill";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('UserSkillsService');

@autoinject
export class UserSkillsService extends BaseService<IUserSkill>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'UserSkills');
  }
}
