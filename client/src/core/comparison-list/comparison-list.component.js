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

    ComparisonListController.$inject = [
        'popTwit.comparisonRepo',
        '$scope',
        '$timeout'
    ];

    function ComparisonListController(repo, $scope, $timeout) {
        var $this = this;
        var delay = 1000;

        this.$onInit = function () {
            this.load();
        };

        var types = {
            user: getByUser,
            all: getTop
        };

        this.load = function () {
            var comps = types[$this.ptType](function (data) {
                if (!angular.equals(comps, $this.comparisons)){
                    console.log('is not equal');
                    $this.comparisons = comps;
                }

                if (hasPending()) {
                    $timeout($this.load, delay);
                }
            });
        };

        function getByUser(success, error) {
            return repo.getByUser($this.ptUsername, $this.ptMaxCount,
                success, error);
        }
        function getTop(success, error) {
            return repo.getTop($this.ptMaxCount, success, error);
        }
        function hasPending() {
            if ($this.comparisons) {
                for (var i = 0; i < $this.comparisons.length; i++) {
                    var thisComp = $this.comparisons[i];
                    if (thisComp.aIsPending || thisComp.bIsPending) {
                        return true;
                    }
                }
            }
            return false;
        }

        $scope.$on('poptwit.compare.change', function () {
            $this.load();
        });
    }
})();