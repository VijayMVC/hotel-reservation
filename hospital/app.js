angular.module('pay', [
	'ngMaterial',
	'ui.router',
	'ngAnimate',
	'ngMessages'
])
.config(function($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('home/login');
    $stateProvider
    .state('menu', {
        url: '/home', 
        controller : 'menuCtrl',
        templateUrl: 'app/menu/menu.html' 
    }) 
    .state('menu.login', {
        url: '/login', 
        controller : 'loginCtrl',
        templateUrl: 'app/login/login.html'
    }) 
    .state('menu.signUp', {
        url: '/signUp', 
        controller : 'signUpCtrl',
        templateUrl: 'app/signUp/signUp.html'
    }) 
    .state('menu.appoinment', {
        url: '/appoinment', 
        controller : 'appoinmentCtrl',
        templateUrl: 'app/appoinment/appoinment.html'
    }) 
    .state('menu.mobile', {
        url: '/mobile', 
        controller : 'mobileCtrl',
        templateUrl: 'app/mobile/mobile.html', 
    }) 
    .state('menu.credit', {
        url: '/credit', 
        controller : 'creditCtrl',
        templateUrl: 'app/credit/credit.html', 
    }) 
})
.config(function ($httpProvider) {
  $httpProvider.defaults.headers.common = {};
  $httpProvider.defaults.headers.post = {};
  $httpProvider.defaults.headers.put = {};
  $httpProvider.defaults.headers.patch = {};
})
.constant('payConfig',{
    "url": "http://localhost:59236/Service1.svc/", 
})