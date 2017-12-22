angular.module('pay')
	.controller('menuCtrl',function($scope,$rootScope,$state){
		$rootScope.userName = '';

		var userName = localStorage.getItem('userName');
		if (userName) {
			$rootScope.userName = userName;
		}else{
			$state.go('menu.login')
		}

		$scope.logOut = function(){
			window.localStorage.removeItem('userName');
			$rootScope.userName = null;
			$state.go('menu.login')
		}

		$scope.goToMain = function(){
			if (userName) {
				$state.go('menu.appoinment')
			}else{
				$state.go('menu.login')
			}
		}
	})