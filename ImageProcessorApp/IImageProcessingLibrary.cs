namespace ImageProcessorApp
{
    public interface IImageProcessingLibrary
    {
        public Task<string> ProcessImage(byte[] imageContent);
    }
}
