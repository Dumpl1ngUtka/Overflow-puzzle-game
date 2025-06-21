using System;
using UnityEngine.Serialization;

namespace Services.SaveLoadService
{
    [Serializable]
    public struct LevelData
    {
        public int CurrentLevelIndex;
        
        public LevelData(int currentLevelIndex)
        {
            CurrentLevelIndex = currentLevelIndex;
        }
    }
}