using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Loggerns;
using Managers;
using Modes;
using System.Reflection;
using System.Linq;
using GUISystemModule;
using HollywoodAnimalQOL2.Patches;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(CharactersManager), "OnProfileLoaded")]
    static class CharacterManagerPatch
    { 
        static void Postfix(CharactersManager __instance,
            ModeManager ___modeManager,
            TimeManager ___timeManager, GUIHelper ___guiHelper,
            ImageManager ___imageManager, LocalizationManager ___localizationManager)
        {
            Logger.Log("Profile loaded");
            HelperObject.CharactersManager = __instance;
            HelperObject.ModeManager = ___modeManager;
            HelperObject.ImageManager = ___imageManager;
            InternalImageManager.InitPrivateMethods(___imageManager);
        }
    }
}
