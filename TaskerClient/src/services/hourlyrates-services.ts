import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IHourlyRate} from "../interfaces/IHourlyRate";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('HourlyRatesService');

@autoinject
export class HourlyRatesService extends BaseService<IHourlyRate>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'HourlyRates');
  }
}
