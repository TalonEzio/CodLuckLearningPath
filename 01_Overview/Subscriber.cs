namespace _01_Overview
{
    internal class Subscriber
    {
        public string Name { get; set; } = string.Empty;

        private EventHandler<NewVideoArgs>? _eventHandler;

        public void SubscribeDelegate(YoutubeChannel channel, Action<string> behaviorAction)
        {
            channel.NewVideoDelegate += (newVideoTitle) => behaviorAction(newVideoTitle);
        }

        public void CancelAllAndSubscribe(YoutubeChannel channel, Action<string> behaviorAction)
        {
            channel.NewVideoDelegate = (newVideoTitle) => behaviorAction(newVideoTitle);
        }

        public void SubscribeEvent(YoutubeChannel channel, Action<string> behaviorAction)
        {
            channel.NewVideoEvent += e => behaviorAction(e);

        }
        public void SubscribeForEventHandler(YoutubeChannel channel, Action<string> behaviorAction)
        {
            if (_eventHandler != null)
            {
                Console.WriteLine("Đã subscribe rồi,hãy huỷ đăng ký rồi đăng kí lại!");
                return;
            }

            _eventHandler = (_, newVideoArgs) =>
            {
                behaviorAction(newVideoArgs.Name);
            };
            channel.NewVideoEventHandler += _eventHandler;
        }

        public void UnsubscribeEvent(YoutubeChannel channel)
        {
            Console.WriteLine("Cannot unsubscribe 🤣");
        }

        public void UnsubscribeEventHandler(YoutubeChannel channel)
        {
            if (_eventHandler == null)
            {
                Console.WriteLine("Bạn chưa đăng ký mà!");
                return;
            }
            channel.NewVideoEventHandler -= _eventHandler;
            Console.WriteLine("Huỷ đăng ký thành công");
        }
    }
}