using Assets.Scripts.World.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Assertions;

namespace Assets.Scripts.World.Characters
{
    /// <summary>
    ///   The attributes of a character. Attributes are a combination of nature and nurture
    ///   which should be enough of a base to extrapolate a character's basic skill stats.
    /// </summary>
    public class Attributes
    {

        private Character m_State;

        public float Attention = 0.5f;
        public float Concentration = 0.5f;
        public float Communication = 0.5f;
        public float Discipline = 0.5f;
        public float EmotionalStability = 0.5f;
        public float FineMotorSkills = 0.5f;
        public float ReactionTime = 0.5f;
        public float Leadership = 0.5f;

        public float Potential = 0.5f;

        public Attributes(Character pState)
        {
            m_State = pState;
        }

        /// <summary>
        ///   Generates pseudo-random values for each of the traits based on the
        ///   seed if provided with one, otherwise it is based on the system clock.
        /// </summary>
        public static Attributes Generate(int pSeed = 0)
        {
            Dictionary<Attribute, float> newAttributes = new Dictionary<Attribute, float>();
            Random random = new Random();

            //Sends empty characterstate for the time being.
            Attributes attributes = new Attributes(new Character());

            float[] attributeEnum = (float[])Enum.GetValues(typeof(Attribute));
            foreach (float attribute in attributeEnum)
            {
                float attributeValue = (pSeed == 0) ? random.Next() : random.Next(pSeed);
                newAttributes.Add((Attribute)attribute, attributeValue);
            }

            attributes.Set(newAttributes);
            return attributes;
        }

        /// <summary>
        ///   Takes a dictionary of Trait and int and sets its member variables accordingly.
        /// </summary>
        private void Set(Dictionary<Attribute, float> pNewAttributes)
        {
            foreach (int tVal in pNewAttributes.Values)
                if (tVal <= 0.01f || tVal >= 0.99f)
                    throw new Exception("Can't assign an int value of below 1 or above 99, "
                                        + "because it does not make sense.");

            Attention = pNewAttributes[Attribute.ATTENTION];
            Concentration = pNewAttributes[Attribute.CONCENTRATION];
            Communication = pNewAttributes[Attribute.COMMUNICATION];
            Discipline = pNewAttributes[Attribute.DISCIPLINE];
            EmotionalStability = pNewAttributes[Attribute.EMOTIONALSTABILITY];
            FineMotorSkills = pNewAttributes[Attribute.FINEMOTORSKILLS];
            ReactionTime = pNewAttributes[Attribute.REACTIONTIME];
            Potential = pNewAttributes[Attribute.POTENTIAL];
        }

        public void SetData(byte[] pData)
        {
            Dictionary<Attribute, float> newAttributes = new Dictionary<Attribute, float>();

            foreach (int t in (float[])Enum.GetValues(typeof(Attribute)))
                newAttributes.Add((Attribute)t, BitConverter.ToSingle(pData, 4 * t));

            Set(newAttributes);
        }

        public byte[] GetData()
        {
            List<byte> data = new List<byte>();
            data.AddRange(BitConverter.GetBytes(FineMotorSkills));
            data.AddRange(BitConverter.GetBytes(Attention));
            data.AddRange(BitConverter.GetBytes(Concentration));
            data.AddRange(BitConverter.GetBytes(Communication));
            data.AddRange(BitConverter.GetBytes(EmotionalStability));
            data.AddRange(BitConverter.GetBytes(ReactionTime));
            data.AddRange(BitConverter.GetBytes(Discipline));
            data.AddRange(BitConverter.GetBytes(Potential));
            data.AddRange(BitConverter.GetBytes(Leadership));
            return data.ToArray();
        }



    }


    public enum Attribute
    {

        ATTENTION,
        CONCENTRATION,
        COMMUNICATION,
        DISCIPLINE,
        EMOTIONALSTABILITY,
        FINEMOTORSKILLS,
        REACTIONTIME,
        LEADERSHIP,

        POTENTIAL
    }




}
