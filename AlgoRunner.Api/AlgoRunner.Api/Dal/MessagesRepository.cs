using AlgoRunner.Api.Dal.EF;
using AlgoRunner.Api.Dal.EF.Entities;
using AlgoRunner.Api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoRunner.Api.Dal
{
    public class MessagesRepository : RepositoryBase
    {        
        public MessagesRepository(AlgoRunnerDbContext dbContext, IMapper mapper, IHttpContextAccessor accessor) : base(dbContext, mapper, accessor) { }

        public List<MessageEntity> GetMessages(string userName)
        {
            return _dbContext.Messages
                .Where(x => x.UserName == userName)
                .OrderByDescending(x => x.CreateDate)
                .Select(x => _mapper.Map<MessageEntity>(x)).ToList();
        }

        public MessageEntity AddNewMessage(string messageTitle, string messageText, string userName)
        {
            MessageEntity message = new MessageEntity { CreateDate = DateTime.Now, Title = messageTitle, Context = messageText, UserName = userName };
            _dbContext.Messages.Add(_mapper.Map<Message>(message));
            _dbContext.SaveChanges();
            return message;
        }

        public void SetMessageAsReaded(string userName)
        {
            _dbContext.Messages.Where(x => x.UserName == userName && !x.isReaded).ToList().ForEach(x => x.isReaded = true);
            _dbContext.SaveChanges();
        }

        public bool DeleteMessage(int id)
        {
            try
            {
                _dbContext.Messages.Remove(_dbContext.Messages.First(x => x.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
