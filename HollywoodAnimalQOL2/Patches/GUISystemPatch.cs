using Enums;
using GUISystemModule;
using HarmonyLib;
using Loggerns;
using Model;
using Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Lists.ItemView;
using static GUISystemModule.GUISystem;

namespace HollywoodAnimalQOL2.Patches
{

    //[HarmonyPatch(typeof(Blurs), "TryPushNewView")]
    //internal class BlursTryPushNewViewPatch
    //{
    //    static void Prefix(Blurs __instance)
    //    {
    //        Logger.Log("BlursTryPushNewViewPatch prefix");
    //        //__instance.an
    //    }

    //}
    //[HarmonyPatch(typeof(Blurs), "PopupBlurAnimation")]
    //internal class BlursPopupBlurAnimationPatch
    //{
    //    static void Prefix()
    //    {
    //        Logger.Log("BlursPopupBlurAnimationPatch prefix");
    //    }

    //}
    [HarmonyPatch(typeof(Blurs), "PlayBlursTransition")]
    internal class BlursPlayBlursTransitionPatch
    {
        static void Prefix()
        {
            Logger.Log("BlursPlayBlursTransitionPatch prefix");
        }

    }
    [HarmonyPatch(typeof(GUISystem), "HideView")]
    internal class GUISystemHideViewPatch
    {
        static MethodInfo CheckAreAllViewsHidden;
        static MethodInfo OnHideAnimationFinished;
        static MethodInfo OnGuiShowAnimFinished;
        static MethodInfo OnShowStart;
        static MethodInfo BlockWindow;
        static MethodInfo SetPixelPerfectActive;
        static FieldInfo animations;
        public static void InitPrivateMethods()
        {
            CheckAreAllViewsHidden =
                typeof(GUISystem).GetMethod("CheckAreAllViewsHidden",
                BindingFlags.NonPublic | BindingFlags.Instance);
            OnHideAnimationFinished =
                typeof(GUIBaseView).GetMethod("OnHideAnimationFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            OnGuiShowAnimFinished =
                typeof(GUIBaseView).GetMethod("OnGuiShowAnimFinished",
                BindingFlags.NonPublic | BindingFlags.Instance);
            OnShowStart =
                typeof(GUIBaseView).GetMethod("OnShowStart",
                BindingFlags.NonPublic | BindingFlags.Instance);
            BlockWindow =
                typeof(GUIBaseView).GetMethod("BlockWindow",
                BindingFlags.NonPublic | BindingFlags.Instance);
            SetPixelPerfectActive =
                typeof(GUIBaseView).GetMethod("SetPixelPerfectActive",
                BindingFlags.NonPublic | BindingFlags.Instance);
            animations =
                typeof(GUIBaseView).GetField("animations", BindingFlags.NonPublic | BindingFlags.Instance);
        }
        //    static void Prefix(GUISystem __instance, ViewKeys viewId, ref GUIParams param, ref Dictionary<ViewKeys, GUIBaseView> ___views)
        //    {
        //        if (param == null)
        //            return;
        //        var paramCopy = param;
        //        var viewIdCopy = viewId;
        //        var viewsCopy = ___views;
        //        if (param.Remove(GUIParamTypes.WithAnimation))
        //        {
        //            Logger.Log($"HideView Removed WithAnimation from {viewIdCopy}");
        //            HelperMethods.CallNextLateUpdate(() =>
        //            {
        //                Logger.Log($"Late update called for {viewIdCopy}");
        //                var data = new GUIEvent(viewIdCopy, paramCopy);

        //                __instance.EvViewHidden.Fire(data);
        //                __instance.EvViewHideAnimationFinished.Fire(viewIdCopy);
        //                __instance.EvViewHiddenAfterBlurCheck.Fire(data);
        //                CheckAreAllViewsHidden.Invoke(__instance, null);
        //                GUIBaseView view = viewsCopy[viewId];
        //                view.OnStartCustomHide(new Action((Action)Delegate.CreateDelegate(typeof(Action), view, OnHideAnimationFinished)), paramCopy);

        //                //view.OnHideStart();
        //                //view.animations.HideWindow(new Action(this.OnHideAnimationFinished));
        //                //__instance.evviewh.Fire(viewId);
        //            });
        //            //HelperObject.Instance.CallNextFrame(() =>
        //            //{
        //            //});
        //        }
        //    }
        //}
        //[HarmonyPatch(typeof(GUISystem), methodName: "MoveViewToTop")]
        //internal class GUISystemMoveViewToTopPatch
        //{
        //    static void Prefix()
        //    {
        //        Logger.Log("GUISystemMoveViewToTopPatch");
        //    }
        //}
        [HarmonyPatch(typeof(GUISystem), methodName: "ShowView")]
        internal class GUISystemShowViewPatch
        {
            static bool Prefix(GUISystem __instance, ViewKeys viewId, ref GUIParams param,
                ref Dictionary<ViewKeys, GUIBaseView> ___views)
            {
                
                Logger.Log($"GUISystemShowViewPatch {viewId}");
                //if (viewId == ViewKeys.NewThingSmallPopupView)
                //{
                //    __instance.HideView(viewId, param);
                //    __instance.ShowView(ViewKeys.SecretsView);
                //    return false;
                //}
                //if (param == null)
                //{
                //    Logger.Log($"ShowView param null returning {viewId}");
                //    return true;
                //}
                //var paramCopy = param;
                //GUIBaseView view = ___views[viewId];
                //if (param.ContainsKey(GUIParamTypes.WithAnimation))
                //{
                //    GUIBaseViewAnimations animationsInstance = animations.GetValue(view) as GUIBaseViewAnimations;
                //    if (animationsInstance != null)
                //    {
                //        animationsInstance.AnimationSpeedUp = 10f;
                //    }
                //}
                return true;
            }
            static void Postfix()
            {
                Logger.Log($"GUISystemShowViewPatch end");
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "AddToQueue")]
        internal class GUISystemAddToQueuePatch
        {
            static bool Prefix(GUISystem __instance, UIQueuePriority priority, ViewKeys viewKey, GUIParams param = null)
            {

                //Logger.Log($"GUISystemAddToQueuePatch {viewKey}");
                //if (viewKey == ViewKeys.NewThingSmallPopupView)
                //{
                //    //__instance.HideView(viewId, param);
                //    __instance.ShowView(ViewKeys.SecretsView);
                //    return false;
                //}
                return true;
            }
            static void Postfix(GUISystem __instance, UIQueuePriority priority, ViewKeys viewKey, GUIParams param = null)
            {
                Logger.Log($"GUISystemAddToQueuePatch {viewKey} end");
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "Construct")]
        internal class GUISystemConstructPatch
        {
            static void Prefix(GUISystem __instance, ModeManager modeManager)
            {

                Logger.Log($"GUISystemConstructPatch");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "ShowTutorialPopup")]
        internal class GUISystemShowTutorialPopuptPatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemShowTutorialPopuptPatch");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "TryToLoadView")]
        internal class GUISystemTryToLoadViewPatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemTryToLoadViewPatch");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "DisableTopView")]
        internal class GUISystemDisableTopViewPatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemDisableTopViewPatch");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(GUISystem __instance)
            {

                Logger.Log($"GUISystemDisableTopViewPatch end");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "MoveTopAndCheckForBlur")]
        internal class GUISystemMoveTopAndCheckForBlurPatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemMoveTopAndCheckForBlurPatch");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(GUISystem __instance)
            {

