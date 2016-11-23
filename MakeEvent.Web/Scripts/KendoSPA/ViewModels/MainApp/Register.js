var registerVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    fileName: '',
    init: function () {
        this.set('isGuest', !this.isAutorized);
        this.initTextBoxes();
        $('.register-form').kendoValidator({
            messages: {
                required: 'Заполните поле',
                email: 'Неверный формат',
                url: 'Неверный формат'
            }
        });
    },
    show: function () {

    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    },
    initTextBoxes: function () {
        $('[type=text]').not('.DateTime').kendoMaskedTextBox();
        $('.btn-default').kendoButton();
    },
    register: function () {
        if ($('.register-form').data('kendoValidator').validate()) {
        };
    }
})