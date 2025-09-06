using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using UI.Common.Animations;
using Loggerns;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2.Patches
{

    [HarmonyPatch(typeof(ParallaxImage), "PlayZoomInAnimation")]
    internal class ParallaxImagePlayZoomInAnimationPatch
    {
        static void Prefix(ParallaxImage __instance, float toZoomIn, ref float duration, AnimationCurve curve)
        {
            Logger.Log($"ParallaxImagePlayZoomInAnimationPatch duration: {duration}");
            duration = 0.1f;
        }
    }
}
