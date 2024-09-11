using System.Collections;

namespace Demo_Tipos_Start;

public class LibraryWithSeparateArrayLists
{
    private ArrayList allItems = new ArrayList();
    private ArrayList movies = new ArrayList();
    private ArrayList songs = new ArrayList();

    // Como queremos evitar el chequeo de tipos, sobrecargaremos dos métodos Add.
    // En cada uno, agregamos la referencia tanto al ArrayList específico, como
    // al de todo el contenido de la biblioteca.
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
    public ArrayList GetMediaByGenre(string genre) 
    { 
        ArrayList result = new ArrayList(); 
 
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
    public ArrayList GetFavorites() 
    { 
        ArrayList result = new ArrayList(); 
 
        foreach (Media item in allItems) 
        { 
            if (item.IsFavorite()) 
            { 
                result.Add(item); 
            } 
        } 

        return result; 
    }
    
    // Ahora que tenemos separadas las películas, podemos iterar sin chequear el
    // tipo de los elementos en movies.
    // Pero todavía tenemos un problema: por un error de programación, por ejemplo por copiar y pegar,
    // podríamos colocar sin querer una canción en la lista de películas, y volveríamos a tener el mismo
    // problema (probar en el método Add(Song) agregar la canción a movies en vez de a songs).
    // Entonces, ¿cómo le decimos al compilador con qué tipo de elementos queremos trabajar en cada lista?
    public ArrayList GetMoviesByActor(string actor) 
    { 
        ArrayList result = new ArrayList(); 

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