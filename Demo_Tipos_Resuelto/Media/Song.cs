namespace Demo_Tipos_Start;

public class Song : Media
{
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

    private string artist;

    public string Artist
    {
        get { return artist;  }
    }
    
    public Song(string name, string genre, string artist) 
    { 
        this.name = name; 
        this.genre = genre; 
        this.artist = artist; 
    }

    public Boolean IsFavorite() 
    { 
        return genre == "Cumbia" || artist == "Luck Ra"; 
    }

    public override string ToString()
    {
        return $"{name} ({genre}) es de {artist}";
    }
}