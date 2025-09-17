using UnityEngine;

namespace KingsBounty
{
    public class GroundCell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void SetColor(Color color)
        {
            _spriteRenderer.color = color;
        }
    }
}