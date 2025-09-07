using Enums;
using GUISystemModule;
using Managers;
using Model;
using Modes;
using System;

using System.Collections;
using System.Reflection;
using System.Xml.Linq;
using UI.Common.Lists.ItemView;
using UI.Views.MovieEditor;
using UnityEngine;
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2
{
    internal class HelperObject : UnityEngine.MonoBehaviour
    {
        public static HelperObject Instance;
        public static bool GameLoaded {  get; set; }
        public static SaveManager SaveManager { get; set; }
        public static CharactersManager CharactersManager { get; set; }
        public static TimeManager TimeManager { get; set; }
        public static GUIHelper GuiHelper { get; set; }
        public static GUISystem GuiSystem { get; set; }
        public static ModeManager ModeManager { get; set; }
        public static AppController AppController { get; internal set; }
        public static TutorialManager TutorialManager { get; internal set; }

        private void Start()
        {
            Logger.Log("Helper object started");
            Instance = this;
            InitPrivateMethods();
            DebugModes.Logs.GUI = true;
            DebugModes.Logs.CHARACTERS = true;
            DebugModes.Logs.SECRETS = true;
            DebugModes.Logs.SAVES = true;
            DebugModes.Logs.TASKS = true;
            DebugModes.Logs.SCRIPT_GENERATION = true;
            DebugModes.Logs.STAFF_INFO = true;
            DebugModes.Logs.ANIMATIONS = true;
            DebugModes.Logs.ASSETS = true;
            DebugModes.Logs.RELEASE = true;
            DebugModes.Logs.TITANS = true;
        }
        //static MethodInfo TryAutoSaveMethod;
        //static MethodInfo SaveGameMethod;

        public static void InitPrivateMethods()
        {
            //SaveGameMethod =
            //    typeof(SaveManager).GetMethod("SaveGame",
            //    BindingFlags.NonPublic | BindingFlags.Instance);
            //TryAutoSaveMethod =
            //    typeof(SaveManager).GetMethod("TryAutoSave",
            //    BindingFlags.NonPublic | BindingFlags.Instance);
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.F5) &&
                !GuiSystem.IsMainMenu &&
                GameLoaded && SaveManager != null &&
                GuiSystem.IsAllHidden && !GuiSystem.PausedByGUI)
            {
                var currentTime = TimeManager.CurrentTime;
                SaveManager.RequestSaveGame($"QOL_Quicksave {currentTime.Day:D2} {currentTime.Month:D2} {currentTime.Year}");
            }

        }
        public void CallNextFrame(Action action)
        {
            Logger.Log($"Creating coroutine for action");
            StartCoroutine(CoroutineCallNextFrame(action));
        }
        private IEnumerator CoroutineCallNextFrame(Action action)
        {
            yield return null;
            if (action != null)
                action();
        }
    }
}
