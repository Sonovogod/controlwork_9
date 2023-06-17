using controlWork_9.Enums.File;
using controlWork_9.Services.FilesServices.Abstracts;

namespace controlWork_9.Services.FilesServices;

public class ImageProfile : IImageProfile
{
    public ImageProfile()
    {
        AllowedExtensions = new List<string>(){".jpg", ".jpeg", ".png"};
    }
    public ImageType ImageType => ImageType.Logo;
    private const int mb = 1048576;
    public string Folder => "Logo";
    public int Width => 110;
    public int Height => 110;
    public int MaxSizeBytes => 10 * mb;
    public IEnumerable<string> AllowedExtensions { get; }
}