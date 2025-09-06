using GUISystemModule;
using HarmonyLib;
using Loggerns;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI.Common.Animations;
using UI.Views;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(NewThingSmallPopupView), "InitComponents")]
    internal class NewThingSmallPopupViewInitComponentsPatch
    {
        static FieldInfo animations;
        static void Prefix(NewThingSmallPopupView __instance,
            ref LoadableAnimatorsAwaiter ___smokeAnimAwaiter)
        {
            animations =
                typeof(GUIBaseView).GetField("animations", BindingFlags.NonPublic | BindingFlags.Instance);
            Logger.Log("NewThingSmallPopupView prefix");
            GUIBaseViewAnimations animationsInstance = animations.GetValue(__instance) as GUIBaseViewAnimations;
            //= getter.Invoke(view, null) as GUIBaseViewAnimations;
            if (animationsInstance != null)
            {
                animationsInstance.AnimationSpeedUp = 10f;
                //animationsInstance.
            }
         
            //__instance.
        }
    }
    [HarmonyPatch(typeof(NewThingSmallPopupView), "OnStartCustomShow")]
    internal class NewThingSmallPopupViewOnStartCustomShowPatch
    {
        static FieldInfo animations;
        static void Prefix(NewThingSmallPopupView __instance,
            ref LoadableAnimatorsAwaiter ___smokeAnimAwaiter)
        {
            Logger.Log($"NewThingSmallPopupViewOnStartCustomShowPatch prefix {__instance}");
            animations =
                typeof(GUIBaseView).GetField("animations", BindingFlags.NonPublic | BindingFlags.Instance);
            GUIBaseViewAnimations animationsInstance = animations.GetValue(__instance) as GUIBaseViewAnimations;
            //= getter.Invoke(view, null) as GUIBaseViewAnimations;
            if (animationsInstance != null)
            {
                
                animationsInstance.AnimationSpeedUp = 10f;
                //animationsInstance.
            }

            //__instance.
        }
    }
}
