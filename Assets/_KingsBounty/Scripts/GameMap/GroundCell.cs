using System;
using UnityEngine;

namespace KingsBounty
{
    public class GroundCell : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        
        private CellType _cellType;

        public CellType CellType => _cellType;
        
        public void SetCellType(CellType cellType)
        {
            _cellType = cellType;
            _spriteRenderer.color = GetCellColor();
        }
        
        private Color GetCellColor()
        {
            return _cellType switch
            {
                CellType.Ground => Color.gray,
                CellType.Water => Color.blue,
                CellType.Mount => Color.magenta,
                CellType.Forest => Color.green,
                CellType.Sand => Color.yellow,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}