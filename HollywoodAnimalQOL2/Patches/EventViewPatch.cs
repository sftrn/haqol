using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ScriptedAnimators;
using UI.Views;

namespace HollywoodAnimalQOL2.Patches
{
    
    [HarmonyPatch(typeof(EventView), "OnGuiShown")]
    internal class EventViewOnGuiShownPatch
    {
        static void Prefix(ref float ___startAnimationDelay,ref float ___startShowingOptionsDelay,
            ref ScriptedAnimatorBase ___starterAnim, ref ScriptedAnimatorBase ___starterPatternsAnim,
            ref float ___illustrationZoomInDelay, ref bool ___useIllustrationZoomIn)
        {
            Logger.Log("EventViewOnGuiShownPatch");
            ___startAnimationDelay = 0.1f;
            //___useIllustrationZoomIn = false;
            ___starterAnim.VerboseLogging = true;
            ___illustrationZoomInDelay = 0.1f;
            ___startShowingOptionsDelay = 0.1f;
            ___starterAnim.TimeMultiplier = 10f;
            //___starterPatternsAnim.TimeMultiplier = 2f;
        }
    }
    [HarmonyPatch(typeof(EventView), "NextInEvent")]
    internal class EventViewNextInEventPatch
    {
        static void Prefix(bool withAnimation)
        {
            Logger.Log("EventViewNextInEventPatch");
        }
        static void Postfix(bool withAnimation)
        {
            Logger.Log("EventViewNextInEventPatch end");
        }
    }
}
