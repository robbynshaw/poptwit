(function () {
    'use strict';

    angular
        .module('popTwit.comparisonList')
        .component('comparisonList', {
            templateUrl: 'src/core/comparison-list/comparison-list.template.html',
            controller: ComparisonListController
        });

    function ComparisonListController() {
        this.comparisons = [
            { id: 1 },
            { id: 2 },
            { id: 3 },
            { id: 4 },
            { id: 5 },
        ];
    }
})();