(function () {
    'use strict';

    angular
        .module('popTwit.comparisonList')
        .component('comparisonList', {
            templateUrl: 'src/core/comparison-list/comparison-list.template.html',
            controller: ComparisonListController,
            bindings: {
                ptType: '<',
                ptUsername: '<',
                ptMaxCount: '<'
            }
        });

    ComparisonListController.$inject = ['popTwit.comparisonRepo'];

    function ComparisonListController(repo) {
        var $this = this;

        this.$onInit =function(){
            this.comparisons = types[$this.ptType]();
        };

        var types = {
            user: getByUser,
            all: getTop
        };

        function getByUser() { 
            return repo.getByUser($this.ptUsername, $this.ptMaxCount);
        }
        function getTop(){
            return repo.getTop($this.ptMaxCount);
        }
    }
})();