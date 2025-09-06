using HarmonyLib;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(Debug), "Log", new Type[] { typeof(object), typeof(Object) })]
    internal class DebugLogStringPlusObjectPatch
    {
        static void Prefix(ref object message, ref Object context)
        {
            var refindedString = Loggerns.Logger.FormatMessage(message.ToString());
            message = refindedString;
        }
    }
    [HarmonyPatch(typeof(Debug), "Log", new Type[] { typeof(object) })]
    internal class DebugLogPatch
    {
        static void Prefix(ref object message)
        {
            var refindedString = Loggerns.Logger.FormatMessage(message.ToString());
            message = refindedString;
        }
    }
}
