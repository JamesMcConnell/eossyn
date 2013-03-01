var app = angular.module('Eossyn', []);
app.controller('WorldCtrl', function ($scope, $http) {
    $http({ method: 'GET', url: '/api/world' }).success(function (data, status) {
        $scope.allWorlds = data;
    });

    $scope.worldSelected = function () {
        $http({ method: 'GET', url: '/Home/GetCharactersForWorld/' + $scope.selectedWorld }).success(function (data, status) {
            console.log(data);
            $scope.characters = data;
        });
    }
});