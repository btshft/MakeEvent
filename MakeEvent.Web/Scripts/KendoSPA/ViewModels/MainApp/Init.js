$(document).on('ready', function () {
    // views, layouts
    var layout = new kendo.Layout($("#layout").html());
    var index = new kendo.View("indexTemplate", { model: indexVM, init: indexVM.init.bind(indexVM), show: indexVM.show.bind(indexVM) });
    var contacts = new kendo.View("contactsTemplate", { model: contactsVM, init: contactsVM.init.bind(contactsVM), show: contactsVM.show.bind(contactsVM) });
    var news = new kendo.View("newsTemplate", { model: newsVM, init: newsVM.init.bind(newsVM), show: newsVM.show.bind(newsVM) });
   var about = new kendo.View("aboutTemplate", { model: aboutVM, init: aboutVM.init.bind(aboutVM), show: aboutVM.show.bind(aboutVM) });

    // routing
    var router = new kendo.Router();

    router.bind("init", function () {
        layout.render($("#app"));
    });

    router.route("/", function () {
        layout.showIn("#content", index);
    });

    router.route("contacts", function () {
        layout.showIn("#content", contacts);
    });

    router.route("news", function () {
        layout.showIn("#content", news);
    });

    router.route("about", function () {
        layout.showIn("#content", about);
    });
    router.start();
})