var KendoHelper = {
    templateLoader: {
            loadExtTemplate: function(path){
                var tmplLoader = $.get(path)
                    .success(function(result){
                        $("body").append(result);
                    })
                    .error(function(result){
                        console.log("Error Loading Templates");
                    })
            }
        }
}