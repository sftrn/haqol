using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.SubPanels;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(NewSecretPanel), "StartPresentationAnimationOnSecretItemView")]
    internal class NewSecretPanelPatch
    {
        static void Prefix(NewSecretPanel __instance)
        {
            Logger.Log($"StartPresentationAnimationOnSecretItemView inst: {__instance.name}");
            var test = __instance.enabled;

            //__instance.
        }
    }
#endif
}
