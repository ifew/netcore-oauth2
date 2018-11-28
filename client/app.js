var SampleDataAccess = function () {
    var app = {};
    var clientApiKey = "clientID";
    var clientSecret  = "secretPassword"; 
    var baseUrl       = "http://localhost:5001";
    var getTokenUrl   = baseUrl + "/connect/token";
    var generalApiUrl = baseUrl + "/api/user";
    var appAuthToken; 
 
    app.GetUser = GetUser;
 
    function GetUser()
    {
        var dfd = new $.Deferred();
 
        getAccessTokenByPost()
        .done(function () {
            return $.ajax({
                method:      "get",
                url:         generalApiUrl,
                contentType: "application/json; charset=utf-8",
                headers:     { 'Authorization': 'Bearer ' + appAuthToken }
            })
            .done(function (data) {
                dfd.resolve(data);
                if (data) {
                    $("#results").html(data);
                }
                else {
                    $("#results").html("<b>Failed to Load User.</b>");
                };
            })
            .fail(function () {
                alert("failed to get user.");
                dfd.fail();
            });
        });
        return dfd.promise();
    }
 
    function getAccessTokenByPost() {
        if (appAuthToken) {
            alert("using saved Access Token");
 
            return $.Deferred().resolve().promise();
        }
        else {
            var postData = {
                grant_type:    'client_credentials',
                client_id:     clientApiKey,
                client_secret: clientSecret
            };
            return $.ajax({
                type: 'POST',
                crossDomain: true,
                dataType: 'json',
                data: postData,
                url: getTokenUrl,
                success: function(data){
                    alert("got Access Token");
                        appAuthToken = data.access_token;
                },
                fail: function(data, status, error){
                    alert("getting Access Token failed.");
                }
             })

        }
    }
    return app;
}();