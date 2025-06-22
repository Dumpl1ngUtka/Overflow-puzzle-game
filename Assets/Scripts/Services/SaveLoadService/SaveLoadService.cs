using System.IO;
using UnityEngine;

namespace Services.SaveLoadService
{
    public class SaveLoadService : MonoBehaviour
    {
        private static SaveLoadService _instance;
        private ISaveLoadRepository<LevelData> _levelLoader;
        private string _filePath;

        public static SaveLoadService Instance => 
            _instance ?? FindAnyObjectByType(typeof(SaveLoadService)) as SaveLoadService;
        
        public void Init(ISaveLoadRepository<LevelData> levelLoader)
        {
            _levelLoader = levelLoader;
            var saveDirectory = Path.Combine(Application.persistentDataPath, "Saves");
            
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
            
            _filePath = Path.Combine(saveDirectory, "Save.json");
        }
        
        public void SaveData(LevelData data) => _levelLoader.Save(_filePath, data);
        
        public LevelData LoadData() => _levelLoader.Load(_filePath); 
    }
}