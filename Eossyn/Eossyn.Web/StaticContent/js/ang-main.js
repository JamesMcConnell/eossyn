var app = angular.module('Eossyn', []);
app.controller('WorldCtrl', function ($scope, $http) {
    $http({ method: 'GET', url: '/json/worlds' }).success(function (data, status) {
        $scope.allWorlds = data;
    });
    
    $scope.worldSelected = function () {
        $http({ method: 'GET', url: '/json/world/' + $scope.selectedWorld + '/characters' }).success(function (data, status) {
            console.log(data);
            $scope.characters = data;
        });
    }
});