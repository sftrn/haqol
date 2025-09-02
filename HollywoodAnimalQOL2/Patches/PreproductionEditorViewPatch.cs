using Data.Configs;
using Data.GameObject.Building;
using Data.GameObject.Character;
using Data.GameObject.ForUI;
using Data.GameObject.Movie;
using Data.GameObject.Tech;
using Enums;
using HarmonyLib;
using Managers;
using Model.Movies;
using PP.OptimizedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UI.Common;
using UI.Common.Lists;
using UI.Common.Lists.ItemData;
using UI.Common.Lists.ItemView;
using UI.Common.SubPanels;
using UI.Views.MovieEditor;
using static UI.Common.Lists.ItemView.LocationTypeItemView;
//using static UI.Views.AssignPolluxNominations;?
using Logger = Loggerns.Logger;

namespace HollywoodAnimalQOL2
{
    [HarmonyPatch(typeof(PreproductionEditorView), "UpdateStage")]
    class PreproductionEditorViewPatch
    {
        static void Postfix(PreproductionEditorView __instance,
          ref SimpleList ___listSidebar,
          ref BuildingsManager ___buildingsManager,
          ref MovieDataWrapper ___movieWrapper,
          ref List<int> ___charactersForReplacement,
          ref DropdownItemData ___selectedItemData,
          ref SimpleList ___locationsListView,
          ref TechManager ___techManager,
          ref GameVariables ___gameVariables,
          ref StudioManager ___studioManager,
          ref MoviesOptions ___moviesOptions,
          ref PreproductionEditorView.Stages ___currentStage,
          ref PreproductionTechSelectionFieldSubpanel ___extras,
          ref PreproductionTechSelectionFieldSubpanel ___crew,
          ref PreproductionTechSelectionFieldSubpanel ___costumesAndProps,
          ref SimpleButton ___startPhaseButton)
        {


            if (___currentStage == PreproductionEditorView.Stages.Location)
            {
                ChooseLocationAndCinematog(__instance, ref ___buildingsManager, ref ___charactersForReplacement, ref ___movieWrapper, ref ___selectedItemData, ref ___studioManager);
            }
            else if (___currentStage == PreproductionEditorView.Stages.Tech)
            {
                ChooseTechAndSelectable(__instance, ref ___movieWrapper, ref ___techManager,
                    ref ___gameVariables, ref ___studioManager, ref ___moviesOptions,
                    ref ___extras, ref ___crew, ref ___costumesAndProps);
            }
            else if (___currentStage == PreproductionEditorView.Stages.Cast)
            {
                ChooseTeam(__instance, ref ___movieWrapper, ref ___charactersForReplacement, ref ___selectedItemData);
            }


            //OnResultsUpdated.Invoke
            //UpdateResults.Invoke(__instance, new object[] { });

            //___startPhaseButton.SetActive(true);
        }
        static MethodInfo PavilionSelected;
        static MethodInfo GetCharacterItemsToChooseFromForSlot;
        static MethodInfo GetCharactersItemContainerDataList;
        static MethodInfo OnItemSelected; 
        static MethodInfo UpdateTeamSlotItemView;
        static MethodInfo OnResultsUpdated;
        static MethodInfo VideoTechSelected;
        static MethodInfo AudioTechSelected;
        static MethodInfo UpdateResults;

        static MethodInfo LocationTypeOnValueChanged;
        static MethodInfo LocationTypeOnQualityChanged;

