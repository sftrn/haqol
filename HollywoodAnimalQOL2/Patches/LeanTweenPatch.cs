//using HarmonyLib;
//using Loggerns;
//using PP.OptimizedList;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;
//using Logger = Loggerns.Logger;

//namespace HollywoodAnimalQOL2.Patches
//{
//    [HarmonyPatch(typeof(LeanTween), "pushNewTween"
//        //,new Type[] { typeof(ItemContainerData), typeof(Transform) }
//        )]
//    internal class LeanTweenPatch
//    {
//        static HashSet<string> leenBlacklist = new HashSet<string>()
//        {
//            "TintBg",
//            "MapUI"
//        };
//        static void Prefix(GameObject gameObject, Vector3 to,ref float time, LTDescr tween)
//        {
//            if (!leenBlacklist.Contains(gameObject.name))
//            {
//                //time = 0.1f;
//                Logger.Log($"New tween started: {gameObject.name} {tween.type} time: {time}" +
//                    $" callback: {tween._optional?.onComplete?.Target} " +
//                    $"type: {tween.loopType}");
//            }
//        }
//    }
//}
