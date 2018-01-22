'use strict';

angular.module('popTwit.compare', [
  'ngRoute',
  'popTwit.comparisonList',
  'popTwit.comparisonForm'
])

  .config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/compare', {
      templateUrl: 'src/compare/compare.html',
      controller: 'CompareCtrl'
    });
  }])

  .controller('CompareCtrl', ['$scope', function ($scope) {
    $scope.$on('poptwit.comparisonform.change', function(e){
      $scope.$broadcast('poptwit.compare.change', e);
    });
    
    var ctrl = {
      newestId: 0,
    };
    return ctrl;
  }]);