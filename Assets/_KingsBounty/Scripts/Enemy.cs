using UnityEngine;

namespace KingsBounty
{
    public class Enemy : MonoBehaviour
    {
        private Vector2 _currentPosition;
        
        public Vector2 CurrentPosition => _currentPosition;

        public void Construct(Vector2 startingPosition)
        {
            _currentPosition = startingPosition;
        }
    }
}