                Logger.Log($"GUISystemMoveTopAndCheckForBlurPatch end");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "UpdateTopBarElements")]
        internal class GUISystemUpdateTopBarElementsPatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemUpdateTopBarElementsPatch");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(GUISystem __instance)
            {

                Logger.Log($"GUISystemUpdateTopBarElementsPatch end");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "MoveViewToTop")]
        internal class GUISystemMoveViewToTopPatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemMoveViewToTopPatch");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(GUISystem __instance)
            {

                Logger.Log($"GUISystemMoveViewToTopPatch end");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(Layers), methodName: "MoveViewToTopInLayer")]
        internal class LayersMoveViewToTopInLayerPatch
        {
            static void Prefix(Layers __instance)
            {

                Logger.Log($"LayersMoveViewToTopInLayerPatch");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(Layers __instance)
            {

                Logger.Log($"LayersMoveViewToTopInLayerPatch end");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(Layers), methodName: "TryRemoveViewFromLayer")]
        internal class LayersTryRemoveViewFromLayerPatch
        {
            static void Prefix(Layers __instance, GUIBaseView view)
            {

                Logger.Log($"LayersTryRemoveViewFromLayerPatch {view.name}");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(Layers __instance, GUIBaseView view)
            {

                Logger.Log($"LayersTryRemoveViewFromLayerPatch {view.name} end");
                //HelperObject.ModeManager = modeManager;
            }
        }
        [HarmonyPatch(typeof(GUISystem), methodName: "SetPopupCanvasActive")]
        internal class GUISystemSetPopupCanvasActivePatch
        {
            static void Prefix(GUISystem __instance)
            {

                Logger.Log($"GUISystemSetPopupCanvasActivePatch");
                //HelperObject.ModeManager = modeManager;
            }
            static void Postfix(GUISystem __instance)
            {

                Logger.Log($"GUISystemSetPopupCanvasActivePatch end");
                //HelperObject.ModeManager = modeManager;
            }
        }
    }
}
