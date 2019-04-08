import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IIdentificationType} from "../interfaces/IIdentificationType";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('IdentificationTypesService');

@autoinject
export class IdentificationTypesService extends BaseService<IIdentificationType>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'IdentificationTypes');
  }
}
