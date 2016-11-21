eventVM = kendo.observable({
    event:{
        Id: 0,
        Title:  'Занятие ораторским искусством в школе ORATORIS Антона Духовского',
        Description: '22 и 27 ноября в 19.00. На занятии Вы узнаете пять секретов о том, как \
                      стать ещё более успешными в жизни, в общении с людьми и на публичных выступлениях.\
                      Вы станете сильнее и увереннее!Занятие будет вести Антон Духовский сертифицированный тренер по публичным выступлениям, генеральный директор и создатель двух самых крупных в Санкт-Петербурге школ: «Школа ораторского искусства Oratoris» и «Школа актёрского мастерства Teatring». Организации с 2009 занимаются: Корпоративным обучением сотрудников компаний: Мегафон, Сбербанк, Банк Санкт-Петербург, Балтика, L’Orеal. Индивидуальной подготовкой спикеров, политических деятелей и групповым обучением для всех желающих. Каждый день на базе школы Невский проспект 78 обучается порядка 150 и более человек. За это время накоплен большой опыт в публичных выступлениях, которым Антон делится на своих занятиях в школе Oratoris.',
        ImgUrl: '/Content/images/event-icon.png',
        Adress: 'Санкт-Петербург, Невский проспект дом 78',
        Date: '20.12.2015 10:20',
        MapImgSrc: 'https://api-maps.yandex.ru/services/constructor/1.0/static/?sid=Q9l2OTSscVivSb7RmPV6v-NF-FUYfTx9&amp;width=500&amp;height=400&amp;lang=ru_RU&amp;sourceType=constructor',
        MapImgHref: 'https://yandex.ru/maps/?um=constructor:Q9l2OTSscVivSb7RmPV6v-NF-FUYfTx9&amp;source=constructorStatic',
        Tickets: [{
            Id: 0,
            Type: 'VIP билет',
            Price: '1000 руб.'
        },
        {
            Id: 0,
            Type: 'Только посмотреть',
            Price: 'Бесплатно'
        }]
    },
    ticketModel: {
        Id: '',
        Type: '',
        Amount: 1,
        FIO: '',
        Email: ''
    },

    init: function () {
        var self = this;

        $('#buyWindow').kendoValidator({
            messages: {
                required: 'Заполните поле',
                email: 'Неверный формат'
            }
        });
        var wndw= $('#buyWindow');
        wndw.kendoWindow({
            width: '330px',
            height: '350px',
            title: 'Оформление заказа',
            visible: false,
            modal: true,
            actions: [
                'Close'
            ],
            close: self.afetrCloseWindow.bind(self)

        });
        },
    afetrCloseWindow: function () {
        this.ticketModel.set('Id','');
        this.ticketModel.set('Type','');
        this.ticketModel.set('Amount', 1);
        this.ticketModel.set('FIO', '');
        this.ticketModel.set('Email', '');
        $('#buyWindow').data('kendoValidator').hideMessages();
    },
    show: function () {
        var self = this;
        $('.choiceAction').click(function (event) {
            var id = $(event.target).closest('tr').data('id');
            var type = $(event.target).closest('tr').data('type');
            var price = $(event.target).closest('tr').data('price');
            self.ticketModel.set('Id', id);
            self.ticketModel.set('Type', type);
            $('#buyWindow').data('kendoWindow').center().open();
        });
    },
    cancel: function () {
      $('#buyWindow').data('kendoWindow').close();
    },
    buyTickets: function () {
        if($('#buyWindow').data('kendoValidator').validate()){}
    }
});