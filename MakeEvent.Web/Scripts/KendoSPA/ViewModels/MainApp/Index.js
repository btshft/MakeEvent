var indexVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    events: [{
        Id: 1, Title: 'Бесплатное пробное занятие ораторским искусством в школе ORATORIS Антона Духовского',
        ShortDescription: 'Занятие состоится 20 и 21 ноября в 19.00. На занятии Вы узнаете пять секретов о том, как стать ещё более успешными в жизни, в общении с людьми и на публичных выступлениях. Вы станете сильнее и увереннее! Занятие будет вести Антон Духовский.',
        Day: '20', Month: 'Ноябрь'
    },
    {
        Id: 2, Title: 'Беcплатный урок «Как выучить разговорный английский?»',
        ShortDescription: 'Вы учили английский более 14 лет со школы, можете читать и писать, но не умеете говорить? Хотите снять барьеры, научиться общаться с иностранцами и получить более высокооплачиваемую работу? Узнайте, как освоить язык всего за год, а заговорить на английском уже через 1 месяц!',
        Day: '13', Month: 'Февраль'
    },
    {
        Id: 1, Title: 'Бесплатное пробное занятие ораторским искусством в школе ORATORIS Антона Духовского',
        ShortDescription: 'Занятие состоится 20 и 21 ноября в 19.00. На занятии Вы узнаете пять секретов о том, как стать ещё более успешными в жизни, в общении с людьми и на публичных выступлениях. Вы станете сильнее и увереннее! Занятие будет вести Антон Духовский.',
        Day: '20', Month: 'Ноябрь'
    },
    {
        Id: 2, Title: 'Беcплатный урок «Как выучить разговорный английский?»',
        ShortDescription: 'Вы учили английский более 14 лет со школы, можете читать и писать, но не умеете говорить? Хотите снять барьеры, научиться общаться с иностранцами и получить более высокооплачиваемую работу? Узнайте, как освоить язык всего за год, а заговорить на английском уже через 1 месяц!',
        Day: '13', Month: 'Февраль'
    },
    {
        Id: 1, Title: 'Бесплатное пробное занятие ораторским искусством в школе ORATORIS Антона Духовского',
        ShortDescription: 'Занятие состоится 20 и 21 ноября в 19.00. На занятии Вы узнаете пять секретов о том, как стать ещё более успешными в жизни, в общении с людьми и на публичных выступлениях. Вы станете сильнее и увереннее! Занятие будет вести Антон Духовский.',
        Day: '20', Month: 'Ноябрь'
    },
    {
        Id: 2, Title: 'Беcплатный урок «Как выучить разговорный английский?»',
        ShortDescription: 'Вы учили английский более 14 лет со школы, можете читать и писать, но не умеете говорить? Хотите снять барьеры, научиться общаться с иностранцами и получить более высокооплачиваемую работу? Узнайте, как освоить язык всего за год, а заговорить на английском уже через 1 месяц!',
        Day: '13', Month: 'Февраль'
    }],
    filter: {
        Title: ''
    },
    window: {
        login: '',
        password: ''
    },
    init: function () {
        this.initButtons();
        this.initTextBoxes();
        this.initEnterWidow();
        this.set('isGuest', !this.isAutorized);
    },
    show: function () {
        KendoHelper.insertExtTemplate('#event-item', '#events-list-block', this.events);
        $('a.event-header').click(function (event) {
            var id = $(event.target).data('id');
            router.navigate('event/' + id);
        });

    },
    goToHelp: function () {
        router.navigate('about');
    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    },
    searchEvents: function () {

    },
    initButtons: function () {
        $('.weight-button, .light-button, .default-btn').kendoButton();
    },
    initTextBoxes: function () {
        $('[type=text]').kendoMaskedTextBox();
    },
    openEnterWidow: function () {
        $('#enterWindow').data('kendoWindow').center().open();
    },
    initEnterWidow: function () {
        var wndw = $('#enterWindow');
        wndw.kendoWindow({
            width: '240px',
            height: '180px',
            title: 'Вход',
            visible: false,
            actions: [
                'Close'
            ],
        });
        wndw.bind('close', this.afterWndwClose);
    },
    afterWndwClose: function () {
        this.window.set('login', '');
        this.window.set('password', '');
    },
    start: function () {
    //    if (this.isAutorized) {
      //      router.navigate('personalPage/' + this.user.Id);
       // }
       // else {
            this.goToRegister();
        //}
    },
    goToRegister: function () {
        $('#enterWindow').data('kendoWindow').close();
        router.navigate('register');
    }
});