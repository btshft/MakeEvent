$(document).on('ready', function () {
    // views, layouts
    var layout = new kendo.Layout($("#layout").html());
    var news = new kendo.View("newsTemplate", { model: newsVM, init: newsVM.init.bind(newsVM), show: newsVM.show.bind(newsVM) });
    var pages = new kendo.View("pagesTemplate", { model: pagesVM, init: pagesVM.init.bind(pagesVM), show: pagesVM.show.bind(pagesVM) });
    var category = new kendo.View("categoriesTemplate", { model: categoryVM, init: categoryVM.init.bind(categoryVM), show: categoryVM.show.bind(categoryVM) });

    router = new kendo.Router();
    router.bind("init", function () {
        layout.render($("#app"));
    });
    router.route("/", function () {
        layout.showIn("#page", news);
    });
    router.route("news", function () {
        layout.showIn("#page", news);
    });
    router.route("pages", function () {
        layout.showIn("#page", pages);
    });
    router.route("categories", function () {
        layout.showIn("#page", category);
    });
    router.start();
})