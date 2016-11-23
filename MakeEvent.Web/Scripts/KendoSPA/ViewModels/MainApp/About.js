var aboutVM = kendo.observable({
    aboutPageContent: '',
    isEdit: true,
    isOnlyView: true,
    init: function () {
        KendoHelper.initEditor('#aboutEditor');
    },
    show: function () {

    }
})