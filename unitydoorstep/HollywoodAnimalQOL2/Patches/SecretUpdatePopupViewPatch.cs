using HarmonyLib;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views;
using static UI.Views.SecretUpdatePopupView;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(SecretUpdatePopupView), "PlayAnimation")]
    internal class SecretUpdatePopupViewPlayAnimationPatch
    {
        static bool Prefix(ref float ___animationDelay)
        {
            Logger.Log("PlayAnimation prefix");
            ___animationDelay = 0.1f;
            return true;
        }
    }
    /// <summary>
    /// Here because this class located in SecretUpdatePopupView.cs
    /// </summary>
    [HarmonyPatch(typeof(LeakedAnimation), "Animate")]
    internal class SecretUpdatePopupViewAnimatePatch
    {
        static bool Prefix(ref float delay)
        {
            Logger.Log("Animate prefix");
            delay = 0.1f;
            return true;
        }
    }
    /// <summary>
    /// Here because this class located in SecretUpdatePopupView.cs
    /// </summary>
    [HarmonyPatch(typeof(Buttons), "SetInteractable")]
    internal class SecretUpdatePopupViewSetInteractablePatch
    {
        static bool Prefix(bool interactable, ref bool instant,ref float delay)
        {
            //Logger.Log("SetInteractable prefix");
            //instant = true;
            delay = 0.1f;
            return true;
        }
    }
}
