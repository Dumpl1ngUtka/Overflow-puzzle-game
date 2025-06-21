using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace Services.SaveLoadService
{
    public class CsvLevelDataRepository : ISaveLoadRepository<LevelData>
    {
        /*private readonly string _path;
        private Dictionary<int, LevelData> _cache;

        public CsvLevelDataRepository(string path)
        {
            _path = path;
            InitCache(path);
        }

        public void UpdateData(string path, int index, LevelData data)
        {
            _cache[index] = data;
        }

        public void Save(string path, LevelData data)
        {
            var linesToSave = new List<string>();

            for (var i = 0; i < _cache.Count; i++)
            {
                var line = _cache.TryGetValue(i, out var levelData)?
                    $"{levelData.FlaskCount};{levelData.FlaskHeight}" : "-1;-1";
                
                linesToSave.Add(line);
            }

            var fileContent = string.Join("\n", linesToSave);

            try
            {
                File.WriteAllText(_path, fileContent);
            }
            catch (Exception e)
            {
                Debug.LogError($"Ошибка при сохранении файла: {e.Message}");
            }
        }

        public LevelData Load(string path)
        {
            //return _cache.TryGetValue(index, out var result)
                //? result
                //: new LevelData(-1, -1, -1);
                return new LevelData();
        }

        public LevelData[] LoadAll(string path)
        {
            return _cache.Values.ToArray();
        }

        private void InitCache(string path)
        {
            _cache = new Dictionary<int, LevelData>();
            var dataset = Resources.Load<TextAsset>(path);

            var dataLines = dataset.text.Split('\n');
            for (var index = 0; index < dataLines.Length; index++)
            {
                var line = dataLines[index].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                var data = line.Split(';');
                if (data.Length < 2)
                    continue;

                if (int.TryParse(data[0], out var starCount) && int.TryParse(data[1], out var moveGoal))
                    _cache[index] = new LevelData(index, starCount, moveGoal);                   
            }
        }*/
        public void Save(string path, LevelData data)
        {
            throw new NotImplementedException();
        }

        public LevelData Load(string path)
        {
            throw new NotImplementedException();
        }
    }
}