using GUISystemModule;
using HarmonyLib;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Loggerns;
using Logger = Loggerns.Logger;
namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(GUIBaseViewAnimations), nameof(GUIBaseViewAnimations.AnimationSpeedUp), MethodType.Getter)]
    internal class GUIBaseViewAnimationsAnimationSpeedUpPatch
    {
        static bool Prefix(GUIBaseViewAnimations __instance, ref float __result)
        {
            if(__instance != null)
                Logger.Log($"GUIBaseViewAnimationSpeedUpPatch Speedup anim {__instance.name}");
            __result = 10f;
            return true;
        }
    }

#if DEBUG
    [HarmonyPatch(typeof(GUIBaseViewAnimations), "ShowWindow")]
    internal class GUIBaseViewAnimationsShowWindowPatch
    {
        static bool Prefix(GUIBaseViewAnimations __instance)
        {
            if (__instance != null)
                Logger.Log($"GUIBaseViewAnimationsShowWindowPatch Speedup anim {__instance.name}");
            //__instance.NeedToPlayAnimation = false;
            return true;
        }
    }
    [HarmonyPatch(typeof(GUIBaseViewAnimations), "OnAnimationFinished")]
    internal class GUIBaseViewAnimationsOnAnimationFinishedPatch
    {
        static bool Prefix(GUIBaseViewAnimations __instance, Action ___onShownCallback)
        {
            if (__instance != null)
                Logger.Log($"GUIBaseViewAnimationsOnAnimationFinishedPatch Speedup anim {__instance.name} {___onShownCallback}");
            return true;
        }
    }
#endif
}
