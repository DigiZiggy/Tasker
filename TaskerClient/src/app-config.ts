import {LogManager, autoinject} from "aurelia-framework";
import {IAddress} from "./interfaces/IAddress";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {

  public apiUrl = 'https://taskertask.azurewebsites.net/api/v1.0/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }
}
