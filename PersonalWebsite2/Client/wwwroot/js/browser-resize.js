window.browserResize = {

    registerResizeCallback: function () {
        window.addEventListener("resize", browserResize.resized);
    },

    resized: function () {
        DotNet.invokeMethodAsync("PersonalWebsite2.Client", 'OnBrowserResize').then(data => data);
    }

}