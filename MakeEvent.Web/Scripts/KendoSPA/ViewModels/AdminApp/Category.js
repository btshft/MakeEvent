var categoryVM = kendo.observable({
    categories: [{
        Id: 0,
        DefaultName: 'Name',
        EventCategoryLocalizations: [{
            LanguageId: 1,
            Name: 'Test'
        },
        {
            LanguageId: 2,
            Name: 'Test2'
        }]
    }],
    pageID: 'categoryBlock',
    category:{},
    init: function () {
        this.initKendoWindow();
    },
    show: function () {
        var self = this;
        this.readCategories();
        $('#' + this.categoryBlock + ' .deletBtn').click(function (event) {
            var id = $(event.target).closest('tr').data('id');
            if (confirm('Вы действительно хотите удалить категорию? ')) {
                KendoHelper.ajaxLoader.ajaxPost(URLs.deleteEventCategory + '/?id=' + id, {}, { success: function () { }, error: function () { } });
            };
            this.readCategories();
        });

        $('#' + this.categoryBlock + ' .editBtn').click(function (event) {
            var id = $(event.target).closest('tr').data('id');
            $('#' + self.pageID + ' #addWindow').data('kendoWindow').center().open();
        });
    },
    readCategories: function () {
        KendoHelper.ajaxLoader.ajaxGet(URLs.getEventCategories, {}, {
            success: function (data) {
                if (data.Data !== null) {
                    this.set('categories', data.Data);
                }
            }
        });
    },
    initKendoWindow: function () {
        var self = this;
        debugger;
        var wndw = $('#addWindow');
        wndw.kendoWindow({
            width: '350px',
            height: '450px',
            title: 'Категория',
            visible: false,
            modal: true,
            actions: [
                'Close'
            ],
        });
    },
    openAddWindow: function () {
        $('#addWindow').data('kendoWindow').center().open();
    }
});