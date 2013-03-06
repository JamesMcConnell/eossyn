var app = angular.module('Eossyn', []);
app.controller("AppCtrl", function ($scope, $http) {
    if ($scope.userConfig == null) {
        $http({ method: 'GET', url: 'api/userconfig' }).success(function (data, status) {
            $scope.userConfig = data;
        });
    }

    $scope.isAuthorized = function () {
        if ($scope.userConfig != null) {
            return $scope.userConfig.isLoggedIn;
        } else {
            return false;
        }
    }
});

app.controller('WorldCtrl', function ($scope, $http) {
    // Only fetch data if needed.
    if ($scope.allWorlds == null) {
        $http({ method: 'GET', url: 'api/world' }).success(function (data, status) {
            $scope.allWorlds = data;
        });
    }

    $scope.worldSelected = function () {
        // Only fetch data if needed.
        if ($scope.characters == null) {
            $http({ method: 'GET', url: 'api/character' }).success(function (data, status) {
                $scope.characters = data;
            });
        }
    }
});