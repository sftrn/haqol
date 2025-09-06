using HarmonyLib;
using Loggerns;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(BlockerTint), "OnGuiShown")]
    internal class BlockerTintOnGuiShownPatch
    {
        static void Prefix()
        {
            Logger.Log("BlockerTintOnGuiShownPatch");
        }
    }
#endif
}
