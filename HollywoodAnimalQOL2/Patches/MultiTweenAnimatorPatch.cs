using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ScriptedAnimators;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(MultiTweenAnimator), "OnAwake")]
    internal class MultiTweenAnimatorOnAwakePatch
    {
        static void Prefix(MultiTweenAnimator __instance)
        {
            __instance.TimeMultiplier = 10f;
        }
    }
}
