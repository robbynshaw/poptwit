'use strict';

angular.module('popTwit', [
  'ngRoute',
  'ngResource',
  'popTwit.compare',
])
.constant('toastr', toastr)
.config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
  $locationProvider.hashPrefix('!');

  $routeProvider.otherwise({redirectTo: '/compare'});
}]);