using System;
using UnityEngine;

namespace KingsBounty
{
    public class GroundCell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private CellType _cellType;

        public CellType CellType => _cellType;
        
        public void SetCellType(CellType cellType, Sprite cellSprite)
        {
            _cellType = cellType;
            _spriteRenderer.sprite = cellSprite;
        }
    }
}