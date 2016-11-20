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
    init: function () {
        this.set('isGuest', !this.isAutorized);
        $('.DateTime').kendoDatePicker();
        $('.filter-input').kendoMaskedTextBox();
        $('.weight-button, .light-button, .default-btn').kendoButton();
    },
    show: function () {
        KendoHelper.insertExtTemplate('#eventfull-item', '#events-block-list', this.events);
    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    },
})