﻿using MediatR;

namespace RO.DevTest.Application.Features.Auth.Commands.LoginCommand;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse> {
    public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken) {
         

        throw new NotImplementedException();
    }
}
