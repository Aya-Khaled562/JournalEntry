app.controller('journalFormController', ['$scope', '$routeParams', '$window', 'journalService', function ($scope, $routeParams, $window, journalService) {
    //var id = $routeParams.id;
    var id = $window.location.pathname.split('/').pop();

    $scope.journalHeader = {};
    $scope.journalDetails = [];
    async function loadJournalHeader() {
        if (id) {
            try {
                let response = await journalService.getById(id);
                $scope.journalDetails = response.journalDetails;
            }
            catch (error) {
                console.error('Error fetching journal headers:', error);
                throw error;
            }  
        }
    }

    $scope.saveJournalHeader = async function () {
        try {
            if (id) {
                await journalService.update($scope.journalHeader)
            }
            else {
                await journalService.create($scope.journalHeader)
            }
            $window.location.href = '/Journal';
        }
        catch (error) {
            console.error('Error saving journal header:', error);
        }
    };

    $scope.editDetail = function (detail) {
        // Function to edit detail
    };

    $scope.deleteDetail = async function (id) {
        if (confirm('Are you sure you want to delete this journal header?') && id) {
            try {
                await journalService.delete(id);
                alert('Detail deleted successfully!');
                $window.location.href = '/Journal';
            } catch (error) {
                console.error('Error deleting journal header:', error);
            }
        }

           
    };

    loadJournalHeader();
}]);