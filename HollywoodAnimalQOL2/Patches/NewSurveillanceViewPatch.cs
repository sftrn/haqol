using HarmonyLib;
using Loggerns;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(NewSurveillanceView), "UpdateState")]
    internal class NewSurveillanceViewUpdateStatePatch
    {
        static bool Prefix(NewSurveillanceView __instance, ref bool instant)
        {
            Logger.Log($"Update state instant for {__instance.name}");
            instant = true;
            return true;
        }
    }
    [HarmonyPatch(typeof(NewSurveillanceView), "UpdateButtons")]
    internal class NewSurveillanceViewUpdateButtonsPatch
    {
        static bool Prefix(NewSurveillanceView __instance, ref bool instant)
        {
            Logger.Log($"UpdateButtons instant for {__instance.name}");
            instant = true;
            return true;
        }
    }
}
