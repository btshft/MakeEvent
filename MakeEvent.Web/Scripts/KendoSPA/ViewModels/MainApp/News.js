var newsVM = kendo.observable({
    isAutorized: true,
    user: {
        Id: 0,
        Login: 'Test'
    },
    news: [{
        Id: 0,
        Title: 'Открытие организации "MakeEvent"',
        PreviewUrl: '/Content/images/news-icon.png',
        ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
        Date: '10.12.2016'
    },
 {
     Id: 0,
     Title: 'Открытие организации "MakeEvent"',
     PreviewUrl: '/Content/images/news-icon.png',
     ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
     Date: '10.12.2016'
 },
  {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  },
    {
        Id: 0,
        Title: 'Открытие организации "MakeEvent"',
        PreviewUrl: '/Content/images/news-icon.png',
        ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
        Date: '10.12.2016'
    },
 {
     Id: 0,
     Title: 'Открытие организации "MakeEvent"',
     PreviewUrl: '/Content/images/news-icon.png',
     ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
     Date: '10.12.2016'
 },
  {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  }, {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  },
 {
     Id: 0,
     Title: 'Открытие организации "MakeEvent"',
     PreviewUrl: '/Content/images/news-icon.png',
     ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
     Date: '10.12.2016'
 },
  {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  }, {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  },
 {
     Id: 0,
     Title: 'Открытие организации "MakeEvent"',
     PreviewUrl: '/Content/images/news-icon.png',
     ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
     Date: '10.12.2016'
 },
  {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  }, {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  },
 {
     Id: 0,
     Title: 'Открытие организации "MakeEvent"',
     PreviewUrl: '/Content/images/news-icon.png',
     ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
     Date: '10.12.2016'
 },
  {
      Id: 0,
      Title: 'Открытие организации "MakeEvent"',
      PreviewUrl: '/Content/images/news-icon.png',
      ShortDescription: 'Еще чуть-чуть и мы доделаем эту замечательную курсовую работу.',
      Date: '10.12.2016'
  }],
    init: function () {
        this.set('isGuest', !this.isAutorized);
        $('.pageContent.news .DateTime').kendoDatePicker();
    },
    show: function () {
     //   KendoHelper.insertExtTemplate('#news-item', '#news-list-block', this.news);
        var dataSource = new kendo.data.DataSource({
            data: this.news,
            pageSize: 5
        });

        $("#pager").kendoPager({
            dataSource: dataSource,
            change: function () {
                $('a.news-link').click(function (event) {
                    var id = $(event.target).data('id');
                    router.navigate('newsitem/' + id);
                });
            }
        });

        $("#listView").kendoListView({
            dataSource: dataSource,
            template: kendo.template($('#testnews-item').html())
        });
        $('a.news-link').click(function (event) {
            var id = $(event.target).data('id');
            router.navigate('newsitem/' + id);
        });
    },
    goToPersonal: function () {
        router.navigate('personalPage/' + this.user.Id);
    }
});