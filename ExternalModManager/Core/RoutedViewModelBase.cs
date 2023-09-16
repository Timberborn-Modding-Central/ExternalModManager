using System;
using ReactiveUI;

namespace ExternalModManager.Core;

public class RoutedViewModelBase : ViewModelBase, IRoutableViewModel
{
    // Reference to IScreen that owns the routable view model.
    public IScreen HostScreen => null!;

    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);
}