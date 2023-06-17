using controlWork_9.Enums.File;

namespace controlWork_9.Services.FilesServices.Abstracts;

public interface IImageProfile
{
    ImageType ImageType { get; }
    string Folder { get; }
    int Width { get; }
    int Height { get; }
    int MaxSizeBytes { get; }

    IEnumerable<string> AllowedExtensions { get; }
}