//using HarmonyLib;
//using Loggerns;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UI.Common.Animations;

//namespace HollywoodAnimalQOL2.Patches
//{
//    [HarmonyPatch(typeof(ShineMaterialAnimation), "StartAnimation")]
//    internal class ShineMaterialAnimationStartAnimationPatch
//    {
//        static void Prefix(ShineMaterialAnimation __instance,ref float ___startDelay,ref float ___delay, ref float ___duration)
//        {
//            Logger.Log("ShineMaterialAnimationStartAnimationPatch");
//            ___startDelay = 0f;
//            ___delay = 0f;
//            ___duration = 0.1f;
//            //__instance.
//        }
//    }
//}
