
if (args.Length is 0)
{
    Console.WriteLine("Usage: AmazonParser path-to-file");
    return;
}

if (File.Exists(@".\songs.csv"))
{
    Console.WriteLine("songs.csv file already exists. Do you want to delete it?\n[Press Y to delete]");
    if (Console.ReadKey().Key == ConsoleKey.Y)
        File.Delete(@".\songs.csv");
    else
        return;
}

string[] content = File.ReadAllLines(args[0]);
List<Song> songs = new List<Song>();
bool hasTrackNumbers = false;

// Detect a copy\paste operation that has a track number
if (int.TryParse(content[0], out _) && int.TryParse(content[6], out _))
    hasTrackNumbers = true;

int counter = 0;
int fileOffset = hasTrackNumbers ? 6 : 5;

int indexTitle = hasTrackNumbers ? 1 : 0;
int indexArtist = hasTrackNumbers ? 3 : 2;
int indexAlbum = hasTrackNumbers ? 4 : 3;
int indexLength = hasTrackNumbers ? 5 : 4;

for (int i = 0; i < content.Length;)
{
    if (string.IsNullOrWhiteSpace(content[i]))
    {
        i += 1;
        continue;
    }

    string title = content[indexTitle + i];
    string artist = content[indexArtist + i];
    string album = content[indexAlbum + i];
    string length = content[indexLength + i];

    songs.Add(new Song(++counter, title, artist, album, length));
    i += fileOffset;
}

using var stream = File.OpenWrite(@".\songs.csv");
using var writer = new StreamWriter(stream);

// Write header
writer.WriteLine("Number,Title,Artist,Album,Length");
// Write each song
foreach (Song song in songs)
{
    writer.WriteLine($"{song.Number},\"{song.Title}\",\"{song.Artist}\",\"{song.Album}\",{song.Length}");
}

record Song(int Number, string Title, string Artist, string Album, string Length);
