(function() {
    'use strict';

    angular
        .module('popTwit.comparisonForm')
        .component('comparisonForm', {
            templateUrl: 'src/core/comparison-form/comparison-form.template.html',
            controller: ComparisonFormController,
            bindings: {
                onAdd: '&'
            }
        });

    ComparisonFormController.$inject = ['popTwit.comparisonRepo', 'toastr'];

    function ComparisonFormController(repo, toastr) {
        var $this = this;
        toastr.options.timeOut = 4000;
        toastr.options.positionClass = 'toast-bottom-right';

        this.addNew = function(phraseA, phraseB) {
            toastr.info('Submitted new comparison', 'Submitted');
            repo.add(phraseA, phraseB)
                .$promise
                .then(emitAdded);
        };

        function emitAdded(comparison) {
            toastr.success('Comparison processed successfully', 'Complete');
            $this.onAdd(comparison);
        }
    }
})();