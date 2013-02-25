var WorldViewModel = function (data) {
    var self = this;
    self.WorldId = ko.observable(data.WorldId);
    self.WorldName = ko.observable(data.WorldName);
}

var IndexViewModel = function (data) {
    var self = this;
    self.availableWorlds = ko.observableArray(ko.utils.arrayMap(data, function (item) {
        return new WorldViewModel(item);
    }));
    self.selectedWorld = ko.observable();
    self.worldSelected = function () {
        alert(self.selectedWorld.WorldName);
    }
}