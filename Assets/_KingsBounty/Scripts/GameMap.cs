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

        private void Start()
        {
            GenerateMap();
        }

        private void GenerateMap()
        {
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
            cell.SetColor(GetCellColor());
        }

        private Color GetCellColor()
        {
            var cellType = (CellType)Random.Range(0, Enum.GetNames(typeof(CellType)).Length);
            
            return cellType switch
            {
                CellType.Ground => Color.gray,
                CellType.Water => Color.cyan,
                CellType.Mount => Color.magenta,
                CellType.Forest => Color.green,
                CellType.Sand => Color.yellow,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}