'use strict';

/**
 * @ngdoc function
 * @name vendingMachineApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the vendingMachineApp
 */
angular.module('horseRacingApp')
  .controller('mainCtrl', ['$scope','$cookies','config','$state','utils','ENV',function ($scope,$cookies,config,$state,utils,ENV) {
    $scope.model = { viewTitle:'Race List'} ;
    function getRaceList(){
        console.log(utils);
        utils.getApi(ENV.apiEndpoint+'/races/v1/details').then(function(data){
            console.log(data);
            $scope.model.raceList = data;
        }, function(reason){
        });
    }
    getRaceList();
  }]);
