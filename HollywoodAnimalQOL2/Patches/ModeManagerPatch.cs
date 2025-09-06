using Enums;
using GameEvents;
using HarmonyLib;
using Loggerns;
using Managers;
using Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuturialData;

namespace HollywoodAnimalQOL2.Patches
{


    [HarmonyPatch(typeof(ModeManager), "Initialize")]
    internal class ModeManagerInitializePatch
    {
        static void Postfix(ModeManager __instance)
        {
            //Logger.Log("Got modemanager");
            //HelperObject.ModeManager = __instance;
        }
    }
    [HarmonyPatch(typeof(ModeManager), "StartSubStep")]
    internal class ModeManagerStartSubStepPatch
    {
        static void Prefix(ModeManager __instance, SubStepConfig subStep, bool reverted = false)
        {
            Logger.Log($"ModeManagerStartSubStepPatch prefix {subStep.Params.DelayByDays}" +
                $"{subStep.Params.Delay}");
        }
    }
    [HarmonyPatch(typeof(ModeManager), "AddPlannedAction", new Type[]
    {typeof(PlannedActions), typeof(DateTime), typeof(string) })]
    internal class ModeManagerAddPlannedActionPatch
    {
        static void Prefix(ModeManager __instance, PlannedActions type, DateTime applyDate, string value)
        {
            Logger.Log($"ModeManagerAddPlannedActionPatch prefix {type} {applyDate}, {value}");
        }
    }
    [HarmonyPatch(typeof(ModeManager), "AddPlannedAction", new Type[]
    {typeof(LineTrigger), typeof(DateTime) })]
    internal class ModeManagerAddPlannedAction2Patch
    {
        static void Prefix(ModeManager __instance, LineTrigger trigger, DateTime applyDate)
        {
            Logger.Log($"ModeManagerAddPlannedActionPatch prefix {trigger.name} {applyDate}");
        }
    }
    [HarmonyPatch(typeof(ModeManager), "WaitFor", new Type[]
    {typeof(Action), typeof(string[]) })]
    internal class ModeManagerWaitForPatch
    {
        static void Prefix(ModeManager __instance, Action callback, string[] param)
        {
            foreach (var item in param)
            {
                Logger.Log($"ModeManagerWaitForPatch {item}");
            }
        }
    }
}
