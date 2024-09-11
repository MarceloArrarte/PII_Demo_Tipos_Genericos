using System.Collections;

namespace Demo_Tipos_Start;

public class Program
{
    private static List<Song> songs =
    [
        new Song("Que me falte todo", "Cuarteto", "Luck Ra"),
        new Song("Ciudad Mágica", "Rock", "Tan Bionica"),
        new Song("Mentira", "Trap", "Mesita")
    ];

    private static List<Movie> movies =
    [
        new Movie("Forrest Gump", "Comedia", ["Tom Hanks", "Robin Wright", "Gary Sinise"]),
        new Movie("En busca de la felicidad", "Drama", ["Will Smith", "Chris Gardner", "Jaden Smith"]),
        new Movie("Elvis", "Musical/Drama", ["Austin Butler", "Tom Hanks", "Olivia De Jonge"])
    ];
    
    public static void Main(string[] args)
    {
        RunBasicLibraryExample();
        Console.WriteLine();
        RunLibraryWithSeparateArrayListsExample();
        Console.WriteLine();
        RunLibraryWithGenericsExample();
    }

    private static void RunBasicLibraryExample()
    {
        Console.WriteLine("Clase: BasicLibrary");
        
        // Creamos la librería y agregamos todas las obras
        BasicLibrary library = new BasicLibrary();
        foreach (Song song in songs)
        {
            library.Add(song);
        }
        foreach (Movie movie in movies)
        {
            library.Add(movie);
        }
        
        // Obtenemos todas las películas de Tom Hanks y las mostramos
        ArrayList list = library.GetMoviesByActor("Tom Hanks");
        foreach (Media item in list)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();
    }


    private static void RunLibraryWithSeparateArrayListsExample()
    {
        Console.WriteLine("Clase: LibraryWithSeparateArrayLists");
        
        // Creamos la librería y agregamos todas las obras
        LibraryWithSeparateArrayLists library = new LibraryWithSeparateArrayLists();
        foreach (Song song in songs)
        {
            library.Add(song);
        }
        foreach (Movie movie in movies)
        {
            library.Add(movie);
        }
        
        // Obtenemos todas las películas de Tom Hanks y las mostramos
        ArrayList list = library.GetMoviesByActor("Tom Hanks");
        foreach (Media item in list)
        {
            Console.WriteLine(item.ToString());
        }
        Console.WriteLine();
    }


    private static void RunLibraryWithGenericsExample()
    {
        Console.WriteLine("Clase: LibraryWithGenerics");
        
        // Creamos la librería y agregamos todas las obras
        LibraryWithGenerics library = new LibraryWithGenerics();
        foreach (Song song in songs)
        {
            library.Add(song);
        }
        foreach (Movie movie in movies)
        {
            library.Add(movie);
        }
        
        // Llamamos a un método que accede a los atributos de tipo LibraryShelf<T>
        library.ShowFavoritesByShelf();
    }
}