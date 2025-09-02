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
    internal class GUIBaseViewAnimationsPatch
    {
        static bool Prefix(GUIBaseViewAnimations __instance, ref float __result)
        {
            //Logger.Log($"Speedup anim {__instance.name}");
            //__result = 100f;
            return false;
        }
    }
}
