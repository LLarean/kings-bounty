using UnityEngine;

namespace KingsBounty
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private GameMap _gameMap;

        private Vector2 _currentPosition;
        private Vector2 _velocity;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _velocity = new Vector2(0, -1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _velocity = new Vector2(0, 1);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _velocity = new Vector2(-1, 0);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                _velocity = new Vector2(1, 0);
            }

            if (_velocity == Vector2.zero) return;

            var newPosition = _currentPosition + _velocity;

            if (_gameMap.GetCellType(newPosition) == CellType.Water)
            {
                _velocity = Vector2.zero;
                return;
            }
            
            if (_gameMap.GetCellType(newPosition) == CellType.Mountain)
            {
                _velocity = Vector2.zero;
                return;
            }
            
            transform.Translate(_velocity);
            _currentPosition = transform.position;
            _velocity = Vector2.zero;
        }
    }
}