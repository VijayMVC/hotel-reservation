angular.module('pay')
	.controller('loginCtrl',function($scope,$rootScope,$state,payConfig,$http,$mdToast){

		$scope.signUp = function(){
			$state.go('menu.signUp')
		}
		$scope.submit = function(){
			$http({
				url : payConfig.url + 'login',
				method : "POST",
				data : $scope.user,
				headers : {
					'Content-Type': 'application/json; charset=utf-8',
				}
			}).then(function(response){
				var data = response.data;

				$mdToast.show(
                  $mdToast.simple()
                    .textContent(data.success)
                    .position('bottom right' )
                    .hideDelay(3000)
                );

				if (data.status == 200) {
					debugger
					$rootScope.userName = angular.copy($scope.user.userName);
                	localStorage.setItem('userName',angular.copy($scope.user.userName))
					$state.go('menu.appoinment')
				} 
			})
		}
	})