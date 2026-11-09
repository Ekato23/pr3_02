using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SnakeWPF.Pages
{
    /// <summary>
    /// Interaction logic for EndGame.xaml
    /// </summary>
    public partial class EndGame : Page
    {
        public EndGame()
        {
            InitializeComponent();
            name.Content = MainWindow.mainWindow.ViewModelUserSettings.Name;
            top.Content = MainWindow.mainWindow.ViewModelGames.Top;
            int myId = MainWindow.mainWindow.ViewModelGames.IdSnake;
            var mySnake = MainWindow.mainWindow.ViewModelGames.SnakesPlayers
                .FirstOrDefault(s => s.IdSnake == myId);

            if (mySnake != null)
            {
                glasses.Content = $"{mySnake.Points.Count - 3} glasses";
            }
            else
            {
                glasses.Content = "0 glasses";
            }

            MainWindow.mainWindow.receivingUdpClient.Close();
            MainWindow.mainWindow.tRec.Abort();
            MainWindow.mainWindow.ViewModelGames = null;
        }

        private void OpenHome(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.OpenPage(MainWindow.mainWindow.Home);
        }
    }
}