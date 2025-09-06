using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using static UI.Common.Lists.ItemView.AgentForSecretCardItemView;

namespace HollywoodAnimalQOL2.Patches
{
#if DEBUG
        [HarmonyPatch(typeof(ItemSelectorBase), "Animations")]
        internal class ItemSelectorBaseAnimationsPatch
    {
            static void Prefix()
            {
                Logger.Log("ItemSelectorBaseAnimationsPatch");
            }
        }
#endif
}
