using Ardalis.GuardClauses;
using Ardalis.Result;
using MediatR;
using SuntechIT.Demo.Domain.Repositories;
using Ardalis.Result.FluentValidation;
using SuntechIT.Demo.Application.Projects.Commands.Assign.Validators;
using Microsoft.AspNetCore.Identity;
using SuntechIT.Demo.Domain.Enums;

namespace SuntechIT.Demo.Application.Projects.Commands.Assign
{
    internal sealed class AssignProjectCommandHandler : IRequestHandler<AssignProjectCommand, Result>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IProjectRepository _projectRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AssignProjectCommandHandler(UserManager<IdentityUser> userManager,
            IProjectRepository projectRepository,
            IUnitOfWork unitOfWork)
        {
            _userManager = Guard.Against.Null(userManager);
            _projectRepository = Guard.Against.Null(projectRepository);
            _unitOfWork = Guard.Against.Null(unitOfWork);
        }

        public async Task<Result> Handle(AssignProjectCommand request, CancellationToken cancellationToken)
        {
            var validator = new AssignProjectCommandValidator();

            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                return Result.Invalid(result.AsErrors());
            }

            var project = await _projectRepository.GetProjectById(request.ProjectId, false, cancellationToken);

            if (project is null)
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorCode = "400", ErrorMessage = "Invalid project" }
                };

                return Result.Invalid(validationErrorList);
            }

            var user = await _userManager.FindByIdAsync(request.UserId);

            if (user is null)
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorMessage = "Invalid user" }
                };

                return Result.Invalid(validationErrorList);
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            if (!userRoles.Contains(Role.Normal.ToString()))
            {
                var validationErrorList = new List<ValidationError>()
                {
                    new ValidationError{ ErrorCode = "400", ErrorMessage = "Invalid role" }
                };

                return Result.Invalid(validationErrorList);
            }

            project.Assign(request.UserId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
