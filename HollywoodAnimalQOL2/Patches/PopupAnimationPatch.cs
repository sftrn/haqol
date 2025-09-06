using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Animations;
using UI.Views;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(PopupAnimation), "OnShowAnimation")]
    internal class PopupAnimationOnShowAnimationPatch
    {
        static void Prefix(PopupAnimation __instance, ref bool ___withDelay, ref bool ___speedUpShow, ref Transform ___content)
        {
            Logger.Log($"PopupAnimationOnShowAnimationPatch delay: {___withDelay} {__instance.name} {___content.name}");
            __instance.NeedToPlayAnimation = false;
            ___speedUpShow = true;
            __instance.AnimationSpeedUp = 10f;
        }
        static void Postfix()
        {
            Logger.Log($"PopupAnimationOnShowAnimationPatch end");
        }
    }
}
