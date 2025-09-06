using HarmonyLib;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views;
using static UI.Views.SecretUpdatePopupView;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(SecretUpdatePopupView), "PlayAnimation")]
    internal class SecretUpdatePopupViewPlayAnimationPatch
    {
        static bool Prefix(ref float ___animationDelay, OperationOutcomeAnimation ___operationOutcomeAnimation)
        {
            Logger.Log("PlayAnimation prefix");
            ___animationDelay = 0.01f;
            return true;
        }
    }
    /// <summary>
    /// Here because this class located in SecretUpdatePopupView.cs
    /// </summary>
    [HarmonyPatch(typeof(LeakedAnimation), "Animate")]
    internal class LeakedAnimationAnimatePatch
    {
        static bool Prefix(ref float delay, ref float ___localDelay, ref float ___flashlightDuration)
        {
            Logger.Log("LeakedAnimationAnimate prefix");
            ___flashlightDuration = 0.1f;
            ___localDelay = 0.1f;
            delay = 0.01f;
            return true;
        }
    }
    /// <summary>
    /// Here because this class located in SecretUpdatePopupView.cs
    /// </summary>
    [HarmonyPatch(typeof(Buttons), "SetInteractable")]
    internal class ButtonsSetInteractablePatch
    {
        static bool Prefix(bool interactable, ref bool instant,ref float delay)
        {
            Logger.Log("ButtonsSetInteractablePatch prefix");
            delay = 0.1f;
            return true;
        }
    }
    /// <summary>
    /// Here because this class located in SecretUpdatePopupView.cs
    /// </summary>
    [HarmonyPatch(typeof(MainHeader), "Animate")]
    internal class MainHeaderSetInteractablePatch
    {
        static bool Prefix(ref float delay, ref float ___localDelay, ref float ___duration)
        {
            ___duration = 0.1f;
            ___localDelay = 0.1f;
            Logger.Log("MainHeaderAnimate prefix");
            delay = 0.1f;
            return true;
        }
    }
    /// <summary>
    /// Here because this class located in SecretUpdatePopupView.cs
    /// </summary>
    [HarmonyPatch(typeof(IntroFadeAnimation), "Animate")]
    internal class IntroFadeAnimationAnimatePatch
    {
        static bool Prefix(IntroFadeAnimation __instance, ref float delay, ref float ___localDelay, ref float ___duration)
        {
            ___duration = 0.1f;
            ___localDelay = 0.1f;
            Logger.Log("IntroFadeAnimation prefix");
            delay = 0.1f;
            return true;
        }
    }
}
