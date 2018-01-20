'use strict';

angular.module('popTwit.compare', [
  'ngRoute',
  'popTwit.comparisonList'
])

.config(['$routeProvider', function($routeProvider) {
  $routeProvider.when('/compare', {
    templateUrl: '/src/compare/compare.html',
    controller: 'CompareCtrl'
  });
}])

.controller('CompareCtrl', [function() {

}]);