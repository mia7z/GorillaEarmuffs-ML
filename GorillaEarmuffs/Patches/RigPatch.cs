using HarmonyLib;
using UnityEngine;

namespace GorillaEarmuffs.Patches
{
    [HarmonyPatch(typeof(VRRig))]
    [HarmonyPatch("PostTick", MethodType.Normal)]
    internal class RigPatch
    {
        private static void Postfix(VRRig __instance)
        {
            AudioSource voiceAudio = AccessTools.Field(__instance.GetType(), "voiceAudio").GetValue(__instance) as AudioSource;
            if (voiceAudio != null)
            {
                voiceAudio.rolloffMode = AudioRolloffMode.Linear;
                voiceAudio.spatialBlend = 1;
                voiceAudio.pitch = 1;
                
                // Once a good alternative to Jerald comes out, this will be readded.
                
                /*if (EarmuffPage.isWearingEarmuffs)
                {
                    voiceAudio.maxDistance = Plugin.maxDistance.Value;
                    voiceAudio.minDistance = 0;
                } else
                {
                    voiceAudio.maxDistance = 500;
                    voiceAudio.minDistance = 9.901f;
                }*/
                
                voiceAudio.maxDistance = Mod.maxDistance.Value;
                voiceAudio.minDistance = 0;
            }
        }
    }
}
