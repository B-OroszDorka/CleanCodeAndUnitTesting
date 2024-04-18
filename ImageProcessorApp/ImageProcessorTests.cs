using ImageProcessorApp;
using Moq;
using Moq.Protected;
using Xunit;

namespace ImageProcessorApp
{
    public class ImageProcessorTests
    {
        readonly string _valiInputPath = "cat.jpg";
        readonly string _valiOutputPath = Directory.GetCurrentDirectory();

        readonly string _invalidInputPath = "randominput.jpg";
        readonly string _invalidOutputPath = "randompath";

        readonly string _pngInputPath = "cat2.png";

        readonly string _processedImage = "Processed image content";

        [Fact]
        public async Task ProcessAndSaveImage_ValidInput_SuccessfullyProcessedAndSaved()
        {
            var imageProcessingLibraryMock = new Mock<IImageProcessingLibrary>();
            imageProcessingLibraryMock.Setup(x => x.ProcessImage(It.IsAny<byte[]>()))
                .ReturnsAsync(_processedImage);

            var fileStorageLibraryMock = new Mock<IFileStorageLibrary>();
            fileStorageLibraryMock.Setup(x => x.SaveContentIntoFile(_valiOutputPath, _processedImage));

            var imageProcessor = new ImageProcessor(imageProcessingLibraryMock.Object, fileStorageLibraryMock.Object);

            // Act
            var result = await imageProcessor.ProcessAndSaveImage(_valiInputPath, _valiOutputPath);

            // Assert
            Assert.True(result);
            imageProcessingLibraryMock.Verify(x => x.ProcessImage(It.IsAny<byte[]>()), Times.Once);
            fileStorageLibraryMock.Verify(x => x.SaveContentIntoFile(_valiOutputPath, _processedImage), Times.Once);
        }

        [Fact]
        public async Task ProcessAndSaveImage_FileNotFoundException()
        {
            var imageProcessingLibraryMock = new Mock<IImageProcessingLibrary>();
            imageProcessingLibraryMock.Setup(x => x.ProcessImage(It.IsAny<byte[]>()))
                .ThrowsAsync(new FileNotFoundException("Input image file not found."));
            var fileStorageLibraryMock = new Mock<IFileStorageLibrary>();

            var imageProcessor = new ImageProcessor(imageProcessingLibraryMock.Object, fileStorageLibraryMock.Object);

            // Act and Assert
            await Assert.ThrowsAsync<FileNotFoundException>(() => imageProcessor.ProcessAndSaveImage(_invalidInputPath, _invalidOutputPath));
        }


        [Fact]
        public async Task ProcessAndSaveImage_InvalidImageException()
        {
            var imageProcessingLibraryMock = new Mock<IImageProcessingLibrary>();
            imageProcessingLibraryMock.Setup(x => x.ProcessImage(It.IsAny<byte[]>()))
                .ThrowsAsync(new InvalidImageException("Only .jpg file format is accepted."));

            var fileStorageLibraryMock = new Mock<IFileStorageLibrary>();

            var imageProcessor = new ImageProcessor(imageProcessingLibraryMock.Object, fileStorageLibraryMock.Object);

            // Act and Assert
            await Assert.ThrowsAsync<InvalidImageException>(() => imageProcessor.ProcessAndSaveImage(_pngInputPath, _invalidOutputPath));
        }

        [Fact]
        public async Task ProcessAndSaveImage_FileStorageException()
        {
            var imageProcessingLibraryMock = new Mock<IImageProcessingLibrary>();

            var fileStorageLibraryMock = new Mock<IFileStorageLibrary>();
            fileStorageLibraryMock.Setup(x => x.SaveContentIntoFile(It.IsAny<string>(), It.IsAny<string>()))
                .ThrowsAsync(new FileStorageException("Error saving processed image.", new Exception()));

            var imageProcessor = new ImageProcessor(imageProcessingLibraryMock.Object, fileStorageLibraryMock.Object);

            // Act and Assert
            await Assert.ThrowsAsync<FileStorageException>(() => imageProcessor.ProcessAndSaveImage(_valiInputPath, _invalidOutputPath));
        }
    }
}