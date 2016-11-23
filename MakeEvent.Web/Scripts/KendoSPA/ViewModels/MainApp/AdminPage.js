var adminVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    categories: [{
        Id: 0,
        Name: 'Категория 1',
        LangId: '1'
    },
    {
        Id: 0,
        Name: 'Category 1',
        LangId: '2'
    }, {
        Id: 0,
        Name: 'Кино',
        LangId: '1'
    },
     {
         Id: 0,
         Name: 'Cinema',
         LangId: '2'
     }],
    news: [ {
        Id: 0,
        Title: 'Открытие организации "MakeEvent"',
        PreviewUrl: '/Content/images/news-icon.png',
        ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
        Date: '10.12.2016',
        Description: 'Описание описание описание описание',
        LangId: '2'
    },
{
    Id: 0,
    Title: 'Открытие организации "MakeEvent"',
    PreviewUrl: '/Content/images/news-icon.png',
    ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
    Date: '10.12.2016',
    Description: 'Описание описание описание описание',
    LangId: '1'
}, {
    Id: 0,
    Title: 'Открытие организации "MakeEvent"',
    PreviewUrl: '/Content/images/news-icon.png',
    ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
    Date: '10.12.2016',
    Description: 'Описание описание описание описание',
    LangId: '1'
},
 {
     Id: 0,
     Title: 'Открытие организации "MakeEvent"',
     PreviewUrl: '/Content/images/news-icon.png',
     ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
     Date: '10.12.2016',
     Description: 'Описание описание описание описание',
     LangId: '2'
 }],
    singleNews:{
        Id: 0,
        Title: '',
        ShortDescription: '',
        Description:'',
        LangId: ''
    },
    singleCategory:{
        Id: 0,
        LangId: '',
        Name: ''
    },
    isAdmin: true,
    isCategoriesActive: true,
    isNewsActive: false,
    isPagesActive: false,
    isAboutPageActive: true,
    isHelpPageActive: false,
    isEdit: false,
    currentLang: '1',
    aboutPage:[{
        Content: '<h1>О нас</h1><p>Текст страницы<p>',
        LangId: 1,
    },
    {
        Content: '<h1>About</h1><p>page content<p>',
        LangId: 2,
    }],
    helpPage: [{
        Content: '<h1>Помощь</h1><p>Текст страницы<p>',
        LangId: 1,
    },
   {
       Content: '<h1>Help</h1><p>page content<p>',
       LangId: 2,
   }],
    init: function () {
        KendoHelper.initEditor('.pageEditor');
        $('.mode-switch').kendoMobileSwitch({
        onLabel: 'Да',
        offLabel: 'Нет'
        });
        $('.langChange').kendoDropDownList({
            dataSource: [{ Name: 'Русский', Id: '1' }, { Name: 'Английский', Id: '2' }],
            dataTextField: "Name",
            dataValueField: "Id",
        });
        this.initWindows();
    },
    show: function () {
        this.changeLang();
    },
    goToPersonal: function () {
        if (this.isAdmin) {
            router.navigate('adminPage');
        }
        else {
            router.navigate('personalPage/' + this.user.Id);
        }
    },
    changeTab: function(event) {
        var itemActive = $(event.target).data('tab');
        this.set('isCategoriesActive', false);
        this.set('isNewsActive', false);
        this.set('isPagesActive', false);
        switch (itemActive) {
            case 'category': this.set('isCategoriesActive', true); break;
            case 'news': this.set('isNewsActive', true); break;
            case 'pages': this.set('isPagesActive', true); break;
        }
    },
    changeSubTab: function (event) {
        var itemActive = $(event.target).data('tab');
        this.set('isAboutPageActive', false);
        this.set('isHelpPageActive', false);
        switch (itemActive) {
            case 'about': this.set('isAboutPageActive', true); break;
            case 'help': this.set('isHelpPageActive', true); break;
       }
    },
    changeEditMode: function () {
        if (!this.isEdit) {
            $('.pageHtml').hide();
            $('.pageEditorBlock').show();
        }
        else {
            $('.pageHtml').show();
            $('.pageEditorBlock').hide();
        }
    },
    changeLang: function () {
        var self = this;
        $('.lang-page').each(function (index, value) {
            if ($(this).data('id') == self.currentLang) {
                $(this).show();}
            else
                $(this).hide();
        });
    },
    addCategory: function () {
        $('#categoryManageWndw').data('kendoWindow').center().open();
    },
    addNews: function () {
        $('#newsManageWndw').data('kendoWindow').center().open();
    },
    initWindows: function () {
        var catWndw = $('#categoryManageWndw');
        catWndw.kendoWindow({
            width: '323px',
            height: '179px',
            title: 'Категория',
            visible: false,
            modal: true,
            actions: [
                'Close'
            ],
        });
        catWndw.data('kendoWindow').bind('close', this.resetCategory.bind(this));
        var newsWndw = $('#newsManageWndw');
        newsWndw.kendoWindow({
            width: '332px',
            height: '380px',
            title: 'Категория',
            visible: false,
            modal: true,
            actions: [
                'Close'
            ],
        });
        newsWndw.data('kendoWindow').bind('close', this.resetNews.bind(this));
    },
    initTableActions: function () {

    },
    saveCategory: function () {
    },
    cancelCat: function () {
        $('#categoryManageWndw').data('kendoWindow').close();
    },
    resetCategory: function () {
        this.singleCategory.set('Id', 0);
        this.singleCategory.set('Name','');
        this.singleCategory.set('LangId','1');
    },
    saveNews: function () {

    },
    cancelNews: function () {
        $('#newsManageWndw').data('kendoWindow').close();
    },
    resetNews: function () {
        this.singleNews.set('Id', 0);
        this.singleNews.set('Title', '');
        this.singleNews.set('ShortDescription', '');
        this.singleNews.set('LangId', '1');
        this.singleNews.set('Description', '');
    }
})