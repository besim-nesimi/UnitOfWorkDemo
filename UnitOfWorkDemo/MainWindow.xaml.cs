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
        }

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
    }
}
