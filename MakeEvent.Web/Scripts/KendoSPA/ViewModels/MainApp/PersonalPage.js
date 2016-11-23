personalVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test',
        Email: 'test@gmail.com',
        Phone: '+7(978)704-56-54',
        Site: 'http://tests.com',
        Description: 'Мы занимаемся очень интересными вещами. Приходите на на наши мероприятия. Не пожалеете.',
        LogoUrl: '/Content/images/org-logo.png'
    },
    events: [
     {
         Id: 0,
         Title: 'Концерт группы "Одуванчики"',
         OrgName: 'Тест',
         Adress: 'г. Севастополь, ул. Университетская 33',
         Date: '20.12.2016',
         Description: 'Мы будем страдать, страдать и еще раз страдать. Приходите на на наши мероприятия. Не пожалеете.',
         ImageUrl: '/Content/images/event-icon.png'
     },
    {
        Id: 0,
        Title: 'Фестиваль шуб',
        OrgName: 'Тест',
        Adress: 'г. Севастополь, ул. Университетская 33',
        Date: '20.12.2016',
        Description: 'Мы будем страдать, страдать и еще раз страдать. Приходите на на наши мероприятия. Не пожалеете.',
        ImageUrl: '/Content/images/event-icon.png'
    },
     {
         Id: 0,
         Title: 'Открытый фестиваль кино',
         OrgName: 'Тест',
         Adress: 'г. Севастополь, ул. Университетская 33',
         Date: '20.12.2016',
         Description: 'Мы будем страдать, страдать и еще раз страдать. Приходите на на наши мероприятия. Не пожалеете.',
         ImageUrl: '/Content/images/event-icon.png'
     }],
    tickets: [{
        Id: 12130,
        Type: 'Vip',
        Fio: 'Петров Петр Петрович',
        EventTitle: 'Концерт группы "Одуванчики"',
        Status: 'Оплачено'
    },
    {
        Id: 123230,
        Type: 'Просто посмотреть',
        Fio: 'Иванов Иван Иваноыич',
        EventTitle: 'Открытый фестиваль кино',
        Status: 'Оплачено'
    },
    {
        Id: 45450,
        Type: 'Классический',
        Fio: 'Шубина Инна Петровна',
        EventTitle: 'Фестиваль шуб',
        Status: 'Бронь'
    },
    {
        Id: 03434,
        Type: 'Vip',
        Fio: 'Игнатьева Инна Карловна',
        EventTitle: 'Фестиваль шуб',
        Status: 'Оплачено'
    }],
    singleEvent: {
        Id: 0,
        Title: 'Занятие ораторским искусством в школе ORATORIS Антона Духовского',
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
        isAddingTickets: false,
        isEventsActive: true,
        isTicketsActive: false,
        init: function () {
            this.set('isGuest', !this.isAutorized);
            this.initUserWindow();
        },
        show: function () {
        },
        changeTab: function(event){
            var itemActive = $(event.target).data('tab');
            if(itemActive == 'tickets'){
                this.set('isEventsActive', false);
                this.set('isTicketsActive', true);
            }
            else {
                this.set('isEventsActive', true);
                this.set('isTicketsActive', false);

            }
        },
        goToPersonal: function () {
            router.navigate('personalPage/' + this.user.Id);
        },
        initUserWindow: function(){
            var wndw = $('#userEditCardWindow');
            wndw.kendoWindow({
                width: '350px',
                height: '450px',
                title: 'Редактировать профиль',
                visible: false,
                modal: true,
                actions: [
                    'Close'
                ],
            });
            var wndw = $('#editCreateEventWindow');
            wndw.kendoWindow({
                width: '730px',
                height: '450px',
                title: 'Мероприятие',
                visible: false,
                modal: true,
                actions: [
                    'Close'
                ],
            });
        },
        editUserInfo: function () {
            $('#userEditCardWindow').data('kendoWindow').center().open();
        },
        cancelEdit: function () {
            $('#userEditCardWindow').data('kendoWindow').close();
        },
        saveUserCard: function () {

        },
        addEvent: function () {
            $('#editCreateEventWindow').data('kendoWindow').center().open();
        },
        addTicket: function () {
            this.set('isAddingTickets', true);
        },
        cancelAddTicket: function () {
            this.set('isAddingTickets', false);
        },

    });