import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IUserOnTask} from "../interfaces/IUserOnTask";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('UserOnTasksService');

@autoinject
export class UserOnTasksService extends BaseService<IUserOnTask>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'UserOnTasks');
  }
}
