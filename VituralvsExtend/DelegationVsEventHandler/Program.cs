﻿using System;

namespace CS009_Event
{

    internal class Program
    {
        /*
       Publisher là lớp phát đi sự kiện, bằng cách gọi
       một deleage trong phương thức Send
   */
        public class Publisher
        {
            public delegate void NotifyNews(object data);

            public event NotifyNews event_news;

            public void Send()
            {
                event_news?.Invoke("Co tin moi");
            }
        }

        // SubscriberA lớp này đăng ký nhận sự kiện từ Publisher,
        // bằng phương thức Sub, khi sự kiện xảy ra nó sẽ gọi ReceiverFromPublisher
        public class SubscriberA
        {
            public void Sub(Publisher p)
            {
                p.event_news += ReceiverFromPublisher;
            }

            void ReceiverFromPublisher(object data)
            {
                Console.WriteLine("SubscriberA: " + data.ToString());
            }
        }

        // SubscriberA lớp này đăng ký nhận sự kiện từ Publisher,
        // bằng phương thức Sub - khi đăng ký nó hủy việc nhận sự kiện của các đối tượng khác,
        // khi sự kiện xảy ra nó sẽ gọi ReceiverFromPublisher
        public class SubscriberB
        {
            public void Sub(Publisher p)
            {
               // p.event_news = null;  // Hủy các đối tượng khác nhận sự kiện
                p.event_news += ReceiverFromPublisher;
            }

            void ReceiverFromPublisher(object data)
            {
                Console.WriteLine("SubscriberB: " + data.ToString());
            }

            static void Main(string[] args)
            {
                //Console.WriteLine(SubscriberBHelpers.Value);
               
            }
        }

        static void TestDelegate()
        {
            Publisher p = new Publisher();
            SubscriberA sa = new SubscriberA();
            SubscriberB sb = new SubscriberB();

            sa.Sub(p);
            sb.Sub(p);

            p.Send();
        }

        static void Main(string[] args) { 
            TestDelegate();
        }
    }

}