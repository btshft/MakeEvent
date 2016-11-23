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
    var event = new kendo.View("eventItemTemplate", { model: eventVM, init: eventVM.init.bind(eventVM), show: eventVM.show.bind(eventVM) });
    var org = new kendo.View("orgItemTemplate", { model: organizationVM, init: organizationVM.init.bind(organizationVM), show: organizationVM.show.bind(organizationVM) });
    var newsItem = new kendo.View("newsItemTemplate", { model: newsItemVM, init: newsItemVM.init.bind(newsItemVM), show: newsItemVM.show.bind(newsItemVM) });;
    // routing
    router = new kendo.Router();
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
    router.route("newsItem/:id", function (id) {
        newsItemVM.set('newsId', id);
        layout.showIn("#content", newsItem);
    });
    router.route("about", function () {
        layout.showIn("#content", about);
    });
    router.route("organizations", function () {
        layout.showIn("#content", organizations);
    });
    router.route("organization/:id", function (id) {
        organizationVM.set('orgId', id);
        layout.showIn("#content", org);
    });
    router.route("events", function () {
        layout.showIn("#content", events);
    });
    router.route("event/:id", function (id) {
        eventVM.set('eventId', id);
        layout.showIn("#content", event);
    });
    router.route("personalPage/:id", function (id) {
        personalVM.set('userId', id);
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