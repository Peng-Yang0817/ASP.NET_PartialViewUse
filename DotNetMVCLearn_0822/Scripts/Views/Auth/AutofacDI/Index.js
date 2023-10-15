var app = angular.module('MyApp', []);  // Will use ['ng-Route'] when we will implement routing
//Create a Controller
app.controller('HomeController', function ($scope, $http) {  // here $scope is used for share data between view and controller
    $scope.Message = "Yahoooo! we have successfully done our first part.";

    // 向API 取得資訊
    $http.post("AutofacDI/GerAllAuth001Info", {}).then(
        function (response) {
            $scope.data = response.data;
            $scope.peopleInfo = response.data;
        },
        function (error) {
            $scope.errorMessage = "發生錯誤：" + error.statusText;
        }
    );
});