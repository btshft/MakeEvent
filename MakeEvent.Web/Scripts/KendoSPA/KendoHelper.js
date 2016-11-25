var KendoHelper = {
    templateLoader: {
            loadExtTemplate: function(path) {
                var tmplLoader = $.get(path)
                    .success(function(result) {
                        $("body").append(result);
                    })
                    .error(function(result) {
                        console.log("Error Loading Templates");
                    });
            }
    },
    initEditor: function (elem, settings) {
        $(elem).kendoEditor($.extend({
            tools: [
              "bold", "italic", "underline",
              "fontName", "fontSize", "foreColor", "backColor",
              "justifyLeft", "justifyCenter", "justifyRight", "justifyFull",
              "insertUnorderedList", "insertOrderedList", "indent", "outdent",
              "createLink", "unlink", "insertImage",
              "createTable", "addColumnLeft", "addColumnRight", "addRowAbove", "addRowBelow", "deleteRow", "deleteColumn",
              "formatting", "cleanFormatting",
              "viewHtml"
            ],
            messages: {
                bold: "Жирный",
                italic: "Курсив",
                underline: "Подчеркнутый",
                strikethrough: "Зачеркнутый",
                superscript: "Верхний индекс",
                subscript: "Индекс",
                justifyCenter: "По центру",
                justifyLeft: "Слева",
                justifyRight: "Справа",
                justifyFull: "Выровнять",
                insertUnorderedList: "Вставить ненумерованный список",
                insertOrderedList: "Вставить нумерованный список",
                indent: "Абзац",
                outdent: "Выступ",
                createLink: "Вставить ссылку",
                unlink: "Удалить ссылку",
                insertImage: "Вставить картинку",
                insertFile: "Вставить файл",
                insertHtml: "Вставить HTML",
                fontName: "Выбрать шрифт",
                fontNameInherit: "Шрифт",
                fontSize: "Выбрать размер шрифта",
                fontSizeInherit: "Размер",
                formatBlock: "Формат",
                formatting: "Формат",
                style: "Стиои",
                viewHtml: "Просотр HTML",
                overwriteFile: "Файл с именем \"{0}\" уже существует в папке. Хотите ли вы перезаписать его?",
                imageWebAddress: "Сссылка",
                imageAltText: "Альтернативный текст",
                fileWebAddress: "Сссылка",
                fileTitle: "Заголовок",
                linkWebAddress: "Ссылка",
                linkText: "Текст",
                linkToolTip: "Подсказка",
                linkOpenInNewWindow: "Открыть ссылку в новом окне",
                dialogInsert: "Вставить",
                dialogUpdate: "Обновить",
                dialogCancel: "Отменить",
                createTable: "Создать таблицу",
                addColumnLeft: "Добавить столбец слева",
                addColumnRight: "Добавить столбец справа",
                addRowAbove: "Добавить строку рядом",
                addRowBelow: "Добавить строку рядом",
                deleteRow: "Удалить строку",
                deleteColumn: "Удалить столбец"
            },
        },settings));
    },
    insertExtTemplate: function (source, target, data) {
        var template = kendo.template($(source).html());
        var result = template(data);
        $(target).html(result);
    },
        ajaxLoader: (function ($, host) {
        return {
            ajaxPost: function (path, data, callbacks, async) {
                async = typeof (async) != "undefined" ? async : true;
                $.ajax({
                    url: path,
                    method: "POST",
                    data: data,
                    dataType: "json",
                    async: async,
                    success: callbacks.success,
                    error: callbacks.error,
                    complete: callbacks.complete
                });
            },
            ajaxGet: function (path, data, callbacks, async) {
                async = typeof (async) != "undefined" ? async : true;
                $.ajax({
                    url: path,
                    data: data,
                    dataType: "json",
                    async: async,
                    success: callbacks.success,
                    error: callbacks.error,
                    complete: callbacks.complete
                });
            }
        };
    })(jQuery, document)
}