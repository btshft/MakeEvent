var eventsVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    events: [{
        Id: 0,
        Title:'Сдача Курсовой работы',
        OrgName:'СевГу',
        Adress:'г. Севастополь, ул. Университетская 33',
        Date:'20.12.2016',
        Description: 'Мы будем страдать, страдать и еще раз страдать. Приходите на на наши мероприятия. Не пожалеете.',
        ImageUrl: '/Content/images/event-icon.png'
    },
    {
        Id: 0,
        Title: 'Сдача Курсовой работы',
        OrgName: 'СевГу',
        Adress: 'г. Севастополь, ул. Университетская 33',
        Date: '20.12.2016',
        Description: 'Мы будем страдать, страдать и еще раз страдать. Приходите на на наши мероприятия. Не пожалеете.',
        ImageUrl: '/Content/images/event-icon.png'
    },
    {
        Id: 0,
        Title: 'Сдача Курсовой работы',
        OrgName: 'СевГу',
        Adress: 'г. Севастополь, ул. Университетская 33',
        Date: '20.12.2016',
        Description: 'Мы будем страдать, страдать и еще раз страдать. Приходите на на наши мероприятия. Не пожалеете.',
        ImageUrl: '/Content/images/event-icon.png'
    }],
    categories: [{
        Id: '0',
        Name: 'Праздники',
        EventsCount: '21'
    },
    {
        Id: '0',
        Name: 'Лекции',
        EventsCount: '67'
    },
    {
        Id: '0',
        Name: 'Мастер-классы',
        EventsCount: '12'
    },
    {
        Id: '0',
        Name: 'Концерты',
        EventsCount: '6'
    },
    {
        Id: '0',
        Name: 'Праздники',
        EventsCount: '21'
    },
    {
        Id: '0',
        Name: 'Лекции',
        EventsCount: '67'
    },
    {
        Id: '0',
        Name: 'Мастер-классы',
        EventsCount: '12'
    },
    {
        Id: '0',
        Name: 'Концерты',
        EventsCount: '6'
    },
    {
        Id: '0',
        Name: 'Праздники',
        EventsCount: '21'
    },
    {
        Id: '0',
        Name: 'Лекции',
        EventsCount: '67'
    },
    {
        Id: '0',
        Name: 'Мастер-классы',
        EventsCount: '12'
    },
    {
        Id: '0',
        Name: 'Концерты',
        EventsCount: '6'
    }],
    init: function () {
        this.set('isGuest', !this.isAutorized);
        $('.pageContent.events .DateTime').kendoDatePicker();
        $('.filter-input').kendoMaskedTextBox();
        $('.weight-button, .light-button, .default-btn').kendoButton();
    },
    show: function () {
        KendoHelper.insertExtTemplate('#categories', '#categories-list-block', this.categories);
        KendoHelper.insertExtTemplate('#eventfull-item', '#events-block-list', this.events);
        $('#categories-list-block .form-inline').click(function (event) {
            var id = $(event.target).data('id');
            //запорос по категории
            //удалить мероприятия из вью, перебайндить темплейт
            $('#categories-list-block .form-inline').removeClass('active');
            $(event.target).closest('.form-inline').addClass('active');
        });
        $('a.event-header, .viewDetails').click(function (event) {
            var id = $(event.target).data('id');
            router.navigate('event/' + id);
        });
    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    },
})