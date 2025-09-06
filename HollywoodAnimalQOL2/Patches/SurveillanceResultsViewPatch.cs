using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.SubPanels;
using UI.ScriptedAnimators;
using UI.Views;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(SurveillanceResultsView), "ShowSplashPanel")]
    internal class SurveillanceResultsViewShowSplashPanelPatch
    {
        static bool Prefix(SurveillanceResultsView __instance, ref ScriptedAnimatorBase ___splashAnimation)
        {
            ___splashAnimation.TimeMultiplier = 2f;
            Logger.Log($"SurveillanceResultsViewShowSplashPanelPatch prefix");
            return true;
        }
    }
    [HarmonyPatch(typeof(SurveillanceResultsView), "ShowSecondPanel")]
    internal class SurveillanceResultsViewShowSecondPanelPatch
    {
        static bool Prefix(SurveillanceResultsView __instance, ref ScriptedAnimatorBase ___splashAnimation)
        {
            ___splashAnimation.TimeMultiplier = 2f;
            Logger.Log($"SurveillanceResultsViewShowSecondPanelPatch");
            return true;
        }
    }
    [HarmonyPatch(typeof(SurveillanceResultsView), "ShowSinsPopup")]
    internal class SurveillanceResultsViewShowSinsPopupPatch
    {
        static bool Prefix(SurveillanceResultsView __instance, ref ScriptedAnimatorBase ___splashAnimation)
        {
            ___splashAnimation.TimeMultiplier = 2f;
            Logger.Log($"SurveillanceResultsViewShowSinsPopupPatch");
            return true;
        }
    }
}
