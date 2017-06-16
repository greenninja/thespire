using UnityEngine;
using System;
using System.Collections;
using Assets.Scripts.World.Characters;

namespace Assets.Scripts.World.Characters
{
    /// <summary>
    ///  This class keeps track of a Pro Gamers experience and updated attribute points
    /// </summary>
    public class Experience
    {
        // Starting XP needed to level up
        private int m_MaxExpToNext = 1000;
        // Current XP needed to level up
        private int m_CurrExpToNext = 1000;
        // Attributes of a specific Pro Gamer
        private Attributes m_ProGamerAttributes;
        // Distributable attribute points gained from leveling up
        private int m_AttributePointsLeft = 0;
        // Attribute points which are distributed but not yet saved
        private int[] m_AppliedAttributePoints = new int[Enum.GetNames(typeof(Attribute)).Length];

        public int MaxExpToNext
        {
            get { return m_MaxExpToNext; }
            set { m_MaxExpToNext = value; }

        }

        public int CurrExpToNext
        {
            get { return m_CurrExpToNext; }
            set { m_CurrExpToNext = value; }

        }

        public Attributes ProGamerAttributes
        {
            get { return m_ProGamerAttributes; }
            set { m_ProGamerAttributes = value; }

        }

        public int AttributePointsLeft
        {
            get { return m_AttributePointsLeft; }
            set { m_AttributePointsLeft = value; }

        }

        public int[] AppliedAttributePoints
        {
            get { return m_AppliedAttributePoints; }
            set { m_AppliedAttributePoints = value; }

        }

        /// <summary>
        /// Constructor. Set the starting applied attribute points to 0
        /// </summary>
        public Experience(Attributes pAttributes)
        {
            m_ProGamerAttributes = pAttributes;
            for (int i = 0; i < m_AppliedAttributePoints.Length; i++) {
                m_AppliedAttributePoints[i] = 0;
            }
        }

        /// <summary>
        /// Increment or decrement one attribute point
        /// </summary>
        /// <param name="pAttribute">
        ///     Index of the attribute to change. Use same index-system as
        ///     enum Attribute from class Attributes. Ex: (int)Attribute.ATTENTION
        /// </param>
        /// <param name="pIncrement">Increment if true, decrement if false</param>
        public void UpdateAppliedAttrPoints(int pAttribute, bool pIncrement)
        {
            if (pIncrement == true && m_AttributePointsLeft > 0)
            {
                m_AppliedAttributePoints[pAttribute]++;
                m_AttributePointsLeft--;
            }
            else if (!pIncrement && m_AppliedAttributePoints[pAttribute] > 0)
            {
                m_AppliedAttributePoints[pAttribute]--;
                m_AttributePointsLeft++;
            }
        }

        /// <summary>
        /// Save the applied attribute points
        /// </summary>
        public void SaveAttrPoints()
        {
            m_ProGamerAttributes.Attention += m_AppliedAttributePoints[(int)Attribute.ATTENTION];
            m_ProGamerAttributes.Concentration += m_AppliedAttributePoints[(int)Attribute.CONCENTRATION];
            m_ProGamerAttributes.Communication += m_AppliedAttributePoints[(int)Attribute.COMMUNICATION];
            m_ProGamerAttributes.Discipline += m_AppliedAttributePoints[(int)Attribute.DISCIPLINE];
            m_ProGamerAttributes.EmotionalStability += m_AppliedAttributePoints[(int)Attribute.EMOTIONALSTABILITY];
            m_ProGamerAttributes.FineMotorSkills += m_AppliedAttributePoints[(int)Attribute.FINEMOTORSKILLS];
            m_ProGamerAttributes.ReactionTime += m_AppliedAttributePoints[(int)Attribute.REACTIONTIME];
        }

        /// <summary>
        /// Reset all the placed out attribute points which have not been saved
        /// </summary>
        public void ResetAttrPoints()
        {
            int pointsToReset = 0;
            for (int i = 0; i < m_AppliedAttributePoints.Length; i++)
            {
                pointsToReset += m_AppliedAttributePoints[i];
                m_AppliedAttributePoints[i] = 0;
            }
            m_AttributePointsLeft += pointsToReset;
        }

        /// <summary>
        /// Update the experience points after a game
        /// </summary>
        public void UpdateExpPoints(int pBaseExp)
        {
            float expWithPotential = pBaseExp * (float)Math.Pow(ProGamerAttributes.Potential, 1.5);
            int totalExpGained = (int)Math.Round(expWithPotential);
            // If XP gained is more than current XP to next level, the
            // pro gamer will level up
            int remainingExp = totalExpGained - m_CurrExpToNext;
            if (remainingExp >= 0)
            {
                m_CurrExpToNext = m_MaxExpToNext - remainingExp;
                // 1 attribute point is gained after level up
                m_AttributePointsLeft++;
            }
            else
            {
                m_CurrExpToNext -= totalExpGained;
            }
        }
    }
}