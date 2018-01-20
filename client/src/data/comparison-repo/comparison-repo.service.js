(function () {
    'use strict';

    angular
        .module('popTwit.comparisonRepo')
        .factory('popTwit.comparisonRepo', ComparisonRepo);

    ComparisonRepo.$inject = ['$resource'];

    function ComparisonRepo($resource) {
        return {
            getByUser: getByUser,
            getTop: getTop,
            add: add
        };
        ////////////////

        function getByUser(username, maxCount) {
            return $resource('/api/TweetComparison/user', {}, {
                query: {
                    method: 'GET',
                    params: {
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

        function add(aPhrase, bPhrase) {
            return $resource('/api/TweetComparison', {}, {
                query: {
                    method: 'PUT',
                    params: {
                        aPhrase: aPhrase,
                        bPhrase: bPhrase
                    },
                }
            }).query();
        }
    }
})();