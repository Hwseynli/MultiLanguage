using Microsoft.Extensions.Localization;

namespace MultiLanguage.Library
{
    public static class UIMessages
    {
        private static IStringLocalizer _localization;
        public static void Configure(IStringLocalizerFactory factory)
        {
            var type = typeof(UIMessages);
            _localization = factory.Create(type);
        }
        public static string WelcomeMessage(string name) => string.Format(_localization["welcome"], name);
        public static string RequiredField => _localization["required"];
    }
}

