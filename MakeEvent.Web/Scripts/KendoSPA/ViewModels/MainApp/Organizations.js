var organizationsVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    filter:{
        orgName:''
    },
    organizations: [{
        Id: 0,
        Name: 'ООО "Тест Ивент"',
        LogoUrl: '/Content/images/org-logo.png',
        Description: 'Мы занимаемся очень интересными вещами. Приходите на на наши мероприятия. Не пожалеете.',
        Site: 'http://test.ru'
    },
    {
        Id: 0,
        Name: 'ООО "Тест Ивент"',
        LogoUrl: '/Content/images/org-logo.png',
        Description: 'Мы занимаемся очень интересными вещами. Приходите на на наши мероприятия. Не пожалеете.',
        Site: 'http://test.ru'
    },
    {
        Id: 0,
        Name: 'ООО "Тест Ивент"',
        LogoUrl: '/Content/images/org-logo.png',
        Description: 'Мы занимаемся очень интересными вещами. Приходите на на наши мероприятия. Не пожалеете.',
        Site: 'http://test.ru'
    }],
    init: function () {
        this.set('isGuest', !this.isAutorized);
        $('[type=text]').not('.DateTime').kendoMaskedTextBox();
    },
    show: function () {
        KendoHelper.insertExtTemplate('#org-item', '#org-list-block', this.organizations);
        $('a.org-header').click(function (event) {
            var id = $(event.target).data('id');
            router.navigate('organization/' + id);
        });
    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    },
    searchOrgs: function () {

    }
})