(function () {
    'use strict';

    angular
        .module('popTwit.comparisonList')
        .component('comparisonList', {
            templateUrl: 'src/core/comparison-list/comparison-list.template.html',
            controller: ComparisonListController,
            bindings: {
                ptType: '<',
                userId: '<',
                maxCount: '<'
            }
        });

    ComparisonListController.$inject = ['popTwit.comparisonRepo'];

    function ComparisonListController(repo) {
        var $this = this;

        var types = {
            user: getByUser,
            all: getTop
        };
        
        this.comparisons = types[$this.ptType]();

        function getByUser() { 
            return repo.getByUser($this.id, 5);
        }
        function getTop(){
            return repo.getTop(5);
        }
    }
})();