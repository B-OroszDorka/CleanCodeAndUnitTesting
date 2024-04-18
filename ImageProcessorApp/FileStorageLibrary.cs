namespace ImageProcessorApp
{    public class FileStorageLibrary : IFileStorageLibrary
    {
        public async Task<bool> SaveContentIntoFile(string filePath, string content)
        {
            try
            {
                await File.WriteAllTextAsync(filePath, content);
                return true;
            }
            catch (Exception ex)
            {
                throw new FileStorageException("Error saving processed image.", ex);
            }
        }
    }
}
