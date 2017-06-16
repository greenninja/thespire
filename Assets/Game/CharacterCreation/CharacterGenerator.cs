
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
        private Color m_Haircolor;
        private Color m_Skincolor;
        private GenderType m_Gender = GenderType.OTHER;
        private SexualOrientation m_SexualOrientation;

        private static GenderType RandomizeGender()
        {
            int t = UnityEngine.Random.Range(0, 11);
            GenderType gender;

            if (t <= 5) gender = GenderType.MALE;
            else if (t > 5 && t < 11) gender = GenderType.FEMALE;
            else gender = GenderType.OTHER;

            return gender;
        }

        public void SetName(GenderType pGender)
        {
            m_FirstName = RandomizeName(NamesGenerator.GetFirstNames(pGender));
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
            //Randomize SexualIntrestType
            GenSexualOrientation();
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

        public void GenSexualOrientation()
        {
            int r = UnityEngine.Random.Range(1, 10);
            if (r == 10)
            {
                m_SexualOrientation = SexualOrientation.UNSPECIFIED;
            }
            else if (r >= 8)
            {

                m_SexualOrientation = SexualOrientation.HOMOSEXUAL;
            }
            else if (r >= 6)
            {

                m_SexualOrientation = SexualOrientation.BISEXUAL;
            }

            else
            {

                m_SexualOrientation = SexualOrientation.HETEROSEXUAL;
            }

        }

        public enum SexualOrientation
        {
            UNSPECIFIED,
            HOMOSEXUAL,
            BISEXUAL,
            HETEROSEXUAL
        }
        public enum GenderType
        {
            MALE,
            FEMALE,
            OTHER
        }
    }
}
