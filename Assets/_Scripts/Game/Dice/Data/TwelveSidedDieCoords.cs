using System.Collections.Generic;
using UnityEngine;

namespace Game.Dice.Data
{
    //Gdybym miał odina możliwe, że zrobiłbym scriptableobject
    public class TwelveSidedDieCoords : DieCoordinates
    {
        public TwelveSidedDieCoords()
        {
            _coordinates = new Dictionary<int, List<Vector2Int>>
            {
                { 1, new List<Vector2Int>
                    {
                        new(0, -150),
                        new(0, 210),
                        new(-360, -210),
                        new(360, -150),
                        new(180, 30),
                        new(180, -330),
                        new(360, -210),
                        new(360, 210),
                        new(-360, -150),
                        new(-180, -330),
                        new(-180, 30)
                    }
                },
                
                { 2, new List<Vector2Int>
                    {
                        new(-180, 150),
                        new(0, -30),
                        new(-180, -210),
                        new(0, 330),
                        new (360, 330)
                    }
                },
                
                { 3, new List<Vector2Int>
                    {
                        new(-210, -90),
                        new(180, -210),
                        new(180, 150),
                        new(-210, 270),
                        new(30, -270),
                        new(30, 90),
                        new(150, 270),
                        new(150, -90)
                    }
                },
                
                { 4, new List<Vector2Int>
                    {
                        new(-60, -180),
                        new(-60, 180),
                        new(300, -180),
                        new(300, 180),
                        new(-120, 0),
                        new(-120, -360),
                        new(-120, 360)
                    }
                },
                
                { 5, new List<Vector2Int>
                    {
                        new(-240, -360),
                        new(-240, 0),
                        new(-300, -180),
                        new(-300, 180),
                        new(-240, 360),
                        new(60, -180),
                        new(60, 180),
                        new(120, -360),
                        new(120, 0),
                        new(120, 360)
                    }
                },
                
                { 6, new List<Vector2Int>
                    {
                        new(-210, -270),
                        new(-210, 90),
                        new(30, -90),
                        new(30, 270),
                        new(150, 90),
                        new(150, -270)
                    }
                },
                
                { 7, new List<Vector2Int>
                    {
                        new(-30, -270),
                        new(-30, 90),
                        new(-150, -90),
                        new(-150, 270),
                        new(330, 90)
                    }
                },
                
                { 8, new List<Vector2Int>
                    {
                        new(-60, 0),
                        new(-60, 360),
                        new(-120, -180),
                        new(300, -360),
                        new(300, 0),
                        new(300, 360),
                        new(-120, 180),
                        new(-60, -360)
                    }
                },
                
                { 9, new List<Vector2Int>
                    {
                        new(-240, -180),
                        new(-240, 180),
                        new(-300, -360),
                        new(-300, 0),
                        new(-300, 360),
                        new(120, -180),
                        new(-360, -330),
                        new(60, 360),
                        new(120, 180),
                        new(60, 0),
                        new(360, -30),
                        new(360, -330),
                        new(-360, -30),
                        new(60, -360)
                    }
                },
                
                { 10, new List<Vector2Int>
                    {
                        new(-30, -90),
                        new(-30, 270),
                        new(-150, 90),
                        new(-150, -270),
                        new(330, 270)
                    }
                },
                
                { 11, new List<Vector2Int>
                    {
                        new(0, -210),
                        new(0, 150),
                        new(-180, -30),
                        new(-180, 330),
                        new(-360, -210),
                        new(360, 150),
                        new(-360, 150),
                        new(180, -30),
                        new(360, -210),
                        new(180, 330)
                    }
                },
                
                { 12, new List<Vector2Int>
                    {
                        new(0, -330),
                        new(0, 30),
                        new(360, -330),
                        new(-180, -150),
                        new(-180, 210),
                        new(360, 30),
                        new(-360, -330),
                        new(-360, 30),
                        new(180, 210),
                        new(180, -150)
                    }
                }
            };
        }
    }
}