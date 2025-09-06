using GUISystemModule;
using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodAnimalQOL2.Patches
{

#if DEBUG
    [HarmonyPatch(typeof(GUIHelper), "ShowOffSecret")]
    internal class GUIHelperShowOffSecretPatch
    {
        static void Prefix(GUIHelper __instance)
        {
            //__instance.
            Logger.Log("GUIHelperShowOffSecretPatch");
            //__instance.AddSecretsViewToInstantQueue
        }
    }
#endif
}
