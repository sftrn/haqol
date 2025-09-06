using HarmonyLib;
using Model;
using Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Views.Tutorial;

namespace HollywoodAnimalQOL2.Patches
{
    [HarmonyPatch(typeof(ViewController), "Initialize")]
    internal class ViewControllerPatch
    {
        static void Postfix(ModeManager ___modeManager)
        {
            //HelperObject.ModeManager = ___modeManager;
        }
    }
}
