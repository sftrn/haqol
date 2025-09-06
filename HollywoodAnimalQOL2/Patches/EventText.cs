using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.EventUI;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(EventText), "PlayIllustrationZoomIn")]
    internal class EventPlayIllustrationZoomInText
    {
        static void Prefix(EventText __instance, ref float ___zoomInDuration)
        {
            Loggerns.Logger.Log("EventPlayIllustrationZoomInText patch");
            //___zoomInDuration = 0.1f;
        }
    }
}
