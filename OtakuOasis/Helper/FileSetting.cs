namespace OtakuOasis.Helper
{
    public static class FileSetting
    {
        public const  string ImagesPath = "/assets/AnimeImages";
        public const  string AllowedExtentions = ".jpg,.jpeg,.png";
        public const  int MaxFileSize = 1;

        public const  int MaxFileSizeInBytes = MaxFileSize * 1024 * 1024;
    }
}