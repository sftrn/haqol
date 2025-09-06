using HarmonyLib;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UI.Common.Lists.ItemView.AgentForSecretCardItemView;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(NextIterationAnimation), "Play")]
    internal class NextIterationAnimationPlayPatch
    {
        static void Prefix()
        {
            Logger.Log("NextIterationAnimationPlayPatch");
        }
    }
}
