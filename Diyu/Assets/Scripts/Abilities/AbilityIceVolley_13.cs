﻿using System;
using System.Collections;
using System.Collections.Generic;
using AOEs;
using Buffs;
using Entities;
using UnityEngine;
using Weapons;
using Object = UnityEngine.Object;

namespace Abilities
{
    public class AbilityIceVolley_13 : Ability
    {
        public override int id { get => 13; }
        public float damage;
        public float timer;
        public int count;
        public int curCount;
        private readonly GameObject _fireball;
        private readonly ParticleSystem _firelaunch;
        private const float FireSpeed = 50.0f;
        
        private syncManager syncManager;

        private void Update()
        {
            syncManager = Object.FindObjectOfType<syncManager>();
            //Debug.LogError(syncManager != null);
        }
        
        private readonly GameObject _indicator;
        
        public AbilityIceVolley_13(Rarities rarity,Entity target) //Sets the stats according to Rarity of the Ability
        {
            displayName = "Ice Volley";
            switch (rarity)
            {
                case Rarities.COMMON:
                    damage = 5;
                    Cooldown = 15;
                    count = 2;
                    break;
                case Rarities.UNCOMMON:
                    damage = 7;
                    Cooldown = 14;
                    count = 3;
                    break;
                case Rarities.RARE:
                    damage = 9;
                    Cooldown = 13;
                    count = 3;
                    break;
                case Rarities.EPIC:
                    damage = 11;
                    Cooldown = 12;
                    count = 4;
                    break;
                case Rarities.LEGENDARY:
                    damage = 13;
                    Cooldown = 11;
                    count = 4;
                    break;
                case Rarities.MYTHIC:
                    damage = 15;
                    Cooldown = 10;
                    count = 5;
                    break;
            }
            displayDesc = $"Fires {count} frozen projectiles in a quick succession, each dealing {damage} damage. Has a {Cooldown} seconds cooldown.";
            Rarity = rarity;
            State = States.READY;
            Target = target;
            timer = 0;
            curCount = 0;
            _fireball = Target.resources.projectileList[0];
            _firelaunch = Target.resources.particleList[0];
            _indicator = Object.Instantiate(Target.resources.indicatorList[1], GetPostion(), Quaternion.identity);
            _indicator.transform.localScale *= 3;
            _indicator.SetActive(false);
        }
        
        public void CmdAttack()
        {
            Update();
            CurrentCooldown = Cooldown;
            var position = Target.anchor.transform.position;
            syncManager.CmdSpawnFireball(3,position,(damage + Target.abilityPower),Target.anchor.transform.forward);
        }
        
        public Vector3 GetPostion()
        {
            NewPlayer target = (NewPlayer)Target;
            var position = target.model.transform.position;
            position.y -= 0.95f;
            return position;
            
        }

        public override void OnEnd()
        {
            Object.Destroy(_indicator);
        }
        
        public override void PassiveEffect()
        {
            timer -= Time.deltaTime;
            if (State == States.ACTIVE && timer <= 0)
            {
                curCount--;
                timer = 0.3f;
                CmdAttack();
            }
        }

        public override void ActiveEffect()
        {
            _indicator.SetActive(false);
            if (State == States.READY)
            {
                State = States.ACTIVE;
                curCount = count;
                CurrentDuration = curCount * 0.3f;
            }
        }

        public override void SetupEffect()
        {
            _indicator.SetActive(true);
            _indicator.transform.position = GetPostion();
            _indicator.transform.rotation = Target.model.transform.rotation;
        }

        public override void SetRarity(Rarities rarity)
        {
            switch (rarity)
            {
                case Rarities.COMMON:
                    damage = 5;
                    Cooldown = 15;
                    count = 2;
                    break;
                case Rarities.UNCOMMON:
                    damage = 7;
                    Cooldown = 14;
                    count = 3;
                    break;
                case Rarities.RARE:
                    damage = 9;
                    Cooldown = 13;
                    count = 3;
                    break;
                case Rarities.EPIC:
                    damage = 11;
                    Cooldown = 12;
                    count = 4;
                    break;
                case Rarities.LEGENDARY:
                    damage = 13;
                    Cooldown = 11;
                    count = 4;
                    break;
                case Rarities.MYTHIC:
                    damage = 15;
                    Cooldown = 10;
                    count = 5;
                    break;
            }
            Rarity = rarity;
            displayDesc = $"Fires {count} frozen projectiles in a quick succession, each dealing {damage} damage. Has a {Cooldown} seconds cooldown.";
        }
    }
}