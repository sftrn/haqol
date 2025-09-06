using Data.GameObject.Modes;
using Enums;
using GameEvents;
using HarmonyLib;
using Loggerns;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Animations;
using Utils.Conditions;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(ModeTaskWrapper), "RegisterTask")]
    internal class ModeTaskWrapperRegisterTaskPatch
    {
        static void Prefix(ModeTaskWrapper __instance)
        {
            Logger.Log($"ModeTaskWrapperRegisterTaskPatch patch");
        }
    }
#endif
}
