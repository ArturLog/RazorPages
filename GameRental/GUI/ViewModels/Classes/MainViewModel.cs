using System.Collections.ObjectModel;
using Domain.Entities;
using GUI.Commands;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GUI.ViewModels.Classes
{
    public enum EntityType
    {
        Game = 0,
        Genre = 1,
        User = 2
    }
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private readonly IServiceProvider _serviceProvider;
        private readonly ICrudRepository<Game> _gameRepository;
        private readonly ICrudRepository<Genre> _genreRepository;
        private readonly ICrudRepository<ApplicationUser> _userRepository;
        #endregion
        #region Properties
        private ObservableCollection<Game> games;
        public ObservableCollection<Game> Games
        {
            get => games;
            set
            {
                games = value;
                OnPropertyChanged(nameof(Games));
            }
        }
        private ObservableCollection<Genre> genres;
        public ObservableCollection<Genre> Genres
        {
            get => genres;
            set
            {
                genres = value;
                OnPropertyChanged(nameof(Genres));
            }
        }
        private ObservableCollection<ApplicationUser> users;
        public ObservableCollection<ApplicationUser> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private Genre selectedGenre;
        public Genre SelectedGenre
        {
            get => selectedGenre;
            set
            {
                selectedGenre = value;
                OnPropertyChanged(nameof(SelectedGenre));
            }
        }
        private int selectedEntity;
        public int SelectedEntity
        {
            get => selectedEntity;
            set
            {
                selectedEntity = value;
                OnPropertyChanged(nameof(SelectedEntity));
            }
        }
        private string gameTitle;
        public string GameTitle
        {
            get => gameTitle;
            set
            {
                gameTitle = value;
                OnPropertyChanged(nameof(GameTitle));
            }
        }
        private string gameDescription;
        public string GameDescription
        {
            get => gameDescription;
            set
            {
                gameDescription = value;
                OnPropertyChanged(nameof(GameDescription));
            }
        }

        private DateTime gameReleaseDate;
        public DateTime GameReleaseDate
        {
            get => gameReleaseDate;
            set
            {
                gameReleaseDate = value;
                OnPropertyChanged(nameof(GameReleaseDate));
            }
        }

        private string genreName;
        public string GenreName
        {
            get => genreName;
            set
            {
                genreName = value;
                OnPropertyChanged(nameof(GenreName));
            }
        }

        private string userEmail;
        public string UserEmail
        {
            get => userEmail;
            set
            {
                userEmail = value;
                OnPropertyChanged(nameof(UserEmail));
            }
        }

        private string userPassword;

        public string UserPassword
        {
            get => userPassword;
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        private int gameId;
        public int GameId
        {
            get => gameId;
            set
            {
                gameId = value;
                OnPropertyChanged(nameof(GameId));
            }
        }
        private int genreId;
        public int GenreId
        {
            get => genreId;
            set
            {
                genreId = value;
                OnPropertyChanged(nameof(GenreId));
            }
        }
        private string userId;
        public string UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }
        #endregion
        #region Commands
        private RelayCommand createCommand;
        public RelayCommand CreateCommand
        {
            get
            {
                return createCommand;
            }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand;
            }
        }
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand;
            }
        }
        #endregion

        public MainViewModel()
        {
            AssignCommands();
            _serviceProvider = new ServiceCollection()
                .AddInfrastructureServices()
                .BuildServiceProvider()
                .UpdateDatabase();
            _gameRepository = _serviceProvider.GetService<ICrudRepository<Game>>();
            _genreRepository = _serviceProvider.GetService<ICrudRepository<Genre>>();
            _userRepository = _serviceProvider.GetService<ICrudRepository<ApplicationUser>>();
            ReadAllItems();
        }
        private void AssignCommands()
        {
            createCommand = new RelayCommand(Create);
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }
        private async Task ReadAllItems()
        {
            Games = new ObservableCollection<Game>();
            Genres = new ObservableCollection<Genre>();
            Users = new ObservableCollection<ApplicationUser>();
            var gamesInDb = await _gameRepository.ReadAll();
            foreach (var game in gamesInDb)
            {
                Games.Add(game);
            }
            var genresInDb = await _genreRepository.ReadAll();
            foreach (var genre in genresInDb)
            {
                Genres.Add(genre);
            }
            var usersInDb = await _userRepository.ReadAll();
            foreach (var user in usersInDb)
            {
                Users.Add(user);
            }
        }
        private async Task ServiceCreate()
        {
            switch (SelectedEntity)
            {
                case (int)EntityType.Game:
                    var game = new Game
                    {
                        Title = GameTitle,
                        Description = GameDescription,
                        ReleaseDate = GameReleaseDate,
                        Genres = []
                    };
                    game.Genres.Add(SelectedGenre);
                    await _gameRepository.Create(game);
                    Games.Add(game);
                    break;
                case (int)EntityType.Genre:
                    var genre = new Genre
                    {
                        Name = GenreName
                    };
                    await _genreRepository.Create(genre);
                    Genres.Add(genre);
                    break;
                case (int)EntityType.User:
                    var user = new ApplicationUser
                    {
                        Email = UserEmail,
                        PasswordHash = UserPassword
                    };
                    await _userRepository.Create(user);
                    Users.Add(user);
                    break;
            }
            await ReadAllItems();
        }
        private async Task ServiceUpdate()
        {
            switch (SelectedEntity)
            {
                case (int)EntityType.Game:
                    var game = new Game
                    {
                        Id = GameId,
                        Title = GameTitle,
                        Description = GameDescription,
                        ReleaseDate = GameReleaseDate
                    };
                    game.Genres.Add(SelectedGenre);
                    await _gameRepository.Update(game);
                    Games.Add(game);
                    break;
                case (int)EntityType.Genre:
                    var genre = new Genre
                    {
                        Id = GenreId,
                        Name = GenreName
                    };
                    await _genreRepository.Update(genre);
                    Genres.Add(genre);
                    break;
                case (int)EntityType.User:
                    var user = new ApplicationUser
                    {
                        Id = UserId,
                        Email = UserEmail,
                        PasswordHash = UserPassword
                    };
                    await _userRepository.Update(user);
                    Users.Add(user);
                    break;
            }
            await ReadAllItems();
        }
        private async Task ServiceDelete()
        {
            switch (SelectedEntity)
            {
                case (int)EntityType.Game:
                    await _gameRepository.Delete(GameId);
                    break;
                case (int)EntityType.Genre:
                    await _genreRepository.Delete(GenreId);
                    break;
                case (int)EntityType.User:
                    await _userRepository.Delete(UserId);
                    break;
            }
            await ReadAllItems();
        }
        public void Create()
        {
            try
            {
               ServiceCreate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Update()
        {
            try
            {
                ServiceUpdate();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public void Delete()
        {
            try
            {
                ServiceDelete();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
