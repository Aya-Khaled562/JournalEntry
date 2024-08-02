app.controller('journalController', ['$scope', 'journalService', '$window', '$location', async function ($scope, journalService, $window, $location) {
    $scope.journalHeaders = [];

    async function loadJournalHeaders() {
        try {
            $scope.journalHeaders = await journalService.getAll();
            $scope.$apply(); 
        } catch (error) {
            console.error('Error loading journal headers:', error);
        }
    }

    $scope.navigateToCreate = function () {
        $window.location.href = '/Journal/JournalForm';
        //$location.path('/Journal/JournalForm');
    };

    $scope.navigateToEdit = function (id) {
        $window.location.href = '/Journal/JournalForm/' + id;
        //$location.path('/Journal/JournalForm/' + id);
    };

    $scope.deleteJournalHeader = async function (id) {
        if (confirm('Are you sure you want to delete this journal header?')) {
            try {
                await journalService.delete(id);
                loadJournalHeaders();
            } catch (error) {
                console.error('Error deleting journal header:', error);
            }
        }
    };

    await loadJournalHeaders();
}]);