using controlWork_9.Enums.File;

namespace controlWork_9.Services.FilesServices.Abstracts;

public interface IFileService
{
    public bool FileValid(IFormFile uploadedFile, ImageType imageType);
    public string SaveImage(IFormFile uploadedFile, ImageType imageType);
    public string GetPrimalImgPath();
}