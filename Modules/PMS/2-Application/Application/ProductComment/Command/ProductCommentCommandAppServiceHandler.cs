using Application.ProductComment.Interface;
using Application.ViewModel;
using AutoMapper;
using Domain.Aggregates.ProductComment.Commands.Command;
using Domain.Common;
using FluentValidation.Results;

namespace Application.ProductComment.Command
{
    public class ProductCommentCommandAppServiceHandler: IProductCommentCommandAppServiceHandler
    {
    private readonly IMapper _mapper;
    private readonly IProductCommentCommandRepository _ProductCommentCommandRepository;
    private readonly IProductCommentQueryRepository _ProductCommentQueryRepository;
    private readonly IMediatorHandler _mediator;

    public ProductCommentCommandAppServiceHandler(IMapper mapper,
        IProductCommentCommandRepository ProductCommentCommandRepository,
        IProductCommentQueryRepository ProductCommentQueryRepository,
        IMediatorHandler mediator)
    {
        _mapper = mapper;
            _ProductCommentCommandRepository = ProductCommentCommandRepository;
        _mediator = mediator;
            _ProductCommentQueryRepository = ProductCommentQueryRepository;
    }

    public async Task<IEnumerable<ProductCommentViewModel>> GetAll()
    {
        return _mapper.Map<IEnumerable<ProductCommentViewModel>>(await _ProductCommentQueryRepository.GetAll());
    }

    public async Task<ProductCommentViewModel> GetById(long id)
    {
        return _mapper.Map<ProductCommentViewModel>(await _ProductCommentQueryRepository.GetById(id));
    }

    public async Task<ValidationResult> Register(ProductCommentViewModel ProductCommentViewModel)
    {
        var registerCommand = _mapper.Map<RegisterNewProductCommentCommand>(ProductCommentViewModel);
        return await _mediator.SendCommand(registerCommand);
    }

    public async Task<ValidationResult> Update(ProductCommentViewModel ProductCommentViewModel)
    {
        var updateCommand = _mapper.Map<UpdateProductCommentCommand>(ProductCommentViewModel);
        return await _mediator.SendCommand(updateCommand);
    }

    public async Task<ValidationResult> Remove(long id)
    {
        var removeCommand = new RemoveProductCommentCommand(id);
        return await _mediator.SendCommand(removeCommand);
    }

    public void Dispose() => GC.SuppressFinalize(this);
    }
}

