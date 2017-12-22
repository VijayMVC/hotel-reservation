angular.module('pay')
	.controller('appoinmentCtrl',function($scope,$state,payConfig,$http){
		$scope.submit = function(){
			if ($scope.user.type === "Mobile") { 
				$state.go('menu.mobile');
			}else if ($scope.user.type === "Credit") { 
				$state.go('menu.credit');
			}

			localStorage.setItem("user",JSON.stringify($scope.user))
		}

		function loadDoctors(){
			$http({
				url : payConfig.url + 'getDoctors',
				method : "GET",
			}).then(function(response){
				$scope.doctors = response.data.success;
			})
		}

		loadDoctors()
	});
	 