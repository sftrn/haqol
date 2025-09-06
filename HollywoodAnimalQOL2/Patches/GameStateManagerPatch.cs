using Doorstop;
using HarmonyLib;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(GameStateManager), nameof(GameStateManager.ShowDisclaimer), MethodType.Getter)]
    [HarmonyPatchCategory("beforeGameLoad")]
    internal class GameStateManagerPatch
    {
        static bool Prefix(ref bool __result)
        {
            Logger.Log("Bypassing disclaimer");
            __result = false;
            return false;
        }
        static void Postfix()
        {
            Entrypoint.harmony.PatchAllUncategorized();
            Logger.Log("Patching completed");
        }
    }
}
