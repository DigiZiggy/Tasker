import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {ITaskType} from "../interfaces/ITaskType";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('TaskTypesService');

@autoinject
export class TaskTypesService extends BaseService<ITaskType>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'TaskTypes');
  }
}
