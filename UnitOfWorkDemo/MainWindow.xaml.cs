using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UnitOfWorkDemo.Data;
using UnitOfWorkDemo.Models;
using UnitOfWorkDemo.Services;

namespace UnitOfWorkDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClearUi()
        {
            txtRankGrade.Clear();
            txtRankTitle.Clear();
            txtCrewFirstName.Clear();
            txtCrewLastName.Clear();
        }

        // Add rank with repo pattern
        private async void btnAddRank_Click(object sender, RoutedEventArgs e)
        {

            string rankTitle = txtRankTitle.Text;
            bool success = int.TryParse(txtRankGrade.Text, out int rankGrade); // if sats behövs här.

            if (success)
            {
                using (AppDbContext context = new())
                {
                    await new RankRepository(context).AddRankAsync(new Rank()
                    {
                    Title = rankTitle,
                    Grade = rankGrade
                    });

                    await context.SaveChangesAsync();
                }

                ClearUi();
            }
            else
            {
                MessageBox.Show("Warning");
            }


        }

        // Add crew member with unit of work pattern ( unit of work in action )

        private void btnAddCrewMember_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtCrewFirstName.Text;
            string lastName = txtCrewLastName.Text;

            using(AppDbContext context = new()) // alltid skapar vi ett kontext
            {
                UnitOfWork uow = new(context); // Behöver instansiera unitofwork för att den ska finnas / funka

                Rank? privateRank = uow.RankRepo.GetRankByTitle("Private"); // kan returna null, så vi lägger ? efter Rank objekt.

                if (privateRank != null) // null check, vi kör nedan om privateRank inte är null.
                {
                    uow.CrewRepo.AddCrew(new Crew() // AddCrew metoden tar emot ett objekt med en "crew" variabel som är själva medlemmen. Vår crew medlem har First & Last + Rank som ej får vara null.
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Rank = privateRank // Eftersom ranken finns i Rank Modellen och Rank Repon, hämtar vi GetRankByTitle o.s.v.
                    });
                }

                uow.SaveChanges(); // Sparar ändringarna i vår kontext.
                ClearUi();
            }

            
        }
    }
}
