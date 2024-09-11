namespace Demo_Tipos_Start;

public class Movie : Media
{
    private string[] actors;

    private string name;
    public string Name
    {
        get { return name; }
    }

    private string genre;
    public string Genre
    {
        get { return genre; }
    }

    public Movie(string name, string genre, string[] actors) 
    { 
        this.name = name; 
        this.genre = genre; 
        this.actors = actors; 
    }
    
    public bool IsFavorite()
    {
        return Acts("Tom Hanks");
    }

    public bool Acts(string actor)
    {
        return Array.IndexOf(this.actors, actor) >= 0; 
    }

    public override string ToString()
    {
        return $"{name} ({genre}), actúan: {string.Join(", ", actors)}";
    }
}