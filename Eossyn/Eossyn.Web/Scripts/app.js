var endpoints = {
    FetchAllWorlds: '/api/world',
    FetchWorldById: '/api/world/'
};

var app = app || {};
app.dataservice = (function (app) {
    "use strict";
    var getAllWorlds = function (callback) {
        $.getJSON(endpoints.FetchAllWorlds, function (data) {
            callback(data);
        });
    };

    return {
        getAllWorlds: getAllWorlds
    }
})(app);

var defaultUserConfig = {
    userName: '',
    userCharacterName: ''
};
