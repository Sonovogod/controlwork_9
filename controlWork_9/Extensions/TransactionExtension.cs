using controlWork_9.Models;
using controlWork_9.ViewModels.Providers;

namespace controlWork_9.Extensions;

public static class TransactionExtension
{
    public static List<ProviderViewModel> MapToPayProviderViewModels(this IEnumerable<Provider> providers)
    {
        return providers.Select(x => new ProviderViewModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}