using Colossal.IO.AssetDatabase;
//using Colossal.Logging;
using Colossal.UI;
using Game.Modding;
using Game.PSI;
using Game.SceneFlow;
using Game;
using System.IO;


namespace MixedResidentialOfficeZoning
{
    public class Mod : IMod
    {
        public const string ModName = "Mixed Residential Office Zoning";
        //public static ILog log = LogManager.GetLogger($"{nameof(MixedResidentialOfficeZoning)}.{nameof(Mod)}").SetShowsErrorsInUI(false);
        public static readonly string openModPage = "https://mods.paradoxplaza.com/mods/79067/Windows";
        public static MixedResidentialOfficeZoningSetting Setting;
        public static string uiHostName = "starq-mixed-office";
        public void OnLoad(UpdateSystem updateSystem)
        {
            //log.Info(nameof(OnLoad));

            //if (GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset))
            //log.Info($"Current mod asset at {asset.path}");
            GameManager.instance.modManager.TryGetExecutableAsset(this, out var asset);
            UIManager.defaultUISystem.AddHostLocation(uiHostName, Path.Combine(Path.GetDirectoryName(asset.path), "thumbs"), false);
            Setting = new MixedResidentialOfficeZoningSetting(this);
            AssetDatabase.global.LoadSettings(nameof(MixedResidentialOfficeZoning), Setting, new MixedResidentialOfficeZoningSetting(this));
            Setting.DummySetting = false;
            showChangeNotification();
            
        }

        protected void showChangeNotification()
        {
            if (Setting != null && Setting.HasReadChangeNotice == false)
            {
                NotificationSystem.Push("mod-changed-mixed-office",
                    title: "VP Commercial => Mixed Residential Office Zoning",
                    text: "Mod: 79067. By continue subscribing, you agree to accept the changes.",
                    thumbnail: "https://modscontent.paradox-interactive.com/cities_skylines_2/d964469f-67c9-4e04-8964-3b2fe139186a/content/cover.jpg",
                    onClicked: OpenModPage
                    );
            }

        }
        public static void OpenModPage()
        {
            System.Diagnostics.Process.Start(openModPage);
            NotificationSystem.Pop("mod-changed-mixed-office");
            Setting.HasReadChangeNotice = true;
        }

        public void OnDispose()
        {
            UIManager.defaultUISystem.RemoveHostLocation(uiHostName);
        }
    }
}
