using UnityEngine;

namespace KingsBounty
{
    public class Enemies : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        private Enemy[] _enemies;

        public void Construct(int enemiesCount, Vector2[] enemyPositions)
        {
            GenerateEnemies(enemiesCount, enemyPositions);
        }

        private void GenerateEnemies(int enemiesCount, Vector2[] enemyPositions)
        {
            _enemies = new Enemy[enemiesCount];
            
            for (int i = 0; i < enemiesCount; i++)
            {
                Enemy enemy = Instantiate(_enemy, transform);
                
                var randomPosition = enemyPositions[Random.Range(0, enemyPositions.Length)];
                enemy.transform.localPosition = new Vector3(randomPosition.x, randomPosition.y);
                
                enemy.Construct(randomPosition);
                _enemies[i] = enemy;
            }
        }
    }
}