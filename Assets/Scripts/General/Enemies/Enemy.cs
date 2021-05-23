using System;
using General.Stats;
using UnityEngine;
using System.Collections.Generic;

namespace General.Enemies
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public Health Health { get; private set; }
        public int Points { get; private set; }

        public event Action<GameObject> OnTriggerEnterChange;
        public event Action<Enemy> OnClone;

        public EnemyAbilities Abilities;

        private Enemy _enemyPrefab;

        internal static Ship CreateShipEnemy(Ship enemyPrefab, int hp, int points)
        {
            var enemy = Instantiate(enemyPrefab);
        
            enemy.Health = new Health(hp, hp);

            enemy.Points = points;

            enemy.Abilities = new EnemyAbilities(new List<IAbility>()
            {
                new Ability("ship", 2)
            });

            enemy._enemyPrefab = enemyPrefab;
        
            return enemy;
        }

        internal static Asteroid CreateAsteroidEnemy(Asteroid enemyPrefab, int hp, int points)
        {
            var enemy = Instantiate(enemyPrefab);
        
            enemy.Health = new Health(hp, hp);
            enemy.Points = points;
            enemy.Abilities = new EnemyAbilities(new List<IAbility>()
            {
                new Ability("asteroid", 2)
            });

            enemy._enemyPrefab = enemyPrefab;
            
            return enemy;
        }

        public Enemy Clone()
        {
            var enemy = Instantiate(_enemyPrefab);
            enemy.Abilities = Abilities;
            enemy.Health = new Health(Health.Max, Health.Current);
            enemy._enemyPrefab = _enemyPrefab;
            
            OnClone?.Invoke(enemy);
            
            return enemy;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject);
        }
    }
}