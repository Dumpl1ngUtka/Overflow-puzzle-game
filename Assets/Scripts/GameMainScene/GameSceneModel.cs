using Helpers;
using Services.SaveLoadService;
using Services.SceneControlService;
using UnityEngine;
using Random = System.Random;

namespace GameMainScene
{
    public class GameSceneModel
    {
        private readonly Random _random;
        private LevelData _levelData;
        public int SelectedColor {get; private set; }
        public readonly int[,] Map;
        public readonly int FlaskCount;
        public readonly int FlaskHeight;
        
        public GameSceneModel()
        {
            _levelData = SaveLoadService.Instance.LoadData();
            var levelPreset = LevelPresetCalculator.GetLevelPresetById(_levelData.CurrentLevelIndex);
            
            _random = new Random(levelPreset.RandomHash);
            
            FlaskCount = levelPreset.FlaskCount; 
            FlaskHeight = levelPreset.FlaskHeight;
            
            Map = GenerateMap(FlaskCount, FlaskHeight);
        }

        public void ClickOnFlask(int flaskIndex)
        {
            if (SelectedColor == 0)
            {
                if (!IsFlaskEmpty(flaskIndex))
                {
                    SelectedColor = GetColorFromTop(flaskIndex);
                    RemoveColorFromTop(flaskIndex);
                }
                else
                {
                    //empty flask message 
                }
            }
            else
            {
                if (!IsFlaskFull(flaskIndex))
                {
                    PutColorToTop(flaskIndex, SelectedColor);
                    SelectedColor = 0;
                    CheckLevelComplete();
                }
                else
                {
                    //full flask message 
                }
            }
        }

        private int[,] GenerateMap(int flaskCount, int flaskHeight)
        {
            var map = new int[flaskCount, flaskHeight];
            for (var flaskIndex = 0; flaskIndex < map.GetLength(0); flaskIndex++)
                for (var heightIndex = 0; heightIndex < map.GetLength(1); heightIndex++) 
                    map[flaskIndex, heightIndex] = flaskIndex; // 0 = empty cell

            return MixedColors(map);
        }

        private int[,] MixedColors(int[,] baseMap)
        {
            var flaskCount = baseMap.GetLength(0);
            var flaskHeight = baseMap.GetLength(1);
            var colors = new int[flaskCount * flaskHeight];

            var colorIndex = 0;
            foreach (var color in baseMap) 
                colors[colorIndex++] = color;

            while (colorIndex > 1)
            {
                colorIndex--;
                var index = _random.Next(colorIndex + 1);
                (colors[index], colors[colorIndex]) = (colors[colorIndex], colors[index]);
            }

            var newMap = new int[flaskCount, flaskHeight];
            var flaskColorIndex = 0;
            for (var x = 0; x < flaskCount; x++)
            {
                var emptyCellCount = 0;
                for (var y = 0; y < flaskHeight; y++)
                {
                    var color = colors[flaskColorIndex++];

                    if (color == 0)
                    {
                        emptyCellCount++;
                        continue;
                    }
                    newMap[x, y - emptyCellCount] = color;
                }
            }

            return newMap;
        }

        private int GetColorFromTop(int flaskIndex)
        {
            for (var heightIndex = FlaskHeight - 1; heightIndex >= 0; heightIndex--)
            {
                var color = Map[flaskIndex, heightIndex];
                if (color != 0)
                    return color;
            }
            return 0;
        }

        private void RemoveColorFromTop(int flaskIndex)
        {
            for (var heightIndex = FlaskHeight - 1; heightIndex >= 0; heightIndex--)
            {
                if (Map[flaskIndex, heightIndex] != 0)
                {
                    Map[flaskIndex, heightIndex] = 0;
                    return;
                }
            }
        }

        private void PutColorToTop(int flaskIndex, int colorIndex)
        {
            for (var heightIndex = 0; heightIndex < FlaskHeight; heightIndex++)
            {
                if (Map[flaskIndex, heightIndex] == 0)
                {
                    Map[flaskIndex, heightIndex] = colorIndex;
                    return;
                }
            }
        }

        private bool IsFlaskEmpty(int flaskIndex) => Map[flaskIndex, 0] == 0;

        private bool IsFlaskFull(int flaskIndex) => Map[flaskIndex, FlaskHeight - 1] != 0;

        private void CheckLevelComplete()
        {
            if (IsLevelComplete())
            {
                _levelData.CurrentLevelIndex += 1;
                SaveLoadService.Instance.SaveData(_levelData);
                
                var service = SceneControlService.Instance;
                service.ChangeScene(service.GameControllerPrefab);
            }
        }
        
        private bool IsLevelComplete()
        {
            if (SelectedColor != 0)
                return false;
            
            for (var flaskIndex = 0; flaskIndex < Map.GetLength(0); flaskIndex++)
            {
                var colorIndex = Map[flaskIndex, 0];
                for (var heightIndex = 1; heightIndex < Map.GetLength(1); heightIndex++)
                {
                    if (colorIndex != Map[flaskIndex, heightIndex])
                        return false;
                }
            }
            return true;
        }

        public void Exit()
        {
            var service = SceneControlService.Instance;
            service.ChangeScene(service.MainMenuPrefab);
        }
        
        
        public void Restart()
        {
            var service = SceneControlService.Instance;
            service.ChangeScene(service.GameControllerPrefab);
        }
    }
}
