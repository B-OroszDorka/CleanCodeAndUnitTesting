namespace ImageProcessorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var imageProcessor = new ImageProcessor(new ImageProcessingLibrary(), new FileStorageLibrary());
            try
            {
                var inputString = Path.Combine(Directory.GetCurrentDirectory(), "cat.jpg");
                var outputString = Directory.GetCurrentDirectory();

                imageProcessor.ProcessAndSaveImage(inputString, outputString).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                //logging
                throw new Exception($"The ProcessAndSaveImage function has failed: {ex.Message}");
            }
        }
    }
}
