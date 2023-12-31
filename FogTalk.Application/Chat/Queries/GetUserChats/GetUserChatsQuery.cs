﻿using FogTalk.Application.Abstraction.Messaging;
using FogTalk.Application.Chat.Dto;

namespace FogTalk.Application.Chat.Queries;

public record GetUserChatsQuery(int userId, CancellationToken token) : IQuery<IEnumerable<ChatDto>>;
