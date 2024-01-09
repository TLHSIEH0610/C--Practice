

namespace cookbook.Files
{
    public class FileMetadata
    {
        public string Name { get; }
        public FileFormat Format { get; }

        public FileMetadata(string name, FileFormat format)
        {
            Name = name;
            Format = format;
        }

        public string ToPath() => $"{Name}.{Format.AsFileExtension()}";
    }

    public enum FileFormat
    {
        Json,
        Txt
    }

    public static class FileFormatExtensions
    {
        public static string AsFileExtension(this FileFormat fileFormat) =>
            fileFormat == FileFormat.Json ? "json" : "txt";
    }





}
