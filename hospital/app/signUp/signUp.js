angular.module('pay')
	.controller('signUpCtrl',function($scope,payConfig,$http,$state,$mdToast ){


		$scope.user = {
			'fname' : '',
			'lname' : '',
			'phone' : '',
			'gender' : '',
			'email' : '',
			'fax' : '',
			'password' : ''
		}
		$scope.submit = function(){ 
			$scope.user.fax = parseInt($scope.user.fax)
			$http({
				url : payConfig.url + 'signUp',
				method : "POST",
				data : $scope.user,
				headers : {
					'Content-Type': 'application/json; charset=utf-8',
				}
			}).then(function(response){ 
				var data =  response.data
				$mdToast.show(
                  $mdToast.simple()
                    .textContent(data.success)
                    .position('bottom right' )
                    .hideDelay(3000)
                );
                $state.go('menu.login')
			})
		}
	});
	
angular.module('pay')
	.directive("passwordVerify", function() {
	   return {
	      require: "ngModel",
	      scope: {
	        passwordVerify: '='
	      },
	      link: function(scope, element, attrs, ctrl) {
	        scope.$watch(function() {
	            var combined;

	            if (scope.passwordVerify || ctrl.$viewValue) {
	               combined = scope.passwordVerify + '_' + ctrl.$viewValue; 
	            }                    
	            return combined;
	        }, function(value) {
	            if (value) {
	                ctrl.$parsers.unshift(function(viewValue) {
	                    var origin = scope.passwordVerify;
	                    if (origin !== viewValue) {
	                        ctrl.$setValidity("passwordVerify", false);
	                        return undefined;
	                    } else {
	                        ctrl.$setValidity("passwordVerify", true);
	                        return viewValue;
	                    }
	                });
	            }
	        });
	     }
	   };
	});