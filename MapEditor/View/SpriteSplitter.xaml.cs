using System.Text.RegularExpressions;
using System.Windows;
using MapEditor.Model;
using MapEditor.ViewModel;

namespace MapEditor.View
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class SpriteSplitter : Window
    {
        public SpriteSplitterViewModel viewModel;
        public SpriteSplitter(SpriteSplitterModel model)
        {
            if(model != null) 
            {
                viewModel = new SpriteSplitterViewModel(model);
            }
            else
            {
                viewModel = new SpriteSplitterViewModel();
            }
            DataContext = viewModel;
            InitializeComponent();
        }

        private void AcceptOnlyNumbers(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var regex = new Regex("^[0-9]*$");
            e.Handled = !regex.IsMatch(e.Text);
        }

        private void PreviewSpriteSplit(object sender, RoutedEventArgs e)
        {
            viewModel.CreatePreviewTilemap();
        }
    }
}
