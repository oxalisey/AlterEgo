using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AlterEgo
{
    public class ChoiceOption
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public ChoiceOption(string name)
        {
            Name = name;
            IsSelected = false;
        }
    }

    public class CharacterDraft
    {
        public string Name { get; set; }
        public string AdditionalInfo { get; set; }

        public System.Collections.Generic.List<string> Traits { get; set; }
        public System.Collections.Generic.List<string> Subcultures { get; set; }
        public System.Collections.Generic.List<string> Hobbies { get; set; }
    }

    public partial class CharacterDetailsWindow : Window
    {
        public CharacterDraft CharacterData { get; private set; }

        public ObservableCollection<ChoiceOption> Traits { get; set; }
        public ObservableCollection<ChoiceOption> Subcultures { get; set; }
        public ObservableCollection<ChoiceOption> Hobbies { get; set; }

        public CharacterDetailsWindow()
        {
            InitializeComponent();

            Traits = new ObservableCollection<ChoiceOption>
            {
                new ChoiceOption("Спокойный"),
                new ChoiceOption("Дерзкий"),
                new ChoiceOption("Замкнутый"),
                new ChoiceOption("Общительный"),
                new ChoiceOption("Мечтательный"),
                new ChoiceOption("Ироничный"),
                new ChoiceOption("Амбициозный"),
                new ChoiceOption("Добрый"),
                new ChoiceOption("Импульсивный")
            };

            Subcultures = new ObservableCollection<ChoiceOption>
            {
                new ChoiceOption("Гот"),
                new ChoiceOption("Эмо"),
                new ChoiceOption("Панк"),
                new ChoiceOption("Гранж"),
                new ChoiceOption("Хиппи"),
                new ChoiceOption("Рокер"),
                new ChoiceOption("Киберпанк"),
                new ChoiceOption("Альт")
            };

            Hobbies = new ObservableCollection<ChoiceOption>
            {
                new ChoiceOption("Музыка"),
                new ChoiceOption("Рисование"),
                new ChoiceOption("Фотография"),
                new ChoiceOption("Чтение"),
                new ChoiceOption("Видеоигры"),
                new ChoiceOption("Спорт"),
                new ChoiceOption("Танцы"),
                new ChoiceOption("Путешествия"),
                new ChoiceOption("Программирование")
            };

            TraitsList.ItemsSource = Traits;
            SubculturesList.ItemsSource = Subcultures;
            HobbiesList.ItemsSource = Hobbies;
        }

        private void AddCustomOption(
            ObservableCollection<ChoiceOption> collection,
            System.Windows.Controls.TextBox input)
        {
            string value = input.Text.Trim();

            if (string.IsNullOrWhiteSpace(value))
                return;

            bool alreadyExists = collection.Any(
                option => option.Name.ToLower() == value.ToLower());

            if (!alreadyExists)
            {
                collection.Add(new ChoiceOption(value)
                {
                    IsSelected = true
                });
            }

            input.Clear();
        }

        private void AddTrait_Click(object sender, RoutedEventArgs e)
        {
            AddCustomOption(Traits, CustomTraitInput);
        }

        private void AddSubculture_Click(object sender, RoutedEventArgs e)
        {
            AddCustomOption(Subcultures, CustomSubcultureInput);
        }

        private void AddHobby_Click(object sender, RoutedEventArgs e)
        {
            AddCustomOption(Hobbies, CustomHobbyInput);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameInput.Text))
            {
                MessageBox.Show(
                    "Сначала введи имя персонажа.",
                    "Alter Ego",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            CharacterData = new CharacterDraft
            {
                Name = NameInput.Text.Trim(),

                AdditionalInfo = AdditionalInfoInput.Text.Trim(),

                Traits = Traits
                    .Where(option => option.IsSelected)
                    .Select(option => option.Name)
                    .ToList(),

                Subcultures = Subcultures
                    .Where(option => option.IsSelected)
                    .Select(option => option.Name)
                    .ToList(),

                Hobbies = Hobbies
                    .Where(option => option.IsSelected)
                    .Select(option => option.Name)
                    .ToList()
            };
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Ты действительно хочешь выйти из приложения?",
                "Alter Ego",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
    }
}