import {PLATFORM, LogManager, autoinject} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";
import {AppConfig} from "./app-config";

export var log = LogManager.getLogger('MainRouter');

@autoinject
export class MainRouter {

  public router: Router;

  constructor(private appConfig: AppConfig){
    log.debug('constructor');
  }

  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');

    this.router = router;
    config.title = "Contact App - Aurelia";
    config.map(
      [
        {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},

        {route: 'identity/login', name: 'identity' + 'Login', moduleId: PLATFORM.moduleName('identity/login'), nav: false, title: 'Login'},
        {route: 'identity/register', name: 'identity' + 'Register', moduleId: PLATFORM.moduleName('identity/register'), nav: false, title: 'Register'},
        {route: 'identity/logout', name: 'identity' + 'Logout', moduleId: PLATFORM.moduleName('identity/logout'), nav: false, title: 'Logout'},


        {route: ['addresses/index', 'addresses'], name: 'addresses' + 'Index', moduleId: PLATFORM.moduleName('addresses/index'), nav: false, title: 'Addresses'},
        {route: 'addresses/create', name: 'addresses' + 'Create', moduleId: PLATFORM.moduleName('addresses/create'), nav: false, title: 'Addresses Create'},
        {route: 'addresses/edit/:id', name: 'addresses' + 'Edit', moduleId: PLATFORM.moduleName('addresses/edit'), nav: false, title: 'Addresses Edit'},
        {route: 'addresses/delete/:id', name: 'addresses' + 'Delete', moduleId: PLATFORM.moduleName('addresses/delete'), nav: false, title: 'Addresses Delete'},
        {route: 'addresses/details/:id', name: 'addresses' + 'Details', moduleId: PLATFORM.moduleName('addresses/details'), nav: false, title: 'Addresses Details'},

        {route: ['cities/index', 'cities'], name: 'cities' + 'Index', moduleId: PLATFORM.moduleName('cities/index'), nav: false, title: 'Cities'},
        {route: 'cities/create', name: 'cities' + 'Create', moduleId: PLATFORM.moduleName('cities/create'), nav: false, title: 'Cities Create'},
        {route: 'cities/edit/:id', name: 'cities' + 'Edit', moduleId: PLATFORM.moduleName('cities/edit'), nav: false, title: 'Cities Edit'},
        {route: 'cities/delete/:id', name: 'cities' + 'Delete', moduleId: PLATFORM.moduleName('cities/delete'), nav: false, title: 'Cities Delete'},
        {route: 'cities/details/:id', name: 'cities' + 'Details', moduleId: PLATFORM.moduleName('cities/details'), nav: false, title: 'Cities Details'},

        {route: ['countries/index', 'countries'], name: 'countries' + 'Index', moduleId: PLATFORM.moduleName('countries/index'), nav: true, title: 'Countries'},
        {route: 'countries/create', name: 'countries' + 'Create', moduleId: PLATFORM.moduleName('countries/create'), nav: false, title: 'Countries Create'},
        {route: 'countries/edit/:id', name: 'countries' + 'Edit', moduleId: PLATFORM.moduleName('countries/edit'), nav: false, title: 'Countries Edit'},
        {route: 'countries/delete/:id', name: 'countries' + 'Delete', moduleId: PLATFORM.moduleName('countries/delete'), nav: false, title: 'Countries Delete'},
        {route: 'countries/details/:id', name: 'countries' + 'Details', moduleId: PLATFORM.moduleName('countries/details'), nav: false, title: 'Countries Details'},

        {route: ['hourlyrates/index', 'hourlyrates'], name: 'hourlyrates' + 'Index', moduleId: PLATFORM.moduleName('hourlyrates/index'), nav: true, title: 'HourlyRates'},
        {route: 'hourlyrates/create', name: 'hourlyrates' + 'Create', moduleId: PLATFORM.moduleName('hourlyrates/create'), nav: false, title: 'HourlyRates Create'},
        {route: 'hourlyrates/edit/:id', name: 'hourlyrates' + 'Edit', moduleId: PLATFORM.moduleName('hourlyrates/edit'), nav: false, title: 'HourlyRates Edit'},
        {route: 'hourlyrates/delete/:id', name: 'hourlyrates' + 'Delete', moduleId: PLATFORM.moduleName('hourlyrates/delete'), nav: false, title: 'HourlyRates Delete'},
        {route: 'hourlyrates/details/:id', name: 'hourlyrates' + 'Details', moduleId: PLATFORM.moduleName('hourlyrates/details'), nav: false, title: 'HourlyRates Details'},

        {route: ['invoices/index', 'invoices'], name: 'invoices' + 'Index', moduleId: PLATFORM.moduleName('invoices/index'), nav: true, title: 'Invoices'},
        {route: 'invoices/create', name: 'invoices' + 'Create', moduleId: PLATFORM.moduleName('invoices/create'), nav: false, title: 'Invoices Create'},
        {route: 'invoices/edit/:id', name: 'invoices' + 'Edit', moduleId: PLATFORM.moduleName('invoices/edit'), nav: false, title: 'Invoices Edit'},
        {route: 'invoices/delete/:id', name: 'invoices' + 'Delete', moduleId: PLATFORM.moduleName('invoices/delete'), nav: false, title: 'Invoices Delete'},
        {route: 'invoices/details/:id', name: 'invoices' + 'Details', moduleId: PLATFORM.moduleName('invoices/details'), nav: false, title: 'Invoices Details'},

        {route: ['invoicelines/index', 'invoicelines'], name: 'invoicelines' + 'Index', moduleId: PLATFORM.moduleName('invoicelines/index'), nav: false, title: 'InvoiceLines'},
        {route: 'invoicelines/create', name: 'invoicelines' + 'Create', moduleId: PLATFORM.moduleName('invoicelines/create'), nav: false, title: 'InvoiceLines Create'},
        {route: 'invoicelines/edit/:id', name: 'invoicelines' + 'Edit', moduleId: PLATFORM.moduleName('invoicelines/edit'), nav: false, title: 'InvoiceLines Edit'},
        {route: 'invoicelines/delete/:id', name: 'invoicelines' + 'Delete', moduleId: PLATFORM.moduleName('invoicelines/delete'), nav: false, title: 'InvoiceLines Delete'},
        {route: 'invoicelines/details/:id', name: 'invoicelines' + 'Details', moduleId: PLATFORM.moduleName('invoicelines/details'), nav: false, title: 'InvoiceLines Details'},

        {route: ['payments/index', 'payments'], name: 'payments' + 'Index', moduleId: PLATFORM.moduleName('payments/index'), nav: false, title: 'Payments'},
        {route: 'payments/create', name: 'payments' + 'Create', moduleId: PLATFORM.moduleName('payments/create'), nav: false, title: 'Payments Create'},
        {route: 'payments/edit/:id', name: 'payments' + 'Edit', moduleId: PLATFORM.moduleName('payments/edit'), nav: false, title: 'Payments Edit'},
        {route: 'payments/delete/:id', name: 'payments' + 'Delete', moduleId: PLATFORM.moduleName('payments/delete'), nav: false, title: 'Payments Delete'},
        {route: 'payments/details/:id', name: 'payments' + 'Details', moduleId: PLATFORM.moduleName('payments/details'), nav: false, title: 'Payments Details'},

        {route: ['meansofpayments/index', 'meansofpayments'], name: 'meansofpayments' + 'Index', moduleId: PLATFORM.moduleName('meansofpayments/index'), nav: true, title: 'MeansOfPayments'},
        {route: 'meansofpayments/create', name: 'meansofpayments' + 'Create', moduleId: PLATFORM.moduleName('meansofpayments/create'), nav: false, title: 'MeansOfPayments Create'},
        {route: 'meansofpayments/edit/:id', name: 'meansofpayments' + 'Edit', moduleId: PLATFORM.moduleName('meansofpayments/edit'), nav: false, title: 'MeansOfPayments Edit'},
        {route: 'meansofpayments/delete/:id', name: 'meansofpayments' + 'Delete', moduleId: PLATFORM.moduleName('meansofpayments/delete'), nav: false, title: 'MeansOfPayments Delete'},
        {route: 'meansofpayments/details/:id', name: 'meansofpayments' + 'Details', moduleId: PLATFORM.moduleName('meansofpayments/details'), nav: false, title: 'MeansOfPayments Details'},

        {route: ['prices/index', 'prices'], name: 'prices' + 'Index', moduleId: PLATFORM.moduleName('prices/index'), nav: true, title: 'Prices'},
        {route: 'prices/create', name: 'prices' + 'Create', moduleId: PLATFORM.moduleName('prices/create'), nav: false, title: 'Prices Create'},
        {route: 'prices/edit/:id', name: 'prices' + 'Edit', moduleId: PLATFORM.moduleName('prices/edit'), nav: false, title: 'Prices Edit'},
        {route: 'prices/delete/:id', name: 'prices' + 'Delete', moduleId: PLATFORM.moduleName('prices/delete'), nav: false, title: 'Prices Delete'},
        {route: 'prices/details/:id', name: 'prices' + 'Details', moduleId: PLATFORM.moduleName('prices/details'), nav: false, title: 'Prices Details'},
        
        {route: ['skills/index', 'skills'], name: 'skills' + 'Index', moduleId: PLATFORM.moduleName('skills/index'), nav: true, title: 'Skills'},
        {route: 'skills/create', name: 'skills' + 'Create', moduleId: PLATFORM.moduleName('skills/create'), nav: false, title: 'Skills Create'},
        {route: 'skills/edit/:id', name: 'skills' + 'Edit', moduleId: PLATFORM.moduleName('skills/edit'), nav: false, title: 'Skills Edit'},
        {route: 'skills/delete/:id', name: 'skills' + 'Delete', moduleId: PLATFORM.moduleName('skills/delete'), nav: false, title: 'Skills Delete'},
        {route: 'skills/details/:id', name: 'skills' + 'Details', moduleId: PLATFORM.moduleName('skills/details'), nav: false, title: 'Skills Details'},

        {route: ['tasks/index', 'tasks'], name: 'tasks' + 'Index', moduleId: PLATFORM.moduleName('tasks/index'), nav: true, title: 'Tasks'},
        {route: 'tasks/create', name: 'tasks' + 'Create', moduleId: PLATFORM.moduleName('tasks/create'), nav: false, title: 'Tasks Create'},
        {route: 'tasks/edit/:id', name: 'tasks' + 'Edit', moduleId: PLATFORM.moduleName('tasks/edit'), nav: false, title: 'Tasks Edit'},
        {route: 'tasks/delete/:id', name: 'tasks' + 'Delete', moduleId: PLATFORM.moduleName('tasks/delete'), nav: false, title: 'Tasks Delete'},
        {route: 'tasks/details/:id', name: 'tasks' + 'Details', moduleId: PLATFORM.moduleName('tasks/details'), nav: false, title: 'Tasks Details'},

        {route: ['tasktypes/index', 'tasktypes'], name: 'tasktypes' + 'Index', moduleId: PLATFORM.moduleName('tasktypes/index'), nav: true, title: 'TaskTypes'},
        {route: 'tasktypes/create', name: 'tasktypes' + 'Create', moduleId: PLATFORM.moduleName('tasktypes/create'), nav: false, title: 'TaskTypes Create'},
        {route: 'tasktypes/edit/:id', name: 'tasktypes' + 'Edit', moduleId: PLATFORM.moduleName('tasktypes/edit'), nav: false, title: 'TaskTypes Edit'},
        {route: 'tasktypes/delete/:id', name: 'tasktypes' + 'Delete', moduleId: PLATFORM.moduleName('tasktypes/delete'), nav: false, title: 'TaskTypes Delete'},
        {route: 'tasktypes/details/:id', name: 'tasktypes' + 'Details', moduleId: PLATFORM.moduleName('tasktypes/details'), nav: false, title: 'TaskTypes Details'},
        
        {route: ['users/index', 'users'], name: 'users' + 'Index', moduleId: PLATFORM.moduleName('users/index'), nav: true, title: 'Users'},
        {route: 'users/create', name: 'users' + 'Create', moduleId: PLATFORM.moduleName('users/create'), nav: false, title: 'Users Create'},
        {route: 'users/edit/:id', name: 'users' + 'Edit', moduleId: PLATFORM.moduleName('users/edit'), nav: false, title: 'Users Edit'},
        {route: 'users/delete/:id', name: 'users' + 'Delete', moduleId: PLATFORM.moduleName('users/delete'), nav: false, title: 'Users Delete'},
        {route: 'users/details/:id', name: 'users' + 'Details', moduleId: PLATFORM.moduleName('users/details'), nav: false, title: 'Users Details'},

        {route: ['identifications/index', 'identifications'], name: 'identifications' + 'Index', moduleId: PLATFORM.moduleName('identifications/index'), nav: true, title: 'Identifications'},
        {route: 'identifications/create', name: 'identifications' + 'Create', moduleId: PLATFORM.moduleName('identifications/create'), nav: false, title: 'Identifications Create'},
        {route: 'identifications/edit/:id', name: 'identifications' + 'Edit', moduleId: PLATFORM.moduleName('identifications/edit'), nav: false, title: 'Identifications Edit'},
        {route: 'identifications/delete/:id', name: 'identifications' + 'Delete', moduleId: PLATFORM.moduleName('identifications/delete'), nav: false, title: 'Identifications Delete'},
        {route: 'identifications/details/:id', name: 'identifications' + 'Details', moduleId: PLATFORM.moduleName('identifications/details'), nav: false, title: 'Identifications Details'},

        {route: ['identificationtypes/index', 'identificationtypes'], name: 'identificationtypes' + 'Index', moduleId: PLATFORM.moduleName('identificationtypes/index'), nav: false, title: 'IdentificationTypes'},
        {route: 'identificationtypes/create', name: 'identificationtypes' + 'Create', moduleId: PLATFORM.moduleName('identificationtypes/create'), nav: false, title: 'IdentificationTypes Create'},
        {route: 'identificationtypes/edit/:id', name: 'identificationtypes' + 'Edit', moduleId: PLATFORM.moduleName('identificationtypes/edit'), nav: false, title: 'IdentificationTypes Edit'},
        {route: 'identificationtypes/delete/:id', name: 'identificationtypes' + 'Delete', moduleId: PLATFORM.moduleName('identificationtypes/delete'), nav: false, title: 'IdentificationTypes Delete'},
        {route: 'identificationtypes/details/:id', name: 'identificationtypes' + 'Details', moduleId: PLATFORM.moduleName('identificationtypes/details'), nav: false, title: 'IdentificationTypes Details'},

        {route: ['reviews/index', 'reviews'], name: 'reviews' + 'Index', moduleId: PLATFORM.moduleName('reviews/index'), nav: true, title: 'Reviews'},
        {route: 'reviews/create', name: 'reviews' + 'Create', moduleId: PLATFORM.moduleName('reviews/create'), nav: false, title: 'Reviews Create'},
        {route: 'reviews/edit/:id', name: 'reviews' + 'Edit', moduleId: PLATFORM.moduleName('reviews/edit'), nav: false, title: 'Reviews Edit'},
        {route: 'reviews/delete/:id', name: 'reviews' + 'Delete', moduleId: PLATFORM.moduleName('reviews/delete'), nav: false, title: 'Reviews Delete'},
        {route: 'reviews/details/:id', name: 'reviews' + 'Details', moduleId: PLATFORM.moduleName('reviews/details'), nav: false, title: 'Reviews Details'},

      ]
      
    );
  }
}
