using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Lists.ItemView;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(HelperMethods), "CallWithDelayUnscaled", new Type[] { typeof(Action), typeof(float) })]
    internal class HelperMethodsCallWithDelayUnscaledPatch
    {
        static bool Prefix(Action action, ref float delay)
        {
            //Logger.Log("CallWithDelayUnscaled prefix");

            delay = 0.1f;
            return true;
        }
    }
    //[HarmonyPatch(typeof(HelperMethods), "CallWithFrameDelay", new Type[] { typeof(Action), typeof(int) })]
    //internal class HelperMethodsCallWithFrameDelayPatch
    //{
    //    static bool Prefix(Action action,ref int frames)
    //    {
    //        //Logger.Log("CallWithFrameDelay prefix");
    //        frames = 0;
    //        return true;
    //    }
    //}
}
