using Data.GameObject.Character;
using Enums;
using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Lists.ItemView;
using UI.ScriptedAnimators;
using UnityEngine;
using static UI.Views.SecretUpdatePopupView;
using Logger = Loggerns.Logger;

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
    bool playFinalSoundEvenWithoutAnim, ScriptedAnimatorBase ___riskLvlLabelShowAnimator)
        {
            Logger.Log($"AnimateRiskLevelChanging");
            ___riskLvlLabelShowAnimator.TimeMultiplier = 10f;
            delay = 0.1f;
            return true;
        }
    }
    [HarmonyPatch(typeof(SecretItemView), "StartPresentationAnimation")]
    internal class SecretItemViewStartPresentationAnimationPatch
    {

        static bool Prefix(SecretItemView __instance,
            ref float ___presentationGaugeRiseDurationPerLevel,
            ref float ___riskLabelUpdateDelay,
            ref ScriptedAnimatorBase ___daysLeftDisplayShowAnimator,
            ref ScriptedAnimatorBase ___riskLvlLabelShowAnimator, ref AnimationCurve ___presentationGaugeRiseCurve)
        {
#if DEBUG
            Logger.Log($"StartPresentationAnimation Speedup anim for {__instance.name}");
#endif
            //for (int i = 0; i < ___presentationGaugeRiseCurve.keys.Length; i++)
            //{
            //    ___presentationGaugeRiseCurve.keys[i].time = 0.05f*i;
            //}
            ___daysLeftDisplayShowAnimator.TimeMultiplier = 10f;
            ___riskLvlLabelShowAnimator.TimeMultiplier = 10f;
            ___presentationGaugeRiseDurationPerLevel = 0.1f;
            ___riskLabelUpdateDelay = 0.1f;
            return true;
        }
    }
    [HarmonyPatch(typeof(SupressedAnimation), "Animate")]
    internal class SecretItemViewAnimatePatch
    {

        static bool Prefix(SupressedAnimation __instance,
            ref float delay, ref float ___localDelay)
        {
            delay = 0.1f;
            ___localDelay = 0.1f;
            Logger.Log($"SupressedAnimation");
            return true;
        }
    }
    [HarmonyPatch(typeof(OperationOutcomeAnimation), "Animate")]
    internal class OperationOutcomeAnimationPatch
    {

        static bool Prefix(OperationOutcomeAnimation __instance,
            ref float delay, ref float ___localDelay, ref float ___showDuration)
        {
            delay = 0.1f;
            ___localDelay = 0.1f;
            ___showDuration = 0.1f;
            Logger.Log($"SupressedAnimation");
            return true;
        }
    }
    [HarmonyPatch(typeof(SecretItemView), "PlayPresentationAnimation")]
    internal class SecretItemViewPlayPresentationAnimationPatch
    {

        static bool Prefix(SecretItemView __instance,
            ref float ___presentationGaugeRiseDurationPerLevel, ref float ___riskLabelUpdateDelay)
        {
            ___presentationGaugeRiseDurationPerLevel = 0.05f;
            ___riskLabelUpdateDelay = 0.05f;
            __instance.OperationDurationAnimation = 0;
            Logger.Log($"PlayPresentationAnimation");
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
