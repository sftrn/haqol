using GUISystemModule;
using HarmonyLib;
using Loggerns;
using Managers;
using Model;
using Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(AppController), "StartGame")]
    internal class AppControllerPatch
    {
        static void Postfix(AppController __instance, ref SaveManager ___saveManager,
             ref TimeManager ___timeManager, ref GUIHelper ___guiHelper, ref  GUISystem ___guiSystem)
        {
            Logger.Log("Game started");
            HelperObject.GameLoaded = true;
            HelperObject.SaveManager = ___saveManager;
            HelperObject.TimeManager = ___timeManager;
            HelperObject.GuiHelper = ___guiHelper;
            HelperObject.GuiSystem = ___guiSystem;
            HelperObject.AppController = __instance;
        }
    }


}
