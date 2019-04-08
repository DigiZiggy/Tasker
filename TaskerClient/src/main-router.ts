import {PLATFORM, LogManager} from "aurelia-framework";
import {RouterConfiguration, Router} from "aurelia-router";

export var log = LogManager.getLogger('MainRouter');

export class MainRouter {

  public router: Router;

  constructor(){
    log.debug('constructor');
  }

  configureRouter(config: RouterConfiguration, router: Router):void {
    log.debug('configureRouter');

    this.router = router;
    config.title = "Contact App - Aurelia";
    config.map(
      [
        {route: ['', 'home'], name: 'home', moduleId: PLATFORM.moduleName('home'), nav: true, title: 'Home'},

        {route: ['addresses/index', 'addresses'], name: 'addresses' + 'Index', moduleId: PLATFORM.moduleName('addresses/index'), nav: true, title: 'Addresses'},
        {route: 'addresses/create', name: 'addresses' + 'Create', moduleId: PLATFORM.moduleName('addresses/create'), nav: false, title: 'Addresses Create'},
        {route: 'addresses/edit/:id', name: 'addresses' + 'Edit', moduleId: PLATFORM.moduleName('addresses/edit'), nav: false, title: 'Addresses Edit'},
        {route: 'addresses/delete/:id', name: 'addresses' + 'Delete', moduleId: PLATFORM.moduleName('addresses/delete'), nav: false, title: 'Addresses Delete'},
        {route: 'addresses/details/:id', name: 'addresses' + 'Details', moduleId: PLATFORM.moduleName('addresses/details'), nav: false, title: 'Addresses Details'},

        {route: ['cities/index', 'cities'], name: 'cities' + 'Index', moduleId: PLATFORM.moduleName('cities/index'), nav: true, title: 'Cities'},
        {route: 'cities/create', name: 'cities' + 'Create', moduleId: PLATFORM.moduleName('cities/create'), nav: false, title: 'Cities Create'},
        {route: 'cities/edit/:id', name: 'cities' + 'Edit', moduleId: PLATFORM.moduleName('cities/edit'), nav: false, title: 'Cities Edit'},
        {route: 'cities/delete/:id', name: 'cities' + 'Delete', moduleId: PLATFORM.moduleName('cities/delete'), nav: false, title: 'Cities Delete'},
        {route: 'cities/details/:id', name: 'cities' + 'Details', moduleId: PLATFORM.moduleName('cities/details'), nav: false, title: 'Cities Details'},

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

        {route: ['reviews/index', 'reviews'], name: 'reviews' + 'Index', moduleId: PLATFORM.moduleName('reviews/index'), nav: true, title: 'Reviews'},
        {route: 'reviews/create', name: 'reviews' + 'Create', moduleId: PLATFORM.moduleName('reviews/create'), nav: false, title: 'Reviews Create'},
        {route: 'reviews/edit/:id', name: 'reviews' + 'Edit', moduleId: PLATFORM.moduleName('reviews/edit'), nav: false, title: 'Reviews Edit'},
        {route: 'reviews/delete/:id', name: 'reviews' + 'Delete', moduleId: PLATFORM.moduleName('reviews/delete'), nav: false, title: 'Reviews Delete'},
        {route: 'reviews/details/:id', name: 'reviews' + 'Details', moduleId: PLATFORM.moduleName('reviews/details'), nav: false, title: 'Reviews Details'},

      ]
      
    );
  }
}
