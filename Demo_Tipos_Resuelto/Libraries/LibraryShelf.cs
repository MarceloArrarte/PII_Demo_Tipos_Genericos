using System.Collections;

namespace Demo_Tipos_Start;

// Definimos la clase como genérica, con un tipo parámetro T.
// Además, restringimos los tipos que podemos usar para T como aquellos que implementen el tipo Media (where T : Media).
// LibraryShelf<Media>, LibraryShelf<Song> y LibraryShelf<Movie> son ejemplos de tipos construidos válidos.
// Si intento usar por ejemplo LibraryShelf<Program>, no me lo va a permitir porque Program
// no implementa el tipo Media.
// Además, decimos que LibraryShelf<T> implementa el tipo IEnumerable<T>, que es lo que nos permite recorrer
// los items como si LibraryShelf<T> fuera un ArrayList con un foreach.
public class LibraryShelf<T> : IEnumerable where T : Media
{ 
    // El estante almacena internamente los items que tiene en una lista,
    // donde el tipo parámetro T es el mismo que el de la clase.
    private List<T> items = new List<T>();
    
    private int number;

    public int Number
    {
        get { return number; }
    }

    public LibraryShelf(int number)
    {
        this.number = number;
    }
 
    // El tipo de item que puedo agregar depende del tipo parámetro.
    // Por ejemplo, cuando uso LibraryShelf<Song>, la firma de este método se transforma en void Add(Song item).
    public void Add(T item) 
    { 
        this.items.Add(item); 
    }

    public void ShowFavoritesInShelf()
    {
        List<T> result = new List<T>(); 
 
        // Si bien en tiempo de compilación no conozco exactamente qué tipo es T, sé que
        // todos los elementos de items tendrán ese mismo tipo.
        // Es decir, que si estoy trabajando con un LibraryShelf<Movie>, ninguno de sus items
        // podría tener el tipo Song, porque el método Add no me permitiría agregarlo (pruébenlo)
        foreach (T item in items) 
        { 
            if (item.IsFavorite()) 
            { 
                result.Add(item); 
            } 
        } 

        Console.WriteLine($"Estante {number}");
        foreach (T item in result)   
        {
            Console.WriteLine(item);
        }
    }
 
    public IEnumerator GetEnumerator() 
    { 
        return this.items.GetEnumerator(); 
    }
}