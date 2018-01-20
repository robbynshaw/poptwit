(function () {
    'use strict';

    angular
        .module('popTwit.comparisonRepo')
        .factory('popTwit.comparisonRepo', ComparisonRepo);

    ComparisonRepo.$inject = ['ngResource'];

    function ComparisonRepo($resource) {
        return {
            getByUser: getByUser,
            getTop: getTop
        };
        ////////////////

        function getByUser(userId, maxCount) {
            return [
                { id: 1 },
                { id: 2 },
                { id: 3 },
                { id: 4 },
                { id: 5 },
            ];
        }

        function getTop(maxCount) {
            return [
                { id: 9 },
                { id: 8 },
                { id: 7 },
                { id: 6 },
                { id: 5 },
            ];
        }
    }
})();