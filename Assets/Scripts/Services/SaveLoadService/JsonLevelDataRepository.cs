using System.IO;
using UnityEditor.Overlays;
using UnityEngine;

namespace Services.SaveLoadService
{
    public class JsonLevelDataRepository : ISaveLoadRepository<LevelData>
    {
        public void Save(string path, LevelData data)
        {
            var json = JsonUtility.ToJson(data); 
            File.WriteAllText(path, json);    
        }

        public LevelData Load(string path)
        {
            if (!File.Exists(path)) return new LevelData();
            
            var json = File.ReadAllText(path);
            return JsonUtility.FromJson<LevelData>(json);
        }
    }
}