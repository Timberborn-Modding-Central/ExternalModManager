using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ExternalModManager.Controls;

public partial class ModIOGalleryItem : UserControl
{
  public ModIOGalleryItem()
  {
    InitializeComponent();
  }

  private void InitializeComponent()
  {
    AvaloniaXamlLoader.Load(this);
  }
}