namespace ImageProcessorApp
{
    public interface IFileStorageLibrary
    {
        public  Task<bool> SaveContentIntoFile(string filePath, string content);
    }
}
