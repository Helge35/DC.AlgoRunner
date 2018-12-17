using AlgoRunner.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgoRunner.Api.Dal
{
    public class MessagesRepository
    {

        public MessagesRepository()
        {
            _messages = new List<Message>
            {
                new Message{Id =1, UserName=@"DESKTOP-KM9M96J\Oleg",
                    Context =@"This is probably the last (at least for now) of my posts about push notifications. I've updated the demo project with support for features described here (and there is still couple things on the issues list to come in future).",
                CreateDate= new DateTime(2018, 10, 1), Title="Post1"},
                                new Message{Id =2, UserName=@"DESKTOP-KM9M96J\Oleg",
                    Context =@"This is probably the last (at least for now) of my posts about push notifications. I've updated the demo project with support for features described here (and there is still couple things on the issues list to come in future).",
                CreateDate= new DateTime(2018, 10, 2), Title="Post 2"},
                                                new Message{Id =3, UserName=@"DESKTOP-KM9M96J\Oleg",
                    Context =@"This is probably the last (at least for now) of my posts about push notifications. I've updated the demo project with support for features described here (and there is still couple things on the issues list to come in future).",
                CreateDate= new DateTime(2018, 10, 3), Title="Post 3"},
            };
        }

        List<Message> _messages;

        public List<Message> GetMessages(string userName)
        {
            return _messages.Where(x => x.UserName == userName).ToList();
        }

        public Message AddNewMessage(string messageTitle, string messageText, string userName)
        {
            Message message = new Message { CreateDate = DateTime.Now, Title = messageTitle, Context = messageText, UserName = userName };
            _messages.Add(message);
            return message;
        }

        public bool DeleteMessage(int id)
        {
            try
            {
                _messages.Remove(_messages.First(x => x.Id == id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
