using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using UI.ScriptedAnimators;
using static UI.Common.Lists.ItemView.AgentForSecretCardItemView;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(GaugeBar), "SetGaugeShape")]
    internal class GaugeBarSetGaugeShapePatch
    {
        static void Prefix(GaugeBar __instance, float value, bool animated, ScriptedAnimatorBase ___gaugeAnimator)
        {
            Logger.Log($"GaugeBarSetGaugeShapePatch value: {value} anim: {animated}");
            if (___gaugeAnimator != null)
            {
                //___gaugeAnimator.TimeMultiplier = 10f;
            //___gaugeAnimator.AnimationDuration = Enums.AnimationDurations.Short;
            }
        }
    }
#endif
#if DEBUG
    [HarmonyPatch(typeof(GaugeBar), "SetValue", new Type[] {typeof(float), typeof(bool)})]
    internal class GaugeBarSetValuePatch
    {
        static void Prefix(GaugeBar __instance, float value, ref bool animated)
        {
            Logger.Log($"GaugeBarSetValuePatch end");
            //animated = false;
        }
    }
#endif
}
