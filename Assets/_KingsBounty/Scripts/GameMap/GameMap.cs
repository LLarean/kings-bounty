using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace KingsBounty
{
    public class GameMap : MonoBehaviour
    {
        [SerializeField] private GroundCell _prefab;
        [SerializeField] private int _sizeX;
        [SerializeField] private int _sizeY;
        [Space]
        [SerializeField] private Sprite _ground;
        [SerializeField] private Sprite _water;
        [SerializeField] private Sprite _mountain;
        [SerializeField] private Sprite _forest;
        [SerializeField] private Sprite _desert;

        private GroundCell[,] _groundCells;

        public CellType GetCellType(Vector2 position)
        {
            var cellPositionX = (int)position.x + _sizeX / 2;
            var cellPositionY = (int)position.y + _sizeY / 2;
            
            return _groundCells[cellPositionX, cellPositionY].CellType;
        }

        private void Start()
        {
            GenerateMap();
        }

        private void GenerateMap()
        {
            _groundCells = new GroundCell[_sizeX, _sizeY];

            for (int i = -_sizeX / 2; i < _sizeX / 2; i++)
            {
                for (int j = -_sizeY / 2; j < _sizeY / 2; j++)
                {
                    CreateCell(i, j);
                }
            }
        }

        private void CreateCell(int xPosition, int yPosition)
        {
            GroundCell cell = Instantiate(_prefab, transform);
            cell.transform.localPosition = new Vector3(xPosition, yPosition);

            var cellType = (CellType)Random.Range(0, Enum.GetNames(typeof(CellType)).Length);
            cell.SetCellType(cellType, GetCellSprite(cellType));
            
            cell.gameObject.name = $"Cell ({cellType}, {xPosition}, {yPosition})";

            var cellPositionX = xPosition + _sizeX / 2;
            var cellPositionY = yPosition + _sizeY / 2;
            
            _groundCells[cellPositionX, cellPositionY] = cell;
        }
        
        private Sprite GetCellSprite(CellType cellType)
        {
            return cellType switch
            {
                CellType.Ground => _ground,
                CellType.Water => _water,
                CellType.Mountain => _mountain,
                CellType.Forest => _forest,
                CellType.Desert => _desert,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}