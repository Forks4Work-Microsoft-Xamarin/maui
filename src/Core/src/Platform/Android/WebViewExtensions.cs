using AWebView = Android.Webkit.WebView;

namespace Microsoft.Maui.Platform
{
	public static class WebViewExtensions
	{
		public static void UpdateSource(this AWebView platformWebView, IWebView webView)
		{
			platformWebView.UpdateSource(webView, null);
		}

		public static void UpdateSource(this AWebView platformWebView, IWebView webView, IWebViewDelegate? webViewDelegate)
		{
			if (webViewDelegate != null)
			{
				webView.Source?.Load(webViewDelegate);

				platformWebView.UpdateCanGoBackForward(webView);
			}
		}

		public static void UpdateSettings(this AWebView platformWebView, IWebView webView, bool javaScriptEnabled, bool domStorageEnabled)
		{
			if (platformWebView.Settings == null)
				return;

			platformWebView.Settings.JavaScriptEnabled = javaScriptEnabled;
			platformWebView.Settings.DomStorageEnabled = domStorageEnabled;
		}

		public static void Eval(this AWebView platformWebView, IWebView webView, string script)
		{
			string source = "javascript:" + script;

			platformWebView.LoadUrl(source);
		}

		public static void UpdateGoBack(this AWebView platformWebView, IWebView webView)
		{
			if (platformWebView == null)
				return;

			if (platformWebView.CanGoBack())
				platformWebView.GoBack();

			platformWebView.UpdateCanGoBackForward(webView);
		}

		public static void UpdateGoForward(this AWebView platformWebView, IWebView webView)
		{
			if (platformWebView == null)
				return;

			if (platformWebView.CanGoForward())
				platformWebView.GoForward();

			platformWebView.UpdateCanGoBackForward(webView);
		}

		public static void UpdateReload(this AWebView platformWebView, IWebView webView)
		{
			// TODO: Sync Cookies

			platformWebView.Reload();
		}

		internal static void UpdateCanGoBackForward(this AWebView platformWebView, IWebView webView)
		{
			if (webView == null || platformWebView == null)
				return;

			webView.CanGoBack = platformWebView.CanGoBack();
			webView.CanGoForward = platformWebView.CanGoForward();
		}
	}
}