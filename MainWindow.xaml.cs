using System.Windows;

namespace AlterEgo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Next_Click(object sender, RoutedEventArgs e)
    {
        string gender;

        if (ManRadio.IsChecked == true)
        {
            gender = "man";
        }
        else if (WomanRadio.IsChecked == true)
        {
            gender = "woman";
        }
        else
        {
            MessageBox.Show("Сначала выбери персонажа!");
            return;
        }

        Hide();

        CharacterEditorWindow window = new CharacterEditorWindow(gender);
        window.Closed += (_, _) => Show();
        window.Show();
    }

    private void About_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(
            "Наш проект - это игра с переодеванием персонажей, в которой каждый может придумать любой образ! Для вас старались: Семес Полина, Жаворонкова Маргарита, Годунова Алёна.",
            "О проекте ALTER EGO");
    }

    private void Characters_Click(object sender, RoutedEventArgs e)
    {
        CharactersWindow window = new CharactersWindow
        {
            Owner = this
        };
        window.ShowDialog();
    }
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show(
            "Вы действительно хотите выйти из Alter Ego?",
            "Выход",
            MessageBoxButton.YesNo,
            MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            Application.Current.Shutdown();
        }
    }
}
