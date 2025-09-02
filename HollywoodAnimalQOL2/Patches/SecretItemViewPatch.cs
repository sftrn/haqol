using Data.GameObject.Character;
using Enums;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Lists.ItemView;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(SecretItemView), "AnimateRiskLevelChanging")]
    internal class SecretItemViewAnimateRiskLevelChangingPatch
    {

        static bool Prefix(SecretItemView __instance, SecretUpdates update,
    ref float delay,
    CharacterDataWrapper assignedAgent,
    Action onHeaderFinalState,
    int riskLevelChanges,
    bool playFinalSoundEvenWithoutAnim, ref float ___presentationGaugeRiseDurationPerLevel)
        {
            ___presentationGaugeRiseDurationPerLevel = 0;
            delay = 0f;
            return true;
        }
    }
    //8.50.10
    //[HarmonyPatch(typeof(SecretItemView), "SetInteractable")]
    //internal class SecretItemViewSetInteractablePatch
    //{

    //    static bool Prefix(SecretItemView __instance, SecretUpdates update,
    //        ref float delay,
    //        CharacterDataWrapper assignedAgent,
    //        Action onHeaderFinalState,
    //        int riskLevelChanges,
    //        bool playFinalSoundEvenWithoutAnim, ref float ___presentationGaugeRiseDurationPerLevel)
    //    {
    //        ___presentationGaugeRiseDurationPerLevel = 0;
    //        delay = 0f;
    //        return true;
    //    }
    //}
}
