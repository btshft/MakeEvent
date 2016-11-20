$(document).on('ready', function () {
    // views, layouts
    var layout = new kendo.Layout($("#layout").html());
    var index = new kendo.View("indexTemplate", { model: indexVM, init: indexVM.init.bind(indexVM), show: indexVM.show.bind(indexVM) });
    var contacts = new kendo.View("contactsTemplate", { model: contactsVM, init: contactsVM.init.bind(contactsVM), show: contactsVM.show.bind(contactsVM) });
    var news = new kendo.View("newsTemplate", { model: newsVM, init: newsVM.init.bind(newsVM), show: newsVM.show.bind(newsVM) });
    var about = new kendo.View("aboutTemplate", { model: aboutVM, init: aboutVM.init.bind(aboutVM), show: aboutVM.show.bind(aboutVM) });
    var events = new kendo.View("eventsTemplate", { model: eventsVM, init: eventsVM.init.bind(eventsVM), show: eventsVM.show.bind(eventsVM) });
    var organizations = new kendo.View("organizationsTemplate", { model: organizationsVM, init: organizationsVM.init.bind(organizationsVM), show: organizationsVM.show.bind(organizationsVM) });
    var personal = new kendo.View("personalTemplate", { model: personalVM, init: personalVM.init.bind(personalVM), show: personalVM.show.bind(personalVM) });
    var enter = new kendo.View("enterTemplate", { model: enterVM, init: enterVM.init.bind(enterVM), show: enterVM.show.bind(enterVM) });
    var register = new kendo.View("registerTemplate", { model: registerVM, init: registerVM.init.bind(registerVM), show: registerVM.show.bind(registerVM) });
    // routing
    var router = new kendo.Router();
    router.bind("init", function () {
        layout.render($("#app"));
    });
    router.route("/", function () {
        layout.showIn("#content", index);
    });
    router.route("index", function () {
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
    router.route("organizations", function () {
        layout.showIn("#content", organizations)
    });
    router.route("events", function () {
        layout.showIn("#content", events)
    });
    router.route("personalPage", function () {
        layout.showIn("#content", personal)
    });
    router.route("enter", function () {
        layout.showIn("#content", enter)
    });
    router.route("register", function () {
        layout.showIn("#content", register)
    });
    router.start();
})