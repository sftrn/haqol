using HarmonyLib;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Tutorial;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(TutorialManager), "SetupModeForWaiting")]
    internal class TutorialManagerSetupModeForWaitingPatch
    {
        static bool Prefix()
        {
            Logger.Log("TutorialManagerSetupModeForWaitingPatch");
            return true;
        }
    }
#endif
}
