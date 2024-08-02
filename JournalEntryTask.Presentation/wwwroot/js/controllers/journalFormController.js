import { formatDate , getIdFromUrl} from "../Utils/utils.js"
app.controller('journalFormController', ['$scope', '$routeParams', '$window', '$location', 'journalHeaderService', function ($scope, $routeParams, $window, $location, journalHeaderService) {

    var id = getIdFromUrl();

    $scope.journalHeader = {};
    $scope.journalDetails = [];
    async function loadJournalHeader() {
        if (id) {
            try {
                let response = await journalHeaderService.getById(id);
                response.entryDate = formatDate(response.entryDate);
                $scope.journalHeader = response;
                $scope.journalDetails = response.journalDetails;
                $scope.$apply();
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
                await journalHeaderService.update($scope.journalHeader)
            }
            else {
                await journalHeaderService.create($scope.journalHeader)
            }

            alert("Journal Created successfully");
            //$window.location.href = '/Journal';
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
                await journalHeaderService.delete(id);
                alert('Detail deleted successfully!');
                $window.location.href = '/Journal';
            } catch (error) {
                console.error('Error deleting journal header:', error);
            }
        }

           
    };

  

    loadJournalHeader();
}]);