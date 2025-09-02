using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common.SubPanels;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(SimpleSubPanel), "ShowLogic"
        //, new Type[] { typeof(bool) }
        )]
    internal class SimpleSubPanelPatch
    {
        static bool Prefix(SimpleSubPanel __instance)
        {
            //Temporary workaround 
            //if (__instance.GetType().Name != "AssociationVotedProposalDisplay")
            //{
            //Because EvPanelShown event added after Show() called
            //HelperObject.Instance.CallNextFrame(() =>
            //{
            //    Logger.Log($"Bypassing Show() panel and call ShowInstantly() instead for {__instance.IDText}");
            //    if(__instance != null && __instance.isActiveAndEnabled)
            //        __instance.ShowInstantly();
            //});
            //return false;
            //}
            //else
            return true;
        }
    }
}
