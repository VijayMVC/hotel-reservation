angular.module('pay')
	.controller('mobileCtrl',function($scope,$state,payConfig,$http,$mdToast){ 
		 

		$scope.user = JSON.parse(localStorage.getItem('user')) 

		$scope.submit = function(){
			if (typeof $scope.user.doctor !== "object") {
				$scope.user.doctor = JSON.parse($scope.user.doctor);
			} 
			 
			$http({
				url : payConfig.url + 'saveAppoinmentMobile',
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
                $state.go('menu.appoinment');
                sendSMS()
			})

		}

		function sendSMS(){
			var jsonBody = {
			  "messages": [
			    { 
			      "from": "rasm-pay",
			      "body": "Payment is charged for " + $scope.user.amount+ " from this number",
			      "to": "+94" + $scope.user.phone, 
			      "custom_string": "this is a test",
			    }
			  ]
			};
			$http({
				url : 'https://rest.clicksend.com/v3/sms/send',
				method : "POST",
				data : jsonBody,
				headers : {
					'Content-Type':'application/json',
					'Authorization':'Basic c2FjaGlsYTpzYUNoMWxhcmFuYSNha2E='
				}
			}).then(function(response){ 
			},function(response){

			})
		}
	})