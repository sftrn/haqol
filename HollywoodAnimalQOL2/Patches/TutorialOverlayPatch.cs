using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Tutorial;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(TutorialOverlay), "PopupIsActive", MethodType.Getter)]
    internal class TutorialOverlayPopupIsActivePatch
    {
        static void Prefix(ref bool __result)
        {
            Logger.Log($"TutorialOverlayPopupIsActivePatch current value: {__result}");
        }
    }
}
