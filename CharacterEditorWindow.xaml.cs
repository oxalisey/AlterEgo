using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AlterEgo
{
    public partial class CharacterEditorWindow : Window
    {
        public CharacterEditorWindow(string gender)
        {
            InitializeComponent();

            if (gender == "man")
            {
                CharacterImage.Source =
                    new BitmapImage(new Uri("Images/man.jpg",
                    UriKind.Relative));
            }
            else
            {
                CharacterImage.Source =
                    new BitmapImage(new Uri("Images/woman.jpg",
                    UriKind.Relative));
            }
        }

        private void Tops_Click(object sender, RoutedEventArgs e)
        {
            CategoryInfo.Text =
                "Верхняя одежда\n\nПока здесь нет предметов. Добавим их позже.";
        }

        private void Bottoms_Click(object sender, RoutedEventArgs e)
        {
            CategoryInfo.Text =
                "Нижняя одежда\n\nПока здесь нет предметов. Добавим их позже.";
        }

        private void Shoes_Click(object sender, RoutedEventArgs e)
        {
            CategoryInfo.Text =
                "Обувь\n\nПока здесь нет предметов. Добавим их позже.";
        }

        private void Accessories_Click(object sender, RoutedEventArgs e)
        {
            CategoryInfo.Text =
                "Аксессуары\n\nПока здесь нет предметов. Добавим их позже.";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}