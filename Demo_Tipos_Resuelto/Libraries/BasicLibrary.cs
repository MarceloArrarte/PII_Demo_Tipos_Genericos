using System.Collections;

namespace Demo_Tipos_Start;

public class BasicLibrary
{
    private ArrayList items = new ArrayList();

    // OK, agregamos un objeto de tipo Media, sin importar si es Movie o Song.
    // Tanto Movie como Song implementan el tipo Media, y en ambos casos hacemos lo
    // mismo, así que utilizamos un solo médico.
    public void Add(Media item)
    {
        items.Add(item);
    }
    
    // OK, todos los objetos con el tipo Media tienen un método get Genre,
    // así que es sencillo filtrar por ese atributo
    public ArrayList GetMediaByGenre(string genre) 
    { 
        ArrayList result = new ArrayList(); 
 
        foreach (Media item in items) 
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

        foreach (Media item in this.items) 
        { 
            if (item.IsFavorite()) 
            { 
                result.Add(item); 
            } 
        } 

        return result; 
    }
    
    // Problemas!!
    // No todos los objetos que implementan Media implementan Movie, si quiero hacer algo
    // específico para Movies, no es tan sencillo
    public ArrayList GetMoviesByActor(string actor) 
    { 
        ArrayList result = new ArrayList(); 

        foreach (Media item in this.items) 
        {
            // El tipo Media no define una operación Acts (esta está definida en el tipo Movie),
            // así que esto no compila.
            // if (item.Acts(actor))
            // {
            //     result.Add(item);
            // }
            
            // Podemos hacer typecast de los items a Movie, obligando al compilador a creer
            // que todos los objetos en items son películas... pero en tiempo de ejecución un item que no
            // implemente el tipo Movie (es decir, una canción) no va a tener implementada la operación "Acts"
            // generando un error.
            // if (((Movie) item).Acts(actor))
            // {
            //     result.Add(item);
            // }

            // Una posibilidad es chequear en tiempo de ejecución si item implementa el tipo Movie,
            // pero no es muy feliz tener que estar chequeando tipos todo el tiempo. Además, hace que
            // el programa esté más acoplado y sea más difícil de modificar.
            // En resumen, siempre queremos evitar los if que se basen en el tipo de los objetos.
            if (item.GetType() == typeof(Movie) && ((Movie) item).Acts(actor))
            {
                result.Add(item);
            }
        } 

        return result; 
    }
}