using System.IO;
using MelonLoader;
using MelonLoader.Utils;

[assembly: MelonInfo(typeof(GorillaEarmuffs.Mod), GorillaEarmuffs.Constants.Name, GorillaEarmuffs.Constants.Version, "gizmogoat")]
[assembly: MelonGame("Another Axiom", "Gorilla Tag")]

namespace GorillaEarmuffs
{
    public class Mod : MelonMod
    {
        public static MelonPreferences_Entry<float> maxDistance;

        public override void OnLateInitializeMelon()
        {
            base.OnLateInitializeMelon();
            
            MelonPreferences_Category category = MelonPreferences.CreateCategory("GorillaEarmuffs");
            category.SetFilePath(Path.Combine(MelonEnvironment.UserDataDirectory, "GorillaEarmuffs.cfg"));
            
            maxDistance = category.CreateEntry("maxDistance", 4.5f, "Max Distance", "Maximum distance before voices become completely inaudible.", false, false, null);
            
            category.SaveToFile();
        }
    }
}
