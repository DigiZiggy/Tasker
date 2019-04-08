import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IUserOnAddress} from "../interfaces/IUserOnAddress";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('UserOnAddressesService');

@autoinject
export class UserOnAddressesService extends BaseService<IUserOnAddress>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'UserOnAddresses');
  }
}