        public static void InitPrivateMethods()
        {
            LocationTypeOnValueChanged =
                typeof(LocationTypeItemView).GetMethod("OnValueChanged",
                BindingFlags.NonPublic | BindingFlags.Instance);


            LocationTypeOnQualityChanged =
                typeof(LocationTypeItemView).GetMethod("OnQualityChanged",
                BindingFlags.NonPublic | BindingFlags.Instance);
            PavilionSelected = typeof(PreproductionEditorView).GetMethod("PavilionSelected",
                BindingFlags.NonPublic | BindingFlags.Instance);
            GetCharacterItemsToChooseFromForSlot =
                typeof(PreproductionEditorView).GetMethod("GetCharacterItemsToChooseFromForSlot",
                BindingFlags.NonPublic | BindingFlags.Instance);
            GetCharactersItemContainerDataList =
                typeof(PreproductionEditorView).GetMethod("GetCharactersItemContainerDataList",
                BindingFlags.NonPublic | BindingFlags.Instance);
            OnItemSelected =
                typeof(PreproductionEditorView).GetMethod("OnItemSelected",
                BindingFlags.NonPublic | BindingFlags.Instance);
            UpdateTeamSlotItemView =
                typeof(PreproductionEditorView).GetMethod("UpdateTeamSlotItemView",
                BindingFlags.NonPublic | BindingFlags.Instance);
            OnResultsUpdated =
                typeof(PreproductionEditorView).GetMethod("OnResultsUpdated",
                BindingFlags.NonPublic | BindingFlags.Instance);
            VideoTechSelected =
                typeof(PreproductionEditorView).GetMethod("VideoTechSelected",
                BindingFlags.NonPublic | BindingFlags.Instance);
            AudioTechSelected =
                typeof(PreproductionEditorView).GetMethod("AudioTechSelected",
                BindingFlags.NonPublic | BindingFlags.Instance);
            UpdateResults =
                typeof(PreproductionEditorView).GetMethod("UpdateResults",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private static void ChooseLocationAndCinematog(PreproductionEditorView __instance,
            ref BuildingsManager ___buildingsManager,
            ref List<int> ___charactersForReplacement,
            ref MovieDataWrapper ___movieWrapper,
            ref DropdownItemData ___selectedItemData,
            ref StudioManager ___studioManager)
        {
            var cinematographerSlot = ___movieWrapper.PreproductionSlots.Single(
                slot => slot.Profession == Professions.Cinematographer);
            ChooseCharacterForSlot(__instance, ref ___movieWrapper,
                ref ___charactersForReplacement, ref ___selectedItemData, cinematographerSlot);
            var movieWrapperCopy = ___movieWrapper;
            var studioManagerCopy = ___studioManager;
            Logger.Log("Pavilion list opened");

            var freePavs = ___buildingsManager.GetAllPavilions().Where<BuildingDataWrapper>((Func<BuildingDataWrapper, bool>)
                (p => p.IsActive && p.IsOccupied == false))
                .Select<BuildingDataWrapper, SelectableItemData>
                ((Func<BuildingDataWrapper, SelectableItemData>)(p =>
                {
                    BuildingDataWrapper data = p;
                    int buildingId = p.Id;
                    int? movieId = movieWrapperCopy?.Pavilion?.Id;
                    int hasMovie = movieId.GetValueOrDefault();
                    int num1 = buildingId == hasMovie & movieId.HasValue ? 1 : 0;
                    return new SelectableItemData((object)data, num1 != 0, interactable: true);
                })).ToList<SelectableItemData>();


            Logger.Log($"Got {freePavs.Count} pavs free");
            if(freePavs.Count> 0)
            {
                PavilionSelected.Invoke(__instance, new object[] { (ItemContainerData)freePavs[0] });

                Logger.Log("Choosen first interactable pavilion");

                ___movieWrapper.LocationSlots.ForEach((l =>
                {
                    LocationSlotWrapper slot = l.Value;
                    slot.Type = LocationTypes.Indoor;
                    slot.Quality = studioManagerCopy.
                    GetMaxIndoorLocaltionQuality(movieWrapperCopy, slot.Quality, slot.Config.maxQualityPavilions[slot.SelectedPavilionLevel - 1]) - 1;//slot.Config.maxQualityPavilions[slot.SelectedPavilionLevel];
                }));
            }
        }

        static void ChooseTechAndSelectable(PreproductionEditorView __instance,
            ref MovieDataWrapper ___movieWrapper,
            ref TechManager ___techManager,
            ref GameVariables ___gameVariables,
            ref StudioManager ___studioManager,
            ref MoviesOptions ___moviesOption,
            ref PreproductionTechSelectionFieldSubpanel ___extras,
            ref PreproductionTechSelectionFieldSubpanel ___crew,
            ref PreproductionTechSelectionFieldSubpanel ___costumesAndProps
            )
        {
            Logger.Log($"Choosing best techs");

            var actualVideo = ___techManager.ActualVideoTechnologies
                .Where<TechDataWrapper>((Func<TechDataWrapper, bool>)(tech => !tech.Data.isOutDated))
                .MaxBy(tech => tech.PracticalityPointsMax + tech.EconomyPointsMax + tech.QualityPointsMax);

            var actualAudio = ___techManager.ActualAudioTechnologies
                .Where<TechDataWrapper>((Func<TechDataWrapper, bool>)(tech => !tech.Data.isOutDated))
                .MaxBy(tech => tech.PracticalityPointsMax + tech.EconomyPointsMax + tech.QualityPointsMax);
            var selectableAudio =
                new SelectableItemData((object)actualAudio, false, actualAudio.Config?.Id == ___gameVariables.DefaultFilm);
            var selectableVideo =
               new SelectableItemData((object)actualVideo, false, actualAudio.Config?.Id == ___gameVariables.DefaultFilm);

            Logger.Log($"Choosing best selectable");
            if (selectableAudio != null)
                AudioTechSelected.Invoke(__instance, new object[] { selectableAudio as ItemContainerData });
            if (selectableVideo != null)
                VideoTechSelected.Invoke(__instance, new object[] { selectableVideo as ItemContainerData });


            int maxExtras = ___studioManager.GetMaxExtras(___movieWrapper);
            (int index, bool isPlayer) data = (maxExtras-1, true);
            ___extras.EvSelectionChanged.Fire(data);
            int maxCrew = ___moviesOption.CrewItemsContainerDataList.Count;
            data = (maxCrew-1, true);
            ___crew.EvSelectionChanged.Fire(data);
            int costumesAndPropsQuality = ___studioManager.GetMaxCostumesAndPropsQuality(___movieWrapper);
            data = (costumesAndPropsQuality-1, true);
            ___costumesAndProps.EvSelectionChanged.Fire(data);

            Logger.Log($"choosen: extras: {maxExtras} crew: {maxCrew} costumes: {costumesAndPropsQuality}");
        }
        static void ChooseCharacterForSlot(PreproductionEditorView __instance,
            ref MovieDataWrapper ___movieWrapper,
            ref List<int> ___charactersForReplacement,
            ref DropdownItemData ___selectedItemData, TeamMemberSlotWrapper preproductionSlot
            )
        {
            var movieWrapperCopy = ___movieWrapper;
            Logger.Log($"Choosing top {preproductionSlot.Profession}");
            List<int> charactersForReplacement = ___charactersForReplacement;

            List<ItemContainerData> containerDataList = (List<ItemContainerData>)
                GetCharactersItemContainerDataList.Invoke(__instance, new object[] { preproductionSlot });


            DateTime till = movieWrapperCopy.GetPredictedProductionDeadlineFromPreproduction();
            Logger.Log($"Preproduction will end at: {till}");
            var chooseFromForSlot =
                 containerDataList.Where<ItemContainerData>
                 (c =>
                 {
                     CharacterDataWrapper character = c.GetData<CharacterCardSettingsData>().GetCharacter();
                     return character.IsHiredByPlayer && !character.IsBusy
                     && ((character.Contract.contractType == ContractType.Years && character.Contract.TrueExpirationDate >= till)
                     || character.Contract.contractType == ContractType.Projects)
                     && (preproductionSlot.Character != null &&
                     character == preproductionSlot.Character ||
                     character.HasProfession(preproductionSlot.Profession)
                     && character.IsAppropriateGender(preproductionSlot.SlotGender)
                     && !movieWrapperCopy.HasCharacterOfTheProfession(character.Id, preproductionSlot.Profession))
                     && (charactersForReplacement == null ||
                     !charactersForReplacement.Contains(character.Id)) && !character.IsUnavailable;
                 }).OrderByDescending<ItemContainerData, float>((i =>
                 i.GetData<CharacterCardSettingsData>().GetCharacter()
                 .GetSkillForProfession(preproductionSlot.Profession))).ToList();

            //((IEnumerable < ItemContainerData > )GetCharacterItemsToChooseFromForSlot.Invoke(__instance, parameters))
            //.ToList().Where(character => character.GetData<CharacterCardSettingsData>().GetCharacter().is;
            if (chooseFromForSlot.Count > 0)
            {
                var topCharacter = chooseFromForSlot[0];
                ___selectedItemData = topCharacter as DropdownItemData;
                CharacterDataWrapper character = topCharacter.GetData<CharacterCardSettingsData>().GetCharacter();
                Logger.Log($"Found {chooseFromForSlot.Count} for slot. Selecting {character.GetFullName()}");
                Logger.Log($"Character contract expiration: {character.Contract.TrueExpirationDate}");
                preproductionSlot.Character = character as TalentDataWrapper;
                if (preproductionSlot.Character == null)
                    return;
                movieWrapperCopy.AddContractDraft(preproductionSlot.Character.Id, preproductionSlot.Character.Contract);
            }
            else
            {
                Logger.Log($"0 characters for slot");
            }
            UpdateTeamSlotItemView.Invoke(__instance, new object[] { });
        }
        static void ChooseTeam(PreproductionEditorView __instance, 
            ref MovieDataWrapper ___movieWrapper, 
            ref List<int> ___charactersForReplacement,
            ref DropdownItemData ___selectedItemData
            )
        {

            foreach (TeamMemberSlotWrapper preproductionSlot in ___movieWrapper.PreproductionSlots.Where(
                slot=>slot.Profession != Professions.Cinematographer))
            {
                ChooseCharacterForSlot(__instance, ref ___movieWrapper,
                    ref ___charactersForReplacement, ref ___selectedItemData, preproductionSlot);

            }
            //UpdateTeamSlotItemView.Invoke(__instance, new object[] { });

            //UpdateTeamSlotItemView();
            //UpdateReplacementButtons();
            Logger.Log($"All characters choosen");
        }
      
    }
}
