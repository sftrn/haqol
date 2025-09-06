using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using UI.Common.Animations;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(LoadableAnimatorsAwaiter), "LoadAndWaitFor")]
    internal class LoadableAnimatorsAwaiterLoadAndWaitForPatch
    {
        static bool Prefix(LoadableAnimatorsAwaiter __instance, ref Action callback)
        {
            //callback();
            //return false;
            return true;
        }
    }
#endif
}
