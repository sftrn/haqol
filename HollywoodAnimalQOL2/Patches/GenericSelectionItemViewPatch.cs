using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using UI.Common.Lists.ItemView;

namespace HollywoodAnimalQOL2.Patches
{

#if DEBUG
    [HarmonyPatch(typeof(GenericSelectionItemView), "OnInit")]
    internal class GenericSelectionItemViewOnInitPatch
    {
        static void Prefix()
        {
            Logger.Log("GenericSelectionItemViewOnInitPatch");
        }
    }
#endif
}
