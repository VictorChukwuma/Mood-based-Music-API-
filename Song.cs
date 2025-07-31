namespace MoodBasedPlaylistApi.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public string Mood { get; set; }

        public static readonly string[] ValidMoods = new string[] { "Happy", "Sad", "Energetic", "Relaxing" };

        public bool IsValidMood()
        {
            return ValidMoods.Contains(Mood);
        }
    }
}
