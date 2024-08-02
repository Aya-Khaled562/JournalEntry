var app = angular.module('journalApp', ['ngRoute']);

app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.interceptors.push('HttpInterceptor');
}]);

// Configure routes
//app.config(['$routeProvider', function ($routeProvider) {
//    $routeProvider
//        .when('/Journal', {
//            templateUrl: '/Journal/Index',
//            controller: 'journalController'
//        })
//        .when('/Journal/JournalForm/:id?', {
//            templateUrl: '/Journal/JournalForm',
//            controller: 'journalFormController'
//        })
//        .otherwise({
//            redirectTo: '/Journal'
//        });
//}]);
