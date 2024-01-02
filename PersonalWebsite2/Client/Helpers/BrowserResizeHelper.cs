using Microsoft.JSInterop;

namespace PersonalWebsite2.Client.Helpers {
    public class BrowserResizeHelper {

        public static event Func<Task> OnResize;

        public BrowserResizeHelper(IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeAsync<object>("browserResize.registerResizeCallback");
        }

        [JSInvokable]
        public static async Task OnBrowserResize()
        {
            if (OnResize != null)
            {
                await OnResize.Invoke();
            }
        }

    }
}
