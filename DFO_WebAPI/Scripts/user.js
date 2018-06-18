var app = angular.module('myApp', []);

app.controller('UserController', function ($scope, $http) {
    $http.get('/api/user').then(function (response) {
        $scope.users = response.data
    });
});

app.controller('AddUserController', function ($scope, $http) {

    //$http({
    //    url: '/api/user',
    //    method: 'POST',
    //    data: $scope.saveUserForm.data, 
    //    headers: {
    //        'Content-Type': 'application/x-www-form-urlencoded'
    //    }
    //}).success(function (response) {
    //    $scope.users.push({ 'Name': $scope.saveUserForm.Name, 'done': false })
    //});

    $scope.submitForm = function () {
        $scope.users.push({ 'Name': $scope.saveUserForm.Name, 'done': false })
        //$http({
        //    method: 'POST',
        //    url: '/api/user',
        //    data: $scope.saveUserForm.data,
        //    headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        //})
        //.success(function (response) {
        //    $scope.users.push({ 'Name': $scope.saveUserForm.Name, 'done': false })
        //});
    };
});