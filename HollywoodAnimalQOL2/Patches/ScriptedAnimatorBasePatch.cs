//using HarmonyLib;
//using Loggerns;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UI.ScriptedAnimators;
//using UI.Views.MovieEditor;

//namespace HollywoodAnimalQOL2.Patches
//{
//    [HarmonyPatch(typeof(ScriptedAnimatorBase), "Play", new Type[] { typeof(bool) })]
//    internal class ScriptedAnimatorBasePlayPatch
//    {
//        static HashSet<string> bannedAnimations = new HashSet<string>()
//        {
//            "ZRotationTweenAnimator",
//            "FadeTweenAnimator"
//        };
//        static void Prefix(ScriptedAnimatorBase __instance)
//        {
//            var typeName = __instance.GetType().Name;
//            if (!bannedAnimations.Contains(typeName))
//            {
//                Logger.Log($"{typeName} called play");
//                __instance.TimeMultiplier = 10f;
//                __instance.AnimationDuration = Enums.AnimationDurations.Short;
//            }
//        }
//    }
//}
