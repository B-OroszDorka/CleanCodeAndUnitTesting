namespace ImageProcessorApp
{
    public class ImageProcessor
    {
        private readonly IImageProcessingLibrary _imageProcessingLibrary;
        private readonly IFileStorageLibrary _fileStorageLibrary;

        public ImageProcessor(IImageProcessingLibrary imageProcessingLibrary, IFileStorageLibrary fileStorageLibrary)
        {
            _imageProcessingLibrary = imageProcessingLibrary ?? throw new ArgumentNullException(nameof(imageProcessingLibrary));
            _fileStorageLibrary = fileStorageLibrary ?? throw new ArgumentNullException(nameof(fileStorageLibrary));
        }

        public async Task<bool> ProcessAndSaveImage(string inputPath, string outputPath)
        {
            ValidateInputPath(inputPath);
            ValidateImageFormat(inputPath);

            var processedImage = await ProcessImage(inputPath);
            await SaveProcessedImage(outputPath, processedImage);
            return true;
        }

        private void ValidateInputPath(string inputPath)
        {
            if (!File.Exists(inputPath))
            {
                throw new FileNotFoundException("Input image file not found.", inputPath);
            }
        }

        private void ValidateImageFormat(string inputPath)
        {
            if (Path.GetExtension(inputPath) != ".jpg")
            {
                throw new InvalidImageException("Only .jpg file format is accepted.");
            }
        }

        private async Task<string> ProcessImage(string inputPath)
        {
            try
            {
                var imageBytes = await File.ReadAllBytesAsync(inputPath);
                var processedImage = await _imageProcessingLibrary.ProcessImage(imageBytes);
                return processedImage;
            }
            catch (Exception ex)
            {
                throw new ProcessingErrorException("Error processing image.", ex);
            }
        }

        private async Task<bool> SaveProcessedImage(string outputPath, string processedImage)
        {
            try
            {
                await _fileStorageLibrary.SaveContentIntoFile(outputPath, processedImage);
                return true;
            }
            catch (Exception ex)
            {
                throw new FileStorageException("Error saving processed image.", ex);
            }
        }

    }
}