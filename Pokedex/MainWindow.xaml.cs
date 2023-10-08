using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using Pokedex.Models;
using Pokedex.Util;
using System.Collections.ObjectModel;
using System.Numerics;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Pokedex
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private PokemonRepository PokemonRepository { get; } = new();

        private void InitializeData()
        {
            PokemonRepository.GetPokemonRepository();
        }
        public MainWindow()
        {
            this.InitializeComponent();
            InitializeData();
        }

        
        SpringVector3NaturalMotionAnimation _springAnimation;

        private void CreateOrUpdateSpringAnimation(float finalValue)
        {
            if (_springAnimation == null)
            {
                Compositor _compositor = this.Compositor;
                _springAnimation = _compositor.CreateSpringVector3Animation();
                _springAnimation.Target = "Scale";
            }

            _springAnimation.FinalValue = new Vector3(finalValue);
        }

        private void element_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            // Scale up to 1.5
            CreateOrUpdateSpringAnimation(1.05f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }

        private void element_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            // Scale back down to 1.0
            CreateOrUpdateSpringAnimation(1.0f);

            (sender as UIElement).StartAnimation(_springAnimation);
        }
    }

    public class PokemonRepository
    {
        private Pokemon pokemon = new();
        private readonly PokeClient pokeClient = new();
        public ObservableCollection<Pokemon> PokemonItems { get; } = new();
        public async void GetPokemonRepository()
        {
            PokemonItems.Clear();
            for (int id = 1; id <= 300; id++)
            {
                pokemon = await pokeClient.GetPokemon(id.ToString());
                PokemonItems.Add(pokemon);
            }
        }
    }
}
