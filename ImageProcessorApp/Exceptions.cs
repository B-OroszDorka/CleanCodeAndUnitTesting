namespace ImageProcessorApp
{
    public class InvalidImageException : Exception
    {
        public InvalidImageException(string message) : base(message) { }
    }

    public class ProcessingErrorException : Exception
    {
        public ProcessingErrorException(string message, Exception? innerException) : base(message, innerException) { }
    }

    public class FileStorageException : Exception
    {
        public FileStorageException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
