
using Assets.Scripts.World.Characters;
using Assets.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public class CharacterGenerator
    {
        private string m_FirstName = "";
        private string m_LastName = "";
        private string m_NickName = "";
        private Gender m_Gender = Gender.MALE;

        private static Gender RandomizeGender()
        {
            int t = UnityEngine.Random.Range(0, 10);
            Gender gender = Gender.MALE;

            if (t <= 5) gender = Gender.MALE;
            else if (t > 5 && t < 11) gender = Gender.FEMALE; 

            return gender;
        }

        public void SetName(Gender pGender)
        {
            m_Gender = pGender;
           // m_FirstName = RandomizeName(NamesGenerator.GetFirstNames(m_Gender));
            m_LastName = RandomizeName(NamesGenerator.GetLastNames());
            m_NickName = RandomizeName(NamesGenerator.GetNickNames());
        }

        public static string RandomizeName(List<string> pNameList)
        {
            //Magic
            int r = UnityEngine.Random.Range(0, pNameList.Count);
            string name = "";
            name = pNameList[r];
            return name;
        }

        public enum Region
        {
            EAST,
            NORTH,
            SOUTH,
            WEST
        }

        //Character.GenerateEverything(newFirstName,newLastName, newAttributes)

        public CharacterGenerator()
        {
            //Randomize Gender
            m_Gender = RandomizeGender();
          
            SetName(m_Gender);

            TimeSpan CalcSpan = new TimeSpan();

            //Randomize Attributes
            Attributes newAttributes = Attributes.Generate();

            //Randomize Region
            Region RegionChosen = EnumTools.EnumRandomizer<Region>();

        }

        public void ChangeNickName(string pNickname)
        {
            ////Console.WriteLine(m_NickName);
            //string c = "";
            //Console.WriteLine(c);
            if (pNickname == m_NickName)
                return;

            m_NickName = pNickname;
        }

        public enum Gender
        {
            MALE,
            FEMALE
        }
    }
}
