// LOAD FROM JSON FILE DEMO by MR. V
// Demo of how to load data from a JSON file
using System;
#nullable disable

// Import JSON module
using System.Text.Json;

// Read data from file as a json string
string jsonString = File.ReadAllText("point-data.json");
string answer, logedinnm = "";
// The Deserialize method will convert a json string to data
List<User> users = JsonSerializer.Deserialize<List<User>>(jsonString);
List<Song> array = new List<Song>();
array.Add(new Song("Uptown Funk", "Funk", "Mark Ronsen"));
array.Add(new Song("Gods Country", "Country", "Blake Shelton"));
array.Add(new Song("Pop That", "Pop", "French Montana"));
array.Add(new Song("Its Only Rock N Roll", "Rock", "The Rolling Stones"));
array.Add(new Song("Paint it Black", "Rock", "The Rolling Stones"));
array.Add(new Song("Party Rock Anthem", "Rock", "LMFAO"));

bool egg = true, egg2 = false;
while (egg)
{
    Console.WriteLine("1. Login");
    Console.WriteLine("2. Sign Up");
    Console.WriteLine("3. Quit");
    answer = Console.ReadLine();
    if (answer == "1")
    {
        bool Username = false;
        Console.WriteLine("Input Username");
        string user = Console.ReadLine();
        Console.WriteLine("Input Password");
        string pass = Console.ReadLine();
        foreach (User userz in users)
        {
            if (userz.Name == user)
            {
                if (userz.Password == pass)
                {
                    logedinnm = user;
                    egg = false;
                    egg2 = true;
                }
                Username = true;
            }
        }
        if (egg)
        {
            if (Username)
            {
                Console.WriteLine("Incorrect Password");

            }
            Console.WriteLine("User Not Found");
        }
    }
    else if (answer == "2")
    {
        Console.WriteLine("Input New Username");
        string user = Console.ReadLine();
        Console.WriteLine("Input New Password");
        string pass = Console.ReadLine();
        Console.WriteLine("Confirm New Password");
        if (pass == Console.ReadLine())
        {
            Console.WriteLine("Success!");
            string jsonStringz = "[";
            foreach (User useri in users)
            {
                jsonStringz += JsonSerializer.Serialize(useri);
                jsonStringz += ",";
            }
            User signup = new User(user, pass);
            jsonStringz += JsonSerializer.Serialize(signup);
            jsonStringz += "]";
            jsonString = jsonStringz;
            users.Add(signup);
            File.WriteAllText("point-data.json", jsonString);
        }
        else
        {
            Console.WriteLine("Incorrect Password");
        }
    }
    else if (answer == "3")
    {
        egg = false;
    }
}
while (egg2)
{

    Console.WriteLine("Welcome " + logedinnm);
    Console.WriteLine("1. Display All");
    Console.WriteLine("2. Filter");
    Console.WriteLine("3. Sort");
    Console.WriteLine("4. Favorite");
    Console.WriteLine("5. Remove Favorite");
    Console.WriteLine("6. Display Favorites");
    Console.WriteLine("7. Quit");
    answer = Console.ReadLine();
    if (answer == "1")
    {
        DisplayAll(array);
    }
    else if (answer == "2")
    {
        Console.WriteLine("Filter By");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Artist");
        Console.WriteLine("3. Genre");
        answer = Console.ReadLine();
        Console.WriteLine("Which one");
        string answerz = Console.ReadLine().ToLower();
        string combine;
        bool fail = true;
        if (answer == "1")
        {
            for (int i = 0; i < 5; i++)
            {
                if (array[i].Title.ToLower() == answerz)
                {
                    combine = array[i].Title + " | " + array[i].Genre + " | " + array[i].Artist;
                    Console.WriteLine(combine);
                    fail = false;
                }
            }
            if (fail)
            {
                Console.WriteLine("none match specifications");
            }
        }
        else if (answer == "2")
        {
            for (int i = 0; i < 5; i++)
            {
                if (array[i].Artist.ToLower() == answerz)
                {
                    combine = array[i].Title + " | " + array[i].Genre + " | " + array[i].Artist;
                    Console.WriteLine(combine);
                    fail = false;
                }
            }
            if (fail)
            {
                Console.WriteLine("none match specifications");
            }
        }
        else if (answer == "3")
        {
            for (int i = 0; i < 5; i++)
            {
                if (array[i].Genre.ToLower() == answerz)
                {
                    combine = array[i].Title + " | " + array[i].Genre + " | " + array[i].Artist;
                    Console.WriteLine(combine);
                    fail = false;
                }
            }
            if (fail)
            {
                Console.WriteLine("none match specifications");
            }
        }
    }
    else if (answer == "3")
    {
        Console.WriteLine("Sort By");
        Console.WriteLine("1. Title");
        Console.WriteLine("2. Artist");
        Console.WriteLine("3. Genre");
        answer = Console.ReadLine();
        if (answer == "1")
        {
            Song c;
            Song d;
            for (int b = 1; b < 5; b++)
            {
                for (int i = 0; i < 5 - b; i++)
                {
                    if (string.Compare(array[i].Title, array[i + 1].Title) > 0)
                    {
                        c = array[i];
                        d = array[i + 1];
                        array[i] = d;
                        array[i + 1] = c;
                    }
                }
            }
            Console.WriteLine("Sorted Songs!");
        }
        else if (answer == "2")
        {
            Song c;
            Song d;
            for (int b = 1; b < 5; b++)
            {
                for (int i = 0; i < 5 - b; i++)
                {
                    if (string.Compare(array[i].Artist, array[i + 1].Artist) > 0)
                    {
                        c = array[i];
                        d = array[i + 1];
                        array[i] = d;
                        array[i + 1] = c;
                    }
                }
            }
            Console.WriteLine("Sorted Songs!");
        }
        else if (answer == "3")
        {
            Song c;
            Song d;
            for (int b = 1; b < 5; b++)
            {
                for (int i = 0; i < 5 - b; i++)
                {
                    if (string.Compare(array[i].Genre, array[i + 1].Genre) > 0)
                    {
                        c = array[i];
                        d = array[i + 1];
                        array[i] = d;
                        array[i + 1] = c;
                    }
                }
            }
            Console.WriteLine("Sorted Songs!");
        }
    }
    else if (answer == "4")
    {
        Console.WriteLine("Favorite Which Song?");
        string antz = Console.ReadLine().ToLower();
        bool fail = true;
        foreach (User user in users)
        {
            if (user.Name == logedinnm)
            {
                for (int i = 0; i < array.Count; i++)
                {
                    if (antz == array[i].Title.ToLower())
                    {
                        user.Favorites.Add(array[i]);
                        Console.WriteLine("Success!");
                        RefreshJson(users, jsonString);
                        fail = false;
                    }
                }
                break;
            }
        }
        if (fail)
        {
            Console.WriteLine("Song Not Found");
        }
    }
    else if (answer == "5")
    {
        Console.WriteLine("Unfavorite Which Song?");
        string antz = Console.ReadLine().ToLower();
        bool fail = true;
        foreach (User user in users)
        {
            if (user.Name == logedinnm)
            {
                for (int i = 0; i < user.Favorites.Count; i++)
                {
                    if (antz == array[i].Title.ToLower())
                    {
                        user.Favorites.Remove(array[i]);
                        Console.WriteLine("Success");
                        fail = false;
                        RefreshJson(users, jsonString);
                    }
                }
                break;
            }
        }
        if (fail)
        {
            Console.WriteLine("Song Not Found");
        }

    }
    else if (answer == "6")
    {
        foreach (User user in users)
        {
            if (user.Name == logedinnm)
            {
                if (user.Favorites.Count > 0)
                {
                    for (int i = 0; i < user.Favorites.Count; i++)
                    {
                        DisplayAll(user.Favorites);
                    }
                }
                else
                {
                    Console.WriteLine("You have No Favorites");
                }

            }
        }

    }
    else if (answer == "7")
    {
        egg2 = false;
    }
}
static void RefreshJson(List<User> users, string jsonString)
{
    string jsonStringz = "[";
    int count = 0, c2 = 0;
    foreach (User useri in users)
    {
        count++;
    }
    foreach (User useri in users)
    {
        c2++;
        jsonStringz += JsonSerializer.Serialize(useri);
        if (c2 < count)
        {
            jsonStringz += ",";
        }
    }
    jsonStringz += "]";
    jsonString = jsonStringz;
    File.WriteAllText("point-data.json", jsonString);
}
static void DisplayAll(List<Song> az)
{
    string combine;
    for (int i = 0; i < az.Count; i++)
    {
        combine = az[i].Title + " | " + az[i].Genre + " | " + az[i].Artist;
        Console.WriteLine(combine);
    }
}
class User
{
    // Properties
    public string Name { get; set; }
    public string Password { get; set; }
    public List<Song> Favorites { get; set; }
    public User(string name, string password)
    {
        this.Name = name;
        this.Password = password;
        this.Favorites = new List<Song>();
    }
}
class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public Song(string title, string genre, string artist)
    {
        this.Title = title;
        this.Artist = artist;
        this.Genre = genre;
    }
}