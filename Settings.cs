using Colossal;
using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;
using System.Collections.Generic;

namespace MixedResidentialOfficeZoning
{
    [FileLocation("ModsSettings\\" + nameof(MixedResidentialOfficeZoning))]
    public class MixedResidentialOfficeZoningSetting : ModSetting
    {
        public const string sectionMain = "Main";
        public const string actions = "Actions";

        public MixedResidentialOfficeZoningSetting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        [SettingsUIHidden]
        public bool ProcessedThumbnails { get; set; }

        [SettingsUIHidden]
        public bool HasReadChangeNotice { get; set; }

        [SettingsUIHidden]
        public bool DummySetting { get; set; }


        [SettingsUIButton]
        [SettingsUISection(sectionMain, actions)]
        public bool RedoThumbnail
        {
            set { Mod.ProcessThumbnail(); }
        }

        public override void SetDefaults()
        {
            DummySetting = true;
            HasReadChangeNotice = false;
            ProcessedThumbnails = false;
        }

        public override void Apply()
        {
            base.Apply();
        }
    }

    public class LocaleEN : IDictionarySource
    {
        private readonly MixedResidentialOfficeZoningSetting m_Setting;
        public LocaleEN(MixedResidentialOfficeZoningSetting setting)
        {
            m_Setting = setting;
        }
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Mixed Residential Office Zoning" },
                { m_Setting.GetOptionTabLocaleID(MixedResidentialOfficeZoningSetting.sectionMain), "Main" },
                { m_Setting.GetOptionGroupLocaleID(MixedResidentialOfficeZoningSetting.actions), "Actions" },

                { m_Setting.GetOptionLabelLocaleID(nameof(MixedResidentialOfficeZoningSetting.RedoThumbnail)), "Reset Thumbnail Cache [powered by Asset Icon Library]" },
                { m_Setting.GetOptionDescLocaleID(nameof(MixedResidentialOfficeZoningSetting.RedoThumbnail)), $"This button will redo the thumbnails from the Asset Icon Library to work with this mod. Make sure you're already subscribed to it to have the thumbnails." },

            };
        }

        public void Unload()
        {

        }
    }
}
