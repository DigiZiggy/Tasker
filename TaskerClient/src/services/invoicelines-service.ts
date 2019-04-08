import {LogManager, autoinject} from "aurelia-framework";
import {HttpClient} from 'aurelia-fetch-client';
import {IInvoiceLine} from "../interfaces/IInvoiceLine";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('InvoiceLinesService');

@autoinject
export class InvoiceLinesService extends BaseService<IInvoiceLine>  {

  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'InvoiceLines');
  }
}
