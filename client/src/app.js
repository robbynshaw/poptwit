'use strict';

angular.module('popTwit', [
  'ngRoute',
  'popTwit.compare',
]).
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  $locationProvider.hashPrefix('!');

  $routeProvider.otherwise({redirectTo: '/compare'});
}]);
