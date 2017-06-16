using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public static class NamesGenerator
    {
        private static List<string> m_fstNames;
        private static List<string> m_fNames;
        private static List<string> m_mNames;
        private static List<string> m_oNames;
        private static List<string> m_lNames;
        private static List<string> m_nNames;
        private static List<string> m_FullName;


        public static List<string> GetFirstNames(GenderType pGender)
        {
            //Access
            // GenderType pGender = RandomizeGender();
            List<string> fstNames = new List<string>();

            switch (pGender)
            {
                case GenderType.MALE: fstNames = m_mNames; break;
                case GenderType.FEMALE: fstNames = m_fNames; break;
                default: fstNames = m_oNames; break;
            }
            return fstNames;
        }

        public static List<string> GetMaleNames()
        {
            List<string> mNames = new List<string>();
            mNames.Add("Hans");
            mNames.Add("JörGen");
            mNames.Add("Lasse");

            //Get shit from database #Magic
            //Select first name from namestable in "Link"
            //Tables - NamesTable.
            //->
            return mNames;
        }
        public static List<string> GetFemaleNames()
        {
            List<string> fNames = new List<string>();
            m_fNames.Add("Greta");
            m_fNames.Add("Hanna");
            m_fNames.Add("Julia");
            return fNames;
        }
        public static List<string> GetOtherNames()
        {
            List<string> oNames = new List<string>();
            oNames.Add("Kim");
            oNames.Add("Andy");
            oNames.Add("Lee");
            return oNames;
        }
        public static List<string> GetLastNames()
        {
            List<string> lNames = new List<string>();
            lNames.Add("Fredriksson");
            lNames.Add("Andersson");
            lNames.Add("Lundberg");
            return lNames;
        }
        public static List<string> GetNickNames()
        {
            List<string> nNames = new List<string>();
            nNames.Add("Froggy");
            nNames.Add("XxBuzzkillerxX");
            nNames.Add("Teh Madhatter");
            return nNames;
        }

        public static List<string> GenFullName(GenderType pGender)
        {
            List<string> fstNames = GetFirstNames(pGender);
            List<string> nickNames = GetNickNames();
            List<string> lastNames = GetLastNames();

            string fstName;
            string nickName;
            string lastName;

            fstName = fstNames[UnityEngine.Random.Range(0, fstNames.Count)];
            nickName = nickNames[UnityEngine.Random.Range(0, lastNames.Count)];
            lastName = lastNames[UnityEngine.Random.Range(0, lastNames.Count)];

            List<string> fullName = new List<string>();
            fullName.Add(fstName);
            fullName.Add(nickName);
            fullName.Add(lastName);
            return fullName;
        }

    }
}