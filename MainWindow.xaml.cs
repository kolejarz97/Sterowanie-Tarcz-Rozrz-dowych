using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace SterowanieTarczRozrzadowych;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    private enum SignalType
    {
        Rt1,
        Rt2,
        Rt3,
        Rt4,
        Rt5
    }
    
    private SignalType currentSignal = SignalType.Rt1;
    public MainWindow()
    {
        InitializeComponent();
        Rt1Button_Click(this, new RoutedEventArgs());
    }
    private void Rt1Button_Click(object sender, RoutedEventArgs e)
    {
        SignalPreview.Text= "Wybrano Rt 1 - Pchanie zabronione";
        ResetLamps();
        AnimateLamp(LampML, 1.0);
        AnimateLamp(LampMM, 1.0);
        AnimateLamp(LampMR, 1.0);
    }
    private void Rt2Button_Click(object sender, RoutedEventArgs e)
    {
        SignalPreview.Text= "Wybrano Rt 2 - Pchać powoli";
        ResetLamps();
        AnimateLamp(LampTR, 1.0);
        AnimateLamp(LampMM, 1.0);
        AnimateLamp(LampBL, 1.0);
    }
    private void Rt3Button_Click(object sender, RoutedEventArgs e)
    {
        SignalPreview.Text= "Wybrano Rt 3 - Pchać z umiarkowaną prędkością";
        ResetLamps();
        AnimateLamp(LampTM, 1.0);
        AnimateLamp(LampMM, 1.0);
        AnimateLamp(LampBM, 1.0);
    }
    private void Rt4Button_Click(object sender, RoutedEventArgs e)
    {
        SignalPreview.Text= "Wybrano Rt 4 - Cofnąć";
        ResetLamps();
        AnimateLamp(LampML, 1.0);
        AnimateLamp(LampMM, 1.0);
        AnimateLamp(LampBM, 1.0);
    }
    private void Rt5Button_Click(object sender, RoutedEventArgs e)
    {
        SignalPreview.Text= "Wybrano Rt 5 - Podepchnąć skład do górki";
        ResetLamps();
        FlashLamp(LampML);
        FlashLamp(LampMM);
        FlashLamp(LampMR);
    }
    private void ResetLamps()
    {
        AnimateLamp(LampTM, 0.55);
        AnimateLamp(LampTR, 0.55);
        AnimateLamp(LampML, 0.55);
        AnimateLamp(LampMM, 0.55);
        AnimateLamp(LampMR, 0.55);
        AnimateLamp(LampBL, 0.55);
        AnimateLamp(LampBM, 0.55);
    }
    private void AnimateLamp(UIElement lamp, double targetOpacity)
    {
        DoubleAnimation animation = new DoubleAnimation();
        animation.To = targetOpacity;
        animation.Duration = new Duration(TimeSpan.FromMilliseconds(300));

        ((IAnimatable)lamp).BeginAnimation(UIElement.OpacityProperty, animation);
    }
    private void FlashLamp(UIElement lamp)
    {
        DoubleAnimation animation = new DoubleAnimation();

        animation.From = 0.55;
        animation.To = 1.0;
        animation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
        animation.AutoReverse = true;
        animation.RepeatBehavior = RepeatBehavior.Forever;

        ((IAnimatable)lamp).BeginAnimation(UIElement.OpacityProperty, animation);
    }
}