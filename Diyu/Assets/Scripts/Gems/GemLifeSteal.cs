﻿using Abilities;
using Buffs;
using Entities;

namespace Gems
{
    public class GemLifeSteal : Gem
    {
        public float statBuff;
        public override int id { get => 4; }
        
        public GemLifeSteal(Rarities rarity,NewPlayer target) //Sets the stats according to Rarity of the Gem
        {
            displayName = "Lifesteal Gem";
            displayDesc = "Permanently boosts Lifesteal";
            switch (rarity)
            {
                case Rarities.COMMON:
                    statBuff = 0.05f;
                    break;
                case Rarities.UNCOMMON:
                    statBuff = 0.06f;
                    break;
                case Rarities.RARE:
                    statBuff = 0.07f;
                    break;
                case Rarities.EPIC:
                    statBuff = 0.08f;
                    break;
                case Rarities.LEGENDARY:
                    statBuff = 0.09f;
                    break;
                case Rarities.MYTHIC:
                    statBuff = 0.1f;
                    break;
            }

            Rarity = rarity;
            Target = target;
            if (target != null)
            {
                Target.lifesteal += statBuff;
                Target.lsBonus += statBuff;
            }
        }

        public override void SetRarity(Rarities rarity)
        {
            Target.lifesteal -= statBuff;
            switch (rarity)
            {
                case Rarities.COMMON:
                    statBuff = 0.05f;
                    break;
                case Rarities.UNCOMMON:
                    statBuff = 0.06f;
                    break;
                case Rarities.RARE:
                    statBuff = 0.07f;
                    break;
                case Rarities.EPIC:
                    statBuff = 0.08f;
                    break;
                case Rarities.LEGENDARY:
                    statBuff = 0.09f;
                    break;
                case Rarities.MYTHIC:
                    statBuff = 0.1f;
                    break;
            }
            Rarity = rarity;
            Target.lifesteal += statBuff;
        }
    }
}