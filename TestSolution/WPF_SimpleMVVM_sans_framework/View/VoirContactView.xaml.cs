using System;
using System.Collections.Generic;
using System.Linq;
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
using WpfMvvmSample.ViewModel;
using WpfMvvmSample.ViewModel.Interface;

namespace WpfMvvmSample.View
{
    /// <summary>
    /// Voici la vue !
    /// Elle ne sert qu'à afficher les données en utilisant la puissance du binding
    /// C'est les données du view model qui vont être bindée au DataContext de cette vue
    /// </summary>
    public partial class VoirContactView : Window
    {
        public VoirContactView()
        {
            InitializeComponent();

            // plus le code behind de cette vue reste vide le mieux c'est !
        }
    }
}
