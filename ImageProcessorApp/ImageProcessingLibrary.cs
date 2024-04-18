namespace ImageProcessorApp
{
    public class ImageProcessingLibrary : IImageProcessingLibrary
    {
        public async Task<string> ProcessImage(byte[] imageContent)
        {
            return "Processed image content";
        }
    }
}
