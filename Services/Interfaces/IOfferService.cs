using Test_Case.Models;

namespace Test_Case.Services.Interfaces;

public interface IOfferService
{
    Task<Offer> CreateOfferAsync(int id, Offer offer);
    Task<List<Offer>> GetOfferByUserIdAsync(int id);
    Task<List<Offer>> GetOfferByRequestIdAsync(int id);
    Task<Offer> UpdateOfferStatusAsync(int id, Offer offer);
    Task<Offer> FinishOfferAsync(int offerId, int authorId, int recipientId, CommentDTO Comment);
    Task<List<Offer>> GetFinishedOfferAsync(int id);
    Task<List<Offer>> GetAcceptedRequestsAsync(int userId);
    Task<List<Offer>> GellAllFinishOfferAsync(int userId);
}
