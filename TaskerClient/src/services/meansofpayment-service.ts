import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IMeansOfPayment} from "../interfaces/IMeansOfPayment";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('MeansOfPaymentsService');

@autoinject
export class MeansOfPaymentsService extends BaseService<IMeansOfPayment>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'MeansOfPayments');
  }
}
