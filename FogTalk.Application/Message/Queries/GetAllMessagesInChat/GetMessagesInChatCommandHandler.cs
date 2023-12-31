﻿using FogTalk.Application.Abstraction.Messaging;
using FogTalk.Application.Message.Dto;
using FogTalk.Application.Message.Queries.GetMessagesInChat;
using FogTalk.Domain.Repositories;

namespace FogTalk.Application.Message.Queries.GetAllMessagesInChat;

public class GetMessagesInChatCommandHandler : IQueryHandler<GetMessagesInChatCommand, IEnumerable<ShowMessageDto>>
{
    private readonly IMessageRepository _messageRepository;

    public GetMessagesInChatCommandHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }
    public async Task<IEnumerable<ShowMessageDto>> Handle(GetMessagesInChatCommand request, CancellationToken cancellationToken)
    {
        cancellationToken = request.cancellationToken;
        return await _messageRepository.GetMessagesAsync<ShowMessageDto>(request.chatId, request.cursor, request.pageSize,cancellationToken);
    }
}