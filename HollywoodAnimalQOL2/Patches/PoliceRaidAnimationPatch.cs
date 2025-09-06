using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using UI.Views;
using UnityEngine;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(PoliceRaidAnimation), "PlayStart")]
    internal class PoliceRaidAnimationPlayStartPatch
    {
        static void Prefix(PoliceRaidAnimation __instance, Action onFinished)
        {
            Loggerns.Logger.Log("PoliceRaidAnimationPlayStartPatch patch");
            //duration = 0.1f;
        }
    }
}
