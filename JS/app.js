
define(['angularAMD'], function (angularAMD) {
    var nrayApp = angular.module("nrayApp", ['ngRoute', 'ngCookies']);
    //route configurations
    return angularAMD.bootstrap(nrayApp);
});