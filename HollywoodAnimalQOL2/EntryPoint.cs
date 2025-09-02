using HarmonyLib;
using HollywoodAnimalQOL2;
using Loggerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorstop
{
    class Entrypoint
    {
        public static Harmony harmony;
        public static void Start()
        {
            Logger.Init("haqol", false);
            try
            {
                PreproductionEditorViewPatch.InitPrivateMethods();
                LocationTypeItemViewPatch.InitPrivateMethods();
                QualitySelectionPanelPatch.InitPrivateMethods();
                harmony = new Harmony("com.qwerty.qol.hollywoodanimal");
                Harmony.DEBUG = true;
                harmony.PatchCategory("beforeGameLoad");
                Logger.Log("Harmony init complete");
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }
        
    }

}

