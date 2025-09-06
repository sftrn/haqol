using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views;
using UI.Views.Tutorial;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(TutorialBg), "OnGuiShown")]
    internal class TutorialBGOnGuiShownPatch
    {
        static void Prefix()
        {
            Logger.Log("TutorialBGOnGuiShownPatch");
        }
    }
}
