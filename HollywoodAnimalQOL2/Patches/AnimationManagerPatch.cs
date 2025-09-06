using HarmonyLib;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UI.Common.Lists.ItemView.AgentForSecretCardItemView;

namespace HollywoodAnimalQOL2.Patches
{

#if DEBUG
    [HarmonyPatch(typeof(AnimationManager), "ResetAndFade", new Type[] {
            typeof(CanvasGroup),typeof(bool),
        typeof(Vector3), typeof(float),
        typeof(AnimationManager.Directions), typeof(AnimationManager.Distances),
        typeof(LeanTweenType), typeof(Action) })]
    internal class AnimationManagerResetAndFadePatch
    {
        static void Prefix(ref AnimationManager __instance, CanvasGroup group,
    bool fadeIn,
    Vector3 position,
    float duration,
    AnimationManager.Directions direction,
    AnimationManager.Distances distance,
    LeanTweenType ltType = LeanTweenType.easeOutCubic,
    Action onCompleteCallback = null)
        {
            Loggerns.Logger.Log("AnimationManagerResetAndFadePatch prefix");
        }
    }
    [HarmonyPatch(typeof(AnimationManager), "Initialize")]
    internal class AnimationManagerInitializePatch
    {
        static void Prefix(ref AnimationManager __instance)
        {
            Loggerns.Logger.Log("AnimationManagerInitializePatch prefix");
        }
    }
    [HarmonyPatch(typeof(AnimationManager), "GetDirection")]
    internal class AnimationManagerGetDirectionPatch
    {
        static void Prefix(ref AnimationManager __instance)
        {
            Loggerns.Logger.Log("AnimationManagerGetDirectionPatch prefix");
        }
    }
#endif
}
