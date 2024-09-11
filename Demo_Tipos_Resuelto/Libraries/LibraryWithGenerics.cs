namespace Demo_Tipos_Start;

public class LibraryWithGenerics
{
    private List<Media> allItems = new List<Media>();
    private LibraryShelf<Movie> movies = new LibraryShelf<Movie>(1);
    private LibraryShelf<Song> songs = new LibraryShelf<Song>(2);

    // Como queremos evitar el chequeo de tipos, sobrecargaremos dos métodos Add.
    // En cada uno, agregamos la referencia tanto al ArrayList específico, como
    // al de todo el contenido de la biblioteca
    public void Add(Movie movie)
    {
        movies.Add(movie);
        allItems.Add(movie);
    }

    public void Add(Song song)
    {
        songs.Add(song);
        allItems.Add(song);
    }
    
    // OK, todos los objetos con el tipo Media tienen un método get Genre,
    // así que es sencillo filtrar por ese atributo
    public List<Media> GetMediaByGenre(string genre) 
    { 
        List<Media> result = new List<Media>(); 
 
        foreach (Media item in allItems) 
        { 
            if (item.Genre == genre) 
            { 
                result.Add(item); 
            } 
        } 

        return result; 
    } 
    
    // OK, todos los objetos con el tipo media tienen el método IsFavorite()
    public List<Media> GetFavorites() 
    { 
        List<Media> result = new List<Media>(); 
 
        foreach (Media item in allItems) 
        { 
            if (item.IsFavorite()) 
            { 
                result.Add(item); 
            } 
        } 

        return result; 
    }

    public void ShowFavoritesByShelf()
    {
        movies.ShowFavoritesInShelf();
        Console.WriteLine();
        songs.ShowFavoritesInShelf();
    }
    
    // Ahora que usamos tipos genéricos para las listas de películas y canciones,
    // podemos usar movies con total tranquilidad, porque es imposible agregarle
    // algo que no implemente el tipo Movie.
    public List<Movie> GetMoviesByActor(string actor) 
    { 
        List<Movie> result = new List<Movie>(); 

        foreach (Movie movie in movies) 
        {
            if (movie.Acts(actor))
            {
                result.Add(movie);
            }
        } 

        return result; 
    }
}