using HarmonyLib;
using Loggerns;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Common;
using UI.Common.Lists.ItemView;
using UI.Views.MovieEditor;

namespace HollywoodAnimalQOL2
{
    //[HarmonyPatch(typeof(QualitySelectionPanel), "Start")]
    public class QualitySelectionPanelPatch
    {
        public static void InitPrivateMethods()
        {

        }
        static void Postfix(QualitySelectionPanel __instance, DataManager ___dataManager)
        {
            //Logger.Log($"Quality started {___dataManager.MovieTitlesCache}");
            //__instance.EvOptionIndexSelected.Fire();// (__instance.LockedFromOption);

            //Logger.Log("Max stars selected");
        }
    }
}
