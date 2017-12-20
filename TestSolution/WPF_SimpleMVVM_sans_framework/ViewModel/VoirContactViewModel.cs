using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Linq.Expressions;
using WpfMvvmSample.Model;
using WpfMvvmSample.ViewModel.Interface;
using WpfMvvmSample.FrameworkMvvm;
using System.Windows.Input;
using WpfMvvmSample.Model.Classes;
using WpfMvvmSample.Model.Services;

namespace WpfMvvmSample.ViewModel
{
    /// <summary>
    /// Voici le view model !
    /// C'est lui qui fait la liaison entre la vue et le modèle
    /// </summary>
    public class VoirContactViewModel : ObservableObject, IVoirContactViewModel
    {
        /// <summary>
        /// ID unique du contact
        /// </summary>
        private int? _ID = null;
        public int? ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }
        
        /// <summary>
        /// Nom de famille du contact
        /// </summary>
        private string _nom = null;
        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
                OnPropertyChanged("Nom");
            }
        }

        /// <summary>
        /// Prenom du contact
        /// </summary>
        private string _prenom = null;
        public string Prenom
        {
            get { return _prenom; }
            set
            {
                _prenom = value;
                OnPropertyChanged("Prenom");
            }
        }

        /// <summary>
        /// Age du contact
        /// Booléen nullable à trois états (null, true ou false)
        /// </summary>
        private int? _age = null;
        public int? Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        /// <summary>
        /// Sexe du contact
        /// Booléen nullable à trois états (null, true ou false)
        /// </summary>
        private bool? _homme = null;
        public bool? Homme
        {
            get { return _homme; }
            set
            {
                _homme = value;
                OnPropertyChanged("Homme");
            }
        }

        /// <summary>
        /// Définition de la commande permettant de charger le contact
        /// </summary>
        public ICommand ChargerContactCommand { get; private set; }


        /// <summary>
        /// Constructeur
        /// </summary>
        public VoirContactViewModel()
        {
            // on associe la commande ChargerContactCommand à la méthode ChargeContact
            ChargerContactCommand = new RelayCommand(ChargeContact);
        }

        

        /// <summary>
        /// Méthode pour charger un contact depuis le model (service contacts)
        /// On accède au service de façon très simple par un new, pas d'IOC ici...
        /// </summary>
        private void ChargeContact()
        {
            ServiceContact service = new ServiceContact();
            Contact Contact = service.Charger();

            if (Contact != null)
            {
                this.ID = Contact.ID;
                this.Nom = Contact.Nom;
                this.Prenom = Contact.Prenom;
                this.Age = Contact.Age;
                this.Homme = Contact.Homme;
            }
        }
    }
}
