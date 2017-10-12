$(document).ready(function () {

    viewModelClients = new ClientsModel();
    
    ko.applyBindings(viewModelClients);
    alert("Hi!");

});

function ClientsModel() {
    var self = this;
}