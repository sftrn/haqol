using GameEvents;
using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.ScriptedAnimators;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
    [HarmonyPatch(typeof(GameEventProcessor), "GetNextLineBatchGenerator")]
    internal class GameEventProcessorGetNextLineBatchGeneratorPatch
    {
        static void Prefix()
        {
            Logger.Log("GameEventProcessorGetNextLineBatchGeneratorPatch");
        }
        static void Postfix(IEnumerable<EventLineWrapper>  __result)
        {
            //var resCopy = __result.ToList();
            //foreach (var item in resCopy)
            //{
            //    Logger.Log($"next line: {item.lineNumber} {item.localizationPackageID}");
            //}

            Logger.Log("GameEventProcessorGetNextLineBatchGeneratorPatch end");
        }
    }
#endif
}
