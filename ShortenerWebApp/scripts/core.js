function Link() {
    var that = this;
    that.Url = ko.observable("").extend({ required: true });
    that.ShortUrl = ko.observable("");
}
function LinkVm() {
    var that = this;
    that.Link = new Link();
    that.ExistingLinks = ko.observableArray();
    that.Loaded = ko.observable(false);
    that.HasError = ko.observable(false);
    that.ValidationMessage = ko.observable();

    $.ajax({
        url: '/Shortener/GetLinks',
        type: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            that.ExistingLinks(result.ExistingLinks);
            that.Loaded(true);
        }
    });

    that.reset = function () {
        that.Link.Url("");
        that.Link.ShortUrl("");
        that.HasError(false);
        that.ValidationMessage("");
    };
    that.submit = function () {
        if (!that.Link.Url().trim()) {
            that.HasError(true);
            that.ValidationMessage("Url should not be empty");
        }
        else {
            that.HasError(false);
            that.ValidationMessage("");
            var json1 = ko.toJSON(that.Link);
            that.Link.ShortUrl("Generating...");
            $.ajax({
                url: '/Shortener/SaveLink',
                type: 'POST',
                dataType: 'json',
                data: json1,
                contentType: 'application/json; charset=utf-8',
                success: function (result) {
                    that.Link.ShortUrl(result.SavedLink.ShortUrl);
                    that.ExistingLinks(result.ExistingLinks);
                }
            });
        }
    };
};
var _vm = new LinkVm();
$(function () {
    ko.applyBindings(_vm);
});