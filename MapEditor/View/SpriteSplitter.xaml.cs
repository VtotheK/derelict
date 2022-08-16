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
        SpriteSplitterViewModel viewModel;
        public SpriteSplitter(SpriteSplitterModel model)
        {
            InitializeComponent();
            if(model != null) 
            {
                viewModel = new SpriteSplitterViewModel(model);
            }
            else
            {
                viewModel = new SpriteSplitterViewModel();
            }
            DataContext = viewModel;
        }
    }
}
