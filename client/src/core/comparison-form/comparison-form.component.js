(function () {
    'use strict';

    angular
        .module('popTwit.comparisonForm')
        .component('comparisonForm', {
            templateUrl: 'src/core/comparison-form/comparison-form.template.html',
            controller: ComparisonFormController
        });

    ComparisonFormController.$inject = ['popTwit.comparisonRepo', '$scope', 'toastr', '$timeout'];

    function ComparisonFormController(repo, $scope, toastr, $timeout) {
        var $this = this;
        toastr.options.timeOut = 4000;
        toastr.options.positionClass = 'toast-bottom-right';

        this.$onInit = function(){
            $timeout(focusInput, 1000);
        };

        this.addNew = function (phraseA, phraseB) {
            $this.aPhrase = null;
            $this.bPhrase = null;
            $scope.comparisonSearch.$setPristine();
            toastr.info('Submitted new comparison', 'Submitted');
            repo.add(phraseA, phraseB)
                .$promise
                .then(emitAdded);
        };

        function emitAdded(comparison) {
            toastr.success('Comparison added successfully', 'Processing');
            $scope.$emit('poptwit.comparisonform.change', {
                type: 'add',
                comparison: comparison
            });
        }

        function focusInput() {
            $scope.comparisonSearch.$$element.find('input').first().focus();
        }
    }
})();