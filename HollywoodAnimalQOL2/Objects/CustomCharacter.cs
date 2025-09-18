using Data.Configs;
using Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Loggerns;
using Logger = Loggerns.Logger;
namespace HollywoodAnimalQOL2.Objects
{
    internal class CustomCharacter
    {
        public string FirstName { get; set; } = "Template";
        public string LastName { get; set; } = "Character";
        public Professions Profession { get; set; } = Professions.Actor;
        public CharacterType CharacterType { get; set; } = CharacterType.Talent;
        //???
        public int PortraitBaseId { get; set; } = 0;
        //0-young,1-mid,2-old
        public int AgeGroup { get; set; } = 2;
        //0-male
        public int Gender { get; set; } = 0;
        public string IconPath { get; set; } = "LeonidKonevsky.png";
        public float Loyalty { get; set; } = 0.5f;
        public float Happiness { get; set; } = 0.5f;

        //public static Dictionary<string, int> 
        public static List<CharacterConfig> GetCustomCharacters()
        {
            Logger.Log($"lm: {HelperObject.LocalizationManager}");
            HelperObject.LocalizationManager.AddSubstitution("dsad", "dsad");
            //List<CustomCharacter> characters =
            //JsonUtility.FromJson<List<CustomCharacter>>(File.ReadAllText("./qol/Assets/newactors.json"));
            List<CharacterConfig> convertedCharacters = new List<CharacterConfig>();
            return convertedCharacters;
            //foreach (var item in characters)
            //{
            //    convertedCharacters.Add(new CharacterConfig()
            //    {
            //        firstNameId
            //    })
            //}
        }
    }
}
