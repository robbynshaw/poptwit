(function () {
    'use strict';

    angular
        .module('popTwit.comparisonRepo')
        .factory('popTwit.comparisonRepo', ComparisonRepo);

    ComparisonRepo.$inject = ['$resource'];

    function ComparisonRepo($resource) {
        return {
            getByUser: getByUser,
            getTop: getTop
        };
        ////////////////

        function getByUser(username, maxCount) {
            return $resource('/api/TweetComparison/:username', {}, {
                query: {
                    method: 'GET',
                    params: {
                        username: username,
                        maxCount: maxCount
                    },
                    isArray: true
                }
            }).query();
        }

        function getTop(maxCount) {
            return $resource('/api/TweetComparison', {}, {
                query: {
                    method: 'GET',
                    params: {
                        maxCount: maxCount
                    },
                    isArray: true
                }
            }).query();
        }
    }
})();