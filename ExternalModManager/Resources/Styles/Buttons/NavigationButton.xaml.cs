using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ExternalModManager.Resources.Styles.Buttons;

public class NavigationButton : RadioButton
{
    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof(ImageSource), typeof(ImageSource), typeof(NavigationButton));
    
    public ImageSource ImageSource
    {
        get => (ImageSource) GetValue(ImageSourceProperty);
        set => SetValue(ImageSourceProperty, value);
    }

    static NavigationButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationButton), new FrameworkPropertyMetadata(typeof(NavigationButton)));
    }
}