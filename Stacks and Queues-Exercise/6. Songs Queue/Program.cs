namespace _6._Songs_Queue
{
    /*You will be given a sequence of songs, separated by a comma and a single space. After that, you will be given 
commands until there are no songs enqueued. When there are no more songsin the queue print "No more songs!" 
and stop the program.
The possible commands are:
 "Play" - plays a song (removes it from the queue)

 "Add {song}" - adds the song to the queue, if it isn't contained already, otherwise print "{song} is 
already contained!"

 "Show" - prints all songs in the queue, separated by a comma and a white space (start from the first song in 
the queue to the last
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initialSongs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(initialSongs);
            while(songs.Any())
            {
                string[] command = Console.ReadLine().Split();
                string realCommand = command[0];
                if(realCommand == "Play")
                {
                    songs.Dequeue();
                    if(!songs.Any())
                    {
                        Console.WriteLine("No more songs!");
                        break;

                    }
                }else if(realCommand == "Add")
                {
                    string songToAdd = "";
                    for(int i = 1;i<command.Length;i++)
                    {
                        if (i == command.Length - 1)
                        {
                            songToAdd += ($"{command[i]}");
                            break;
                        }
                        songToAdd+= ($"{command[i]} ");
                    }
                    if(songs.Contains(songToAdd))
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songToAdd);
                    }

                }else if(realCommand == "Show")
                {
                    if (songs.Any())
                    {
                        Console.WriteLine(string.Join(", ", songs));
                    }
                    continue;
                }
            }
        }
    }
}