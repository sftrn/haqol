//using HarmonyLib;
//using Loggerns;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UI.ScriptedAnimators;
//using static UI.Common.Lists.ItemView.AgentForSecretCardItemView;

//namespace HollywoodAnimalQOL2.Patches
//{
//    [HarmonyPatch(typeof(FillTweenAnimator), "Play")]
//    internal class FillTweenAnimatorPlayPatch
//    {
//        static void Prefix(FillTweenAnimator __instance, ref float ___duration)
//        {
//            Logger.Log("FillTweenAnimatorPlayPatch prfix");
//            __instance.AnimationDuration = Enums.AnimationDurations.Short;
//            ___duration = 0.1f;
//        }
//    }
//}
