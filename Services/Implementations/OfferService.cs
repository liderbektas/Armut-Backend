using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Test_Case.Models;

namespace Test_Case.Services.Implementations;

public class OfferService
{
    private readonly LZ_Context _lzContext;

    public OfferService(LZ_Context lzContext)
    {
        _lzContext = lzContext;
    }
    
    public async Task<Offer> CreateOfferAsync(int requestId, int userId, Offer offer)
    {
        var user = await _lzContext.Users
            .Where(u => u.Id == userId)
            .FirstOrDefaultAsync();
        
        var request = await _lzContext.Requests
            .Where(r => r.Id == requestId)
            .Include(r => r.Details)
            .FirstOrDefaultAsync();

        if (request == null)
        {
            return null;
        }
        
        var newOffer = new Offer()
        {
            Blurb = offer.Blurb,
            OfferPrice = offer.OfferPrice,
            Request = request,
            RequestId = request.Id,
            UserId = user.Id,
            User = user,
        };
        
        await _lzContext.Offers.AddAsync(newOffer);
        await _lzContext.SaveChangesAsync();
        return newOffer;
    }
    
    public async Task<List<Offer>> GetOfferByUserIdAsync(int id)
    {
        var offers =  await _lzContext.Offers
            .Where(o => o.UserId == id)
            .Include(o => o.User)
            .Include(o => o.Request)
            .ThenInclude(Request => Request.Details)
            .ToListAsync();

        return offers;
    }

    public async Task<List<Offer>> GetOfferByRequestIdAsync(int id)
    {
        var offers = await _lzContext.Offers
            .Where(o => o.RequestId == id)
            .Include(o => o.User)
            .Include(o => o.Request)
            .ThenInclude(r => r.Details)
            .Where(o => o.Request.Status == "active")
            .ToListAsync();

        return offers;
    }

    public async Task<Offer> UpdateOfferStatusAsync(int id, OfferStatusDTO offer)
    {
        var acceptedOffer = await _lzContext.Offers
            .Where(o => o.Id == id)
            .Include(o => o.User)
            .Include(o => o.Request)
            .ThenInclude(r => r.Details)
            .Where(o => o.Request.Status == "active")
            .FirstOrDefaultAsync();

        if (acceptedOffer == null)
        {
            return null;
        }

        acceptedOffer.Status = offer.Status;
        acceptedOffer.Request.IsAccepted = true;

        if (offer.Status == "Accepted")
        {
            var otherOffers = await _lzContext.Offers
                .Where(o => o.RequestId == acceptedOffer.RequestId && o.Id != id)
                .ToListAsync();

            foreach (var otherOffer in otherOffers)
            {
                otherOffer.Status = "Rejected";
            }
        }
        
        await _lzContext.SaveChangesAsync();
        return acceptedOffer;
    }

    public async Task<Offer> FinishOfferAsync(int offerId, int authorId, int recipientId, CommentDTO request)
    {
        var user = await _lzContext.Users
            .FirstOrDefaultAsync(u => u.Id == authorId);

        if (user == null)
        {
            throw new ArgumentException("Author not found.");
        }

        var finishedOffer = await _lzContext.Offers
            .Include(o => o.User)
            .Include(o => o.Request)
            .ThenInclude(r => r.Details)
            .FirstOrDefaultAsync(o => o.Id == offerId && o.Request.Status == "active");

        if (finishedOffer == null)
        {
            throw new ArgumentException("Offer not found or is not active.");
        }

        finishedOffer.Status = "Completed";
        finishedOffer.Request.Status = "Finished";

        if (string.IsNullOrWhiteSpace(request.Content))
        {
            throw new ArgumentException("Comment content cannot be empty.");
        }

        var comm = new Comment
        {
            AuthorId = user.Id,
            Content = request.Content,
            RecipientId = recipientId,
            UserRate = request.Rate,
        };
        
        var offers = await _lzContext.Offers
            .Where(o => o.RequestId == finishedOffer.RequestId && o.Id != offerId)
            .ToListAsync();

        _lzContext.Offers.RemoveRange(offers);
        await _lzContext.Comments.AddAsync(comm);
        await _lzContext.SaveChangesAsync();
    
        return finishedOffer;
    }

    public async Task<List<Offer>> GetFinishedOfferAsync(int id)
    {
        var finishedOffer = await _lzContext.Offers
            .Where(o => o.UserId == id)
            .Include(o => o.Request)
            .ThenInclude(r => r.User)
            .Where(o => o.Status == "Completed")
            .ToListAsync();
        
        return finishedOffer;
    }
    
    public async Task<List<Offer>> GetAcceptedRequestsAsync(int userId)
    {
        var acceptedOffer = await _lzContext.Offers
            .Where(o => o.UserId == userId && o.Status == "Accepted")
            .Include(o => o.Request)
            .ThenInclude(r => r.User)
            .ToListAsync();
        
        return acceptedOffer;
    }

    public async Task<List<Offer>> GellAllFinishOfferAsync()
    {
        var allFinishedOffer = await _lzContext.Offers
            .Where(o => o.Status == "Completed")
            .ToListAsync();
        
        return allFinishedOffer;
    }
    

}