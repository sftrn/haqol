using Data.GameObject.Character;
using Enums;
using GUISystemModule;
using Managers;
using Model;
using Modes;
using System;

using System.Collections;
using System.Collections.Generic;
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
        public static ImageManager ImageManager { get; internal set; }
        public static LocalizationManager LocalizationManager { get;  set; }

        private void Start()
        {
            Logger.Log("Helper object started");
            Instance = this;
            InitPrivateMethods();
            for (int i = 0; i < 10; i++)
            {
                AddNewCharacterToGame(CharacterType.Talent, Professions.Actor, Genders.Male, SexualPreference.HETEROSEXUAL,
                    1, 0.5f, 1f, 0.5f, 0.5f, 0.5f, i, i,
                    new List<string> { }, false, 25f);
            }
#if DEBUG
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
#endif
        }
        //TalentDataWrapper
        static MethodInfo CreateTalentFromParams;
        public static void InitPrivateMethods()
        {
            CreateTalentFromParams =
                typeof(CharactersManager).GetMethod("CreateTalentFromParams",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }
        private TalentDataWrapper AddNewCharacterToGame(
    Enums.CharacterType type,
    Professions profession,
    Genders gender,
    SexualPreference sexualPreference,
    int preferredDarkPresent,
    float skill,
    float limit,
    float mood,
    float attitude,
    float selfEsteem,
    float art,
    float com,
    List<string> labels,
    bool isForTutorial = false,
    float age = -1f)
        {
            Logger.Log("Creating character ");
            return CreateTalentFromParams.Invoke(CharactersManager,
                new object[] { type, profession, gender, sexualPreference,
                    preferredDarkPresent, skill, limit, mood, attitude, selfEsteem, art, com, labels, isForTutorial, age }) as TalentDataWrapper;
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
#if DEBUG
            Logger.Log($"Creating coroutine for action");
#endif
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
