namespace CentralInovacao.Views;

public partial class ViewChamado : ContentPage
{
	public ViewChamado()
	{
		InitializeComponent();
	}
    void OnEditorTextChanged(object sender, TextChangedEventArgs e)
    {
        string oldText = e.OldTextValue;
        string newText = e.NewTextValue;
        string myText = _editor.Text;
    }
    void OnEditorCompleted(object sender, EventArgs e)
    {
        string text = ((Editor)sender).Text;
    }
}