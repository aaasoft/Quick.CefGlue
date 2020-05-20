using System;

namespace Xilium.CefGlue.WPF
{
    internal sealed class WpfCefLifeSpanHandler : CefLifeSpanHandler
    {
        private readonly WpfCefBrowser _owner;

        public WpfCefLifeSpanHandler(WpfCefBrowser owner)
        {
            if (owner == null) throw new ArgumentNullException("owner");

            _owner = owner;
        }

        protected override void OnAfterCreated(CefBrowser browser)
        {
            _owner.HandleAfterCreated(browser);
        }

        protected override bool OnBeforePopup(CefBrowser browser, CefFrame frame, string targetUrl, string targetFrameName, CefWindowOpenDisposition targetDisposition, bool userGesture, CefPopupFeatures popupFeatures, CefWindowInfo windowInfo, ref CefClient client, CefBrowserSettings settings, ref bool noJavascriptAccess)
        {
            if (_owner.PopupHandler != null)
                return _owner.PopupHandler.Invoke(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref noJavascriptAccess);
            return base.OnBeforePopup(browser, frame, targetUrl, targetFrameName, targetDisposition, userGesture, popupFeatures, windowInfo, ref client, settings, ref noJavascriptAccess);
        }
    }
}
