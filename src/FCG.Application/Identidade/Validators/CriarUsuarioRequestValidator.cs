using FCG.Application.Identidade.DTOs;
using FCG.Domain.Identidade.ValueObjects;
using FluentValidation;

namespace FCG.Application.Identidade.Validators;

public class CriarUsuarioRequestValidator : AbstractValidator<CriarUsuarioRequest>
{
    public CriarUsuarioRequestValidator()
    {
        RuleFor(request => request.Nome)
            .NotEmpty()
            .Length(2, 100);
            
        RuleFor(request => request.Email)
            .NotEmpty()
            .MaximumLength(256)
            .Matches(Email.emailRegex)
            .WithMessage("'{PropertyName}' é um endereço de email inválido.");
        
        RuleFor(request => request.Senha)
            .NotEmpty()
            .Length(8, 128)
            .Must(s => s.Any(char.IsUpper))
            .WithMessage("'{PropertyName}' deve conter ao menos uma letra maiúscula.")
            .Must(s => s.Any(char.IsLower))
            .WithMessage("'{PropertyName}' deve conter ao menos uma letra minúscula.")
            .Must(s => s.Any(char.IsDigit))
            .WithMessage("'{PropertyName}' deve conter ao menos um número.")
            .Must(s => s.Any(c => "!@#$%^&*()".Contains(c)))
            .WithMessage("'{PropertyName}' deve conter ao menos um caractere especial");
        
        RuleFor(request => request.ConfirmacaoSenha)
            .NotEmpty()
            .Equal(request => request.Senha)
            .WithMessage("As senhas não conferem");
    }
}