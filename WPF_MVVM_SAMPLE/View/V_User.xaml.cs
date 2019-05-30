using System.Windows.Controls;

namespace WPF_MVVM_SAMPLE.View
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class V_User : UserControl
    {
        private readonly ViewModel.VM_User _viewModel = new ViewModel.VM_User();

        public V_User()
        {
            InitializeComponent();
            // The DataContext serves as the starting point of Binding Paths
            DataContext = _viewModel;
        }
    }
}
