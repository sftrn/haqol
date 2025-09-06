using Data.GameObject;
using Enums;
using HarmonyLib;
using Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Conditions;
using static UI.Views.SecretUpdatePopupView;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(SecretManager), "AddNewSecret")]
    internal class SecretManagerAddNewSecretPatch
    {
        static void Prefix(SecretManager __instance, string secretId,
    int riskLevel,
    Dictionary<ConditionContextType, ConditionContextSerializable> context,
    string uniqueId = null)
        {
            Loggerns.Logger.Log($"New secret added: {secretId}");
        }
    }
    [HarmonyPatch(typeof(SecretManager), "ActivateSecret")]
    internal class SecretManagerActivateSecretPatch
    {
        static void Prefix(SecretDataWrapper secret, ref bool noEvent)
        {
            HelperObject.ModeManager.UpdateState(Functionalities.Secrets, true);
            HelperObject.ModeManager.EvFunctionalityChange.Fire((Functionalities.Secrets, true));
            //HelperObject.TutorialManager.CurrentActivePopup = null;
            Loggerns.Logger.Log($"ActivateSecret pass");
            noEvent = true;
        }
        static void Postfix()
        {
            var param = new GUISystemModule.GUIParams();
            param.Add(GUIParamTypes.PauseTime, true);
            HelperObject.GuiSystem.ShowView(ViewKeys.SecretsView, param);
        }
    }
}
