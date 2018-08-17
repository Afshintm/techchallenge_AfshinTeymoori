'use strict';

angular.module('horseRacingApp')
  .controller('customersCtrl', ['$scope','$cookies','config','$state',function ($scope,$cookies,config,$state) {
    function initialize(){
    }
    
    initialize();

    $scope.moveToNextStagec = function() {
       $state.go('main');
    }

  }]);
