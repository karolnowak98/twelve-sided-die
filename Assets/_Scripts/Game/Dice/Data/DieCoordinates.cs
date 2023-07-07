using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Dice.Data
{
    public abstract class DieCoordinates
    {
        protected Dictionary<int, List<Vector2Int>> _coordinates;

        protected DieCoordinates()
        {
            _coordinates = new Dictionary<int, List<Vector2Int>>();
        }
        
        public List<Vector2Int> GetCoordinatesBySide(int side)
        {
            if (_coordinates.TryGetValue(side, out var coordinates))
            {
                return coordinates;
            }

            Debug.LogWarning("Not found coordinates!!");
            return null;
        }
        
        public int GetSideByCoordinates(Vector2 coordinates, float diffValue)
        {
            foreach (var (side, coords) in _coordinates)
            {
                foreach (var coord in coords)
                {
                    var diffX = Math.Abs(coord.x - coordinates.x);
                    var diffY = Math.Abs(coord.y - coordinates.y);

                    if (diffX <= diffValue && diffY <= diffValue)
                    {
                        return side;
                    }
                }
            }

            Debug.LogWarning("Not found side which has coordinates!!");
            return 0;
        }
    }
}