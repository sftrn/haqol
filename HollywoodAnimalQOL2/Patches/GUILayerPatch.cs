using GUISystemModule;
using HarmonyLib;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GUISystemModule.GUISystem;

namespace HollywoodAnimalQOL2
{

#if DEBUG
    [HarmonyPatch(typeof(GUILayer), "AddViewToTop")]
    internal class GUILayerAddViewToTopPatch
    {
        static void Prefix()
        {
            Logger.Log("GUILayerAddViewToTopPatch");
        }
        static void Postfix()
        {
            Logger.Log("GUILayerAddViewToTopPatch end");
        }
    }
    [HarmonyPatch(typeof(GUILayer), "ValidateView")]
    internal class GUILayerValidateViewPatch
    {
        static void Postfix()
        {
            Logger.Log("GUILayerValidateViewPatch end");
        }
        static void Prefix()
        {
            Logger.Log("GUILayerValidateViewPatch");
        }
    }
    [HarmonyPatch(typeof(GUILayer), "RefreshSortingOrder")]
    internal class GUILayerRefreshSortingOrderPatch
    {
        static void Prefix(GUILayer __instance, GUIBaseView targetView,
    ref List<GUIBaseView> views,
    int midSortingOrder,
    bool isNewTop)
        {
            Logger.Log("GUILayerRefreshSortingOrderPatch");

        }
        static void Postfix()
        {
            Logger.Log("GUILayerRefreshSortingOrderPatch end");
        }
    }

    [HarmonyPatch(typeof(GUILayer), methodName: "AddViewToBottom")]
    internal class GUILayerAddViewToBottomPatch
    {
        static void Prefix(GUILayer __instance, GUIBaseView view)
        {

            Logger.Log($"LayersAddViewToBottomPatch {view.name}");
            //HelperObject.ModeManager = modeManager;
        }
        static void Postfix(GUILayer __instance, GUIBaseView view)
        {

            Logger.Log($"LayersAddViewToBottomPatch {view.name} end");
            //HelperObject.ModeManager = modeManager;
        }
    }
#endif
}
