using System;

namespace Helpers
{
    public static class LevelPresetCalculator
    {
        private const int BaseFlaskCount = 4;
        private const int BaseFlaskHeight = 4;
        private const int MaxFlaskAdditionCount = 3;
        private const int MaxFlaskAdditionHeight = 6;

        public static LevelParameters GetLevelPresetById(int levelIndex)
        {
            return new LevelParameters(
                GetHash(levelIndex),
                GetFlaskCount(levelIndex),
                GetFlaskHeight(levelIndex));
        }

        private static int GetHash(int levelIndex)
        {
            return levelIndex + 10;
        }

        private static int GetFlaskCount(int levelIndex)
        {
            return BaseFlaskCount + Math.Clamp(levelIndex / 7, 0, MaxFlaskAdditionCount);
        }

        private static int GetFlaskHeight(int levelIndex)
        {
            return BaseFlaskHeight + Math.Clamp(levelIndex / 5, 0, MaxFlaskAdditionHeight);
        }
    }
}