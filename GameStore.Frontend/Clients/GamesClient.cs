using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games =
    [
        new() {Id = 1, Name = "Scooby-Doo: Unmasked", Genre = "Platforming", Price = 19.95M, ReleaseDate = new DateOnly(2006, 7, 11)},
        new() {Id = 2, Name = "Undertale", Genre = "RPG", Price = 19.95M, ReleaseDate = new DateOnly(2015, 7, 11)},
        new() {Id = 3, Name = "Pokémon Platinum", Genre = "RPG", Price = 19.95M, ReleaseDate = new DateOnly(2009, 7, 11)}
    ];

    private readonly GenresClient genresClient;

    public GamesClient(GenresClient genresClient)
    {
        ArgumentNullException.ThrowIfNull(genresClient);
        this.genresClient = genresClient;
    }

    public Genre[] GetGenres() => genresClient.GetGenres();

    //private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(game.GenreId);
        var genres = GetGenres();
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate,
        };

        games.Add(gameSummary);
    }
}
