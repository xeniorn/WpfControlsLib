using PropertyChanged;

namespace WpfControlsLibTester;

[AddINotifyPropertyChangedInterface]
public class MainWindowViewModel
{

    public MainWindowViewModel()
    {
        OldValue = 5;

        Val_AutoRound = 12345.12345;
        Val_Decimal      = 12345.12345  ;
Val_Sig          = 12345.12345  ;
Val_NoRound      = 12345.12345  ;
Val_Int          = 12345.12345  ;
Val_Text         = 12345.12345  ;


    }

    public double OldValue { get; set; }

    public double Val_AutoRound { get; set; }
    public double Val_Decimal { get; set; }
    public double Val_Sig { get; set; }
    public double Val_NoRound { get; set; }
    public double Val_Int { get; set; }
    public double Val_Text { get; set; }

    public object TextFromPopup { get; set; }
}
