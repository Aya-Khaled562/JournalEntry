app.factory('journalHeaderService', ['$http', function ($http) {
    var baseUrl = '/api/journalheader';

    return {
        getAll: async function () {
            try {
                const response = await $http.get(baseUrl);
                return response.data;
            } catch (error) {
                console.error('Error fetching journal headers:', error);
                throw error;
            }
        },
        getById: async function (id) {
            try {
                const response = await $http.get(baseUrl + '/' + id);
                return response.data;
            } catch (error) {
                console.error('Error fetching journal header by ID:', error);
                throw error;
            }
        },
        create: async function (journalHeader) {
            try {
                return await $http.post(baseUrl, journalHeader);
            } catch (error) {
                console.error('Error creating journal header:', error);
                throw error;
            }
        },
        update: async function (journalHeader) {
            try {
                await $http.patch(baseUrl, journalHeader);
            } catch (error) {
                console.error('Error updating journal header:', error);
                throw error;
            }
        },
        delete: async function (id) {
            try {
                await $http.delete(baseUrl + '/' + id);
            } catch (error) {
                console.error('Error deleting journal header:', error);
                throw error;
            }
        }
    };
}]);
