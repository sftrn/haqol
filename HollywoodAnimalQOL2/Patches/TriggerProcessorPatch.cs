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
using Utils.Conditions;

namespace HollywoodAnimalQOL2.Patches
{

    [HarmonyPatch(typeof(TriggerProcessor), "ApplyTriggersInner")]
    internal class TriggerProcessorApplyTriggersInnerPatch
    {
        static void Prefix(ModeTaskWrapper __instance, IEnumerable<LineTrigger> triggers,
    Dictionary<ConditionContextType, ConditionContextSerializable> context,
    int currentLine,
    TriggerProcessor.TriggersOutputData output,
    string associatedImageId,
    EventContextType contextType)
        {
#if DEBUG
            Logger.Log($"TriggerProcessorApplyTriggersInnerPatch patch {output?.requestedNextEventCountdown} {contextType}");
#endif
            foreach (var item in triggers)
            {
                Logger.Log($"trigger type: {item.triggerType} {item.value} {contextType}");

            }
        }
        static void Postfix()
        {
#if DEBUG
            Logger.Log("TriggerProcessorApplyTriggersInnerPatch end");
#endif
        }
    }
}
