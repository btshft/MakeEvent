var indexVM = kendo.observable({
    events: [{
        Id: 1, Title: 'Бесплатное пробное занятие ораторским искусством в школе ORATORIS Антона Духовского',
        ShortDescription: 'Занятие состоится 20 и 21 ноября в 19.00. На занятии Вы узнаете пять секретов о том, как стать ещё более успешными в жизни, в общении с людьми и на публичных выступлениях. Вы станете сильнее и увереннее! Занятие будет вести Антон Духовский.',
        Day: '20', Month: 'Ноябрь'
    },
    {Id:2, Title: 'Беcплатный урок «Как выучить разговорный английский?»',
    ShortDescription: 'Вы учили английский более 14 лет со школы, можете читать и писать, но не умеете говорить? Хотите снять барьеры, научиться общаться с иностранцами и получить более высокооплачиваемую работу? Узнайте, как освоить язык всего за год, а заговорить на английском уже через 1 месяц!',
    Day: '13', Month: 'Февраль'}],
    filter:{
        Title: ''
    },
    init: function () {
        this.initButtons();
        this.initTextBoxes();
    },
    show: function () {
        KendoHelper.insertExtTemplate('#event-item', '#events-list-block', this.events);

    },
    goToHelp: function () {
        router.navigate('about');
    },
    searchEvents: function(){

    },
    initButtons: function () {
        $('.weight-button, .light-button, .default-btn').kendoButton();
    },
    initTextBoxes: function () {
        $('[type=text]').kendoMaskedTextBox();
    }
});