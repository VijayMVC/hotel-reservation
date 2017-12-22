angular.module('pay')
	.controller('creditCtrl',function($scope,$state,$http,payConfig,$mdToast){ 

		$scope.user = JSON.parse(localStorage.getItem('user')) 
		console.log($scope.user)
		$scope.submit = function(){
			$scope.user.email = localStorage.getItem('userName');

			if (typeof $scope.user.doctor !== "object") {
				$scope.user.doctor = JSON.parse($scope.user.doctor);
			} 
			 
			console.log(JSON.stringify($scope.user));
			$http({
				url : payConfig.url + 'saveCredits',
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
                $state.go('menu.appoinment')
			},function(response){
				debugger
			})

		}
	})