import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IUserTask} from "../interfaces/IUserTask";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('UserTasksService');

@autoinject
export class UserTasksService extends BaseService<IUserTask>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'UserTasks');
  }
}
