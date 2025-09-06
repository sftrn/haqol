using HarmonyLib;
using Loggerns;
using PP.OptimizedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Animations;
using UI.ScriptedAnimators;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(ItemView), "InitView",
        new Type[] { typeof(ItemContainerData), typeof(Transform) })]
    internal class ItemViewInitViewPatch
    {
        static void Prefix(ItemView __instance, ScriptedAnimatorBase ___showAnimator)
        {
            Logger.Log($"ItemViewInitViewPatch called from {__instance.name}");
            //___showAnimator.TimeMultiplier = 10f;
            //___showAnimator.SpeedMultiplier = 0.001f;
            //___showAnimator.AnimationDuration = Enums.AnimationDurations.Short;
        }
    }
}
