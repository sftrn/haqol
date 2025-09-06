using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.SubPanels;
using UI.ScriptedAnimators;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(SimpleSubPanel), "ShowLogic")]
    internal class SimpleSubPanelShowLogicPatch
    {
        static bool Prefix(SimpleSubPanel __instance, ref ScriptedAnimatorBase ___showAnimator)
        {
            Logger.Log($"Speedup ShowLogic {__instance.IDText}");
            if (___showAnimator != null)
            {
                ___showAnimator.TimeMultiplier = 10f;
                ___showAnimator.AnimationDuration = Enums.AnimationDurations.Short;
            }
                return true;
        }
    }
    [HarmonyPatch(typeof(SimpleSubPanel), "Show", new Type[] {  typeof(bool) })]
    internal class SimpleSubPanelShowPatch
    {
        static bool Prefix(SimpleSubPanel __instance, ref ScriptedAnimatorBase ___showAnimator, ref int ___animationFrameDelay)
        {
            __instance.VerboseLogging = true;
            ___animationFrameDelay = 0;

            Logger.Log($"Speedup Show {__instance.IDText}");
            if (___showAnimator != null)
            {
                ___showAnimator.TimeMultiplier = 10f;
                ___showAnimator.AnimationDuration = Enums.AnimationDurations.Short;
            }
            return true;
        }
    }
}
