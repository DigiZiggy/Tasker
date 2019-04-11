import {LogManager, autoinject} from "aurelia-framework";
import {IAddress} from "./interfaces/IAddress";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {

  public apiUrl = 'https://localhost:5001/api/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }
}
