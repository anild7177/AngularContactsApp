var ContactsApp = angular.module('ContactsApp', ['ngRoute','ngResource']);

ContactsApp.config(function($routeProvider) {
    $routeProvider
        .when('/', { controller: 'ContactsController', templateUrl: 'Partials/ContactsList.html' })
        .otherwise({ redirectTo: '/' });
});

ContactsApp.factory('ContactsFactory', function($resource) {
    return $resource('/api/MyContacts/');
});

ContactsApp.controller('ContactsController', function($scope, ContactsFactory) {
    $scope.Contacts = ContactsFactory.query();
});