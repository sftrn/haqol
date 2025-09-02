//using HarmonyLib;
//using Loggerns;
//using Managers;
//using Modes;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TuturialData;

//namespace HollywoodAnimalQOL2.Patches
//{
    

//    //[HarmonyPatch(typeof(ModeManager), "StartMode", new Type[] { typeof(ModeConfig) })]
//    internal class ModeManagerInitializePatch
//    {
//        static void Postfix(ModeManager __instance, SaveManager ___saveManager)
//        {
//            Logger.Log("Got modemanager");
//            HelperObject.SaveManager = ___saveManager;
//        }
//    }
//}
