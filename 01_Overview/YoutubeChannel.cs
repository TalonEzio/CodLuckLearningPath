namespace _01_Overview
{

    public class YoutubeChannel
    {
        public delegate void PublishNewVideoDelegate(string newVideoTitle);

        public string Name { get; set; } = string.Empty;
        public PublishNewVideoDelegate? NewVideoDelegate;

        public event PublishNewVideoDelegate? NewVideoEvent;
        public void PublishNewVideo(string newVideoTitle)
        {
            Console.WriteLine($"{Name} đã đăng tải video {newVideoTitle}");

            NewVideoDelegate?.Invoke(newVideoTitle);
        }

        public void PublishNewVideoForEvent(string newVideoTitle)
        {
            NewVideoEvent?.Invoke(newVideoTitle);

        }

        public void PublishNewVideoForEventHandler(string newVideoTitle)
        {
            NewVideoEventHandler?.Invoke(this, new NewVideoArgs()
            {
                Name = newVideoTitle
            });

        }

        public EventHandler<NewVideoArgs>? NewVideoEventHandler;
    }

    public class NewVideoArgs : EventArgs
    {
        public string Name { get; set; } = string.Empty;
        public DateTime Release { get; set; } = DateTime.Now;
    }
}
