
app.factory('HttpInterceptor', function ($q) {
    var apiBaseUrl = 'https://localhost:7182';

    return {
        request: function (config) {
            if (config.url.startsWith('/api')) {
                config.url = apiBaseUrl + config.url;
                config.headers['Content-Type'] = 'application/json';
            }
            return config;
        },
        response: function (response) {
            return response || $q.when(response);
        },
        responseError: function (rejection) {
            console.error('HTTP request error:', rejection);
            return $q.reject(rejection);
        }
    }
});