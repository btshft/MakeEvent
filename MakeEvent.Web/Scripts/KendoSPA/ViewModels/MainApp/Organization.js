organizationVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    isAddingCommment: false,
    organization: {
        Id: 0,
        Name: 'ООО "Тест Ивент"',
        LogoUrl: '/Content/images/org-logo.png',
        Description: 'Мы занимаемся очень интересными вещами. Приходите на на наши мероприятия. Не пожалеете.',
        Site: 'http://test.ru',
        Phone: '+79787897654',
        Comments: [{
            Id: 0,
            Author: 'Петров Петр Иванович',
            Content: 'Браво! Очень полезная статья',
            Date: '21.12.2015'
        },
        {
            Id: 0,
            Author: 'Петров Петр Иванович',
            Content: 'Что за ерунда на сайте с мероприятиями.',
            Date: '21.12.2015'
        },
        {
            Id: 0,
            Author: 'Петров Петр Иванович',
            Content: 'Что за ерунда на сайте с мероприятиями. Что за ерунда на сайте с мероприятиями. Что за ерунда на сайте с мероприятиями. Что за ерунда на сайте с мероприятиями. Я возмущен!!!',
            Date: '21.12.2015'
        }]
    },
    comment: {
        Author: '',
        Content: '',
        Email: ''
    },
    init: function () {
        this.set('isGuest', !this.isAutorized);
        $('.weight-button, .light-button, .btn-default, .btn').kendoButton();
        $('[type=text], [type=email]').not('.DateTime').kendoMaskedTextBox();
        $('.comment-form').kendoValidator({
            messages: {
                required: 'Заполните поле',
                email: 'Неверный формат ввода'
            }
        });
    },
    show: function () {

    },
    commentFormOpen: function () {
        this.set('isAddingCommment', !this.isAddingCommment);
        this.comment.set('Author', '');
        this.comment.set('Content', '');
        this.comment.set('Email', '');
        $('.comment-form').data('kendoValidator').hideMessages()
    },
    cancelComment: function () {
        this.set('isAddingCommment', false);
        this.comment.set('Author', '');
        this.comment.set('Content', '');
        this.comment.set('Email', '');
        $('.comment-form').data('kendoValidator').hideMessages()
    },
    saveComment: function () {
        if ($('.comment-form').data('kendoValidator').validate()) {

        };
    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    }
});