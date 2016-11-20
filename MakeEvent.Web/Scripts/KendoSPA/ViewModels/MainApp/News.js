var newsVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    init: function () {
        this.set('isGuest', !this.isAutorized);
    },
    show: function () {

    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    },
});