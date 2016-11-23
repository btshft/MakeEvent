newsItemVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    isAddingCommment: false,
    comment:{
        Author: '',
        Content: '',
        Email: ''
    },
    model: {
        Id: 0,
        Title: 'Просмотр полной информации о новости',
        Content: '«О Жанне д’Арк мы знаем больше, чем о ком-либо другом из ее современников,\
                  и в то же время трудно найти среди людей XV века другого человека, чей образ\
                 представлялся бы потомкам таким загадочным.»\n«...Родилась она в деревушке Домреми\
                 в Лотарингии в 1412 году. Известно, что она рождена от честных и справедливых родителей.\
                 В ночь на Рождество, когда народы имеют обыкновение в великом блаженстве чтить труды Христовы\
                 вошла она в мир смертный. И петухи, cловно провозвестники новой радости, кричали тогда необыкновенным,\
                 до сих пор не слыханным криком. Видели, как они на протяжении более чем двух часов хлопали крыльями, предсказывая то,\
                 что суждено было этой малютке». Об этом факте сообщает Персеваль де Буленвилье, \
                 советник и камергер короля в письме милонскому герцогу, которое может быть названо ее первой биографией. \
                 Но скорее всего это описание является легендой, т. к. об этом не упоминает ни одна хроника и рождение Жанны не оставило\
                 ни малейшего следа в памяти односельчан — жителей Домреми, выступавших в качестве свидетелей на процессе реабилитации.',
        ImgUrl: '/Content/images/news-icon.png',
        Date: '20.12.2015',
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
    init: function () {
        this.set('isGuest', !this.isAutorized);
        $('.weight-button, .light-button, .btn-default, .btn').kendoButton();
        $('[type=text], [type=email]').not('.DateTime').kendoMaskedTextBox();
        $('.comment-form').kendoValidator({
            messages: {
                required: 'Заполните поле',
                email: 'Неверный формат ввода' }
        });
    },
    show: function () {

    },
    commentFormOpen: function(){
        this.set('isAddingCommment', !this.isAddingCommment);
        this.comment.set('Author', '');
        this.comment.set('Content', '');
        this.comment.set('Email', '');
        $('.comment-form').data('kendoValidator').hideMessages()
    },
    cancelComment: function () {
        this.set('isAddingCommment', false);
        this.comment.set('Author','');
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