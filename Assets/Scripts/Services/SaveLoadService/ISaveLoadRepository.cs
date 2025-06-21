namespace Services.SaveLoadService
{
    public interface ISaveLoadRepository<T>
    {
        public void Save(string path, T data);
        
        public T Load(string path);
    }
}