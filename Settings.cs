using Colossal.IO.AssetDatabase;
using Game.Modding;
using Game.Settings;

namespace MixedResidentialOfficeZoning
{
    [FileLocation("ModsSettings\\" + nameof(MixedResidentialOfficeZoning))]
    public class MixedResidentialOfficeZoningSetting : ModSetting
    {

        public MixedResidentialOfficeZoningSetting(IMod mod) : base(mod)
        {
            SetDefaults();
        }

        [SettingsUIHidden]
        public bool HasReadChangeNotice { get; set; }
        public bool DummySetting { get; set; }

        public override void SetDefaults()
        {
            DummySetting = true;
            HasReadChangeNotice = false;
        }

        public override void Apply()
        {
            base.Apply();
        }
    }
}